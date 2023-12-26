using System.Diagnostics;

namespace Aoc2023Day20;

public class ButtonSystem
{
    private readonly string[] _lines;
    private Broadcaster _initiator;
    private readonly Dictionary<string, IPulseReceiver> _modules;

    public ButtonSystem(string[] lines)
    {
        _lines = lines;
        _modules = new();
        Parse();
    }

    public long LowPulses { get; set; }
    public long HighPulses { get; set; }
    public long Rank => LowPulses * HighPulses;

    public ButtonSystem(Broadcaster initiator)
    {
        _initiator = initiator;
    }

    public void Push(int pushed)
    {
        LowPulses += pushed;

        for (var i = 0; i < pushed; ++i)
        {
            Debug.WriteLine($"button -{Pulse.Low.ToString().ToLowerInvariant()}-> {_initiator.Name}");

            _initiator.Receive(Pulse.Low, null);
            _initiator.Process();
        }

        CalculatePulses();
    }

    public long PushRx()
    {
        var watch = new Stopwatch();
        watch.Start();
        var rx = (Broadcaster)_modules["rx"];

        while (!rx.LowReceived)
        {
            LowPulses++;

            Debug.WriteLine($"button -{Pulse.Low.ToString().ToLowerInvariant()}-> {_initiator.Name}");

            _initiator.Receive(Pulse.Low, null);
            _initiator.Process();

            if (LowPulses % 1_000_000 == 0)
            {
                Console.WriteLine($"Processed {LowPulses} in {watch.Elapsed}");
            }
        }

        return LowPulses;
    }

    private void CalculatePulses()
    {
        foreach (var module in _modules.Values)
        {
            LowPulses += ((PulseSender)module).SentLow;
            HighPulses += ((PulseSender)module).SentHigh;
        }
    }

    public void Parse()
    {
        /*
         * broadcaster -> a, b, c
           %a -> b
           %b -> c
           %c -> inv
           &inv -> a
         */

        CreateModules();
        ConnectModules();
    }

    private void ConnectModules()
    {
        foreach (var line in _lines)
        {
            var tokens = line.Split("->");

            var left = _modules[tokens[0].Trim('%', '&', ' ')];
            var rights = tokens[1].Split(',').Select(t => t.Trim());

            foreach (var rightName in rights)
            {
                if (!_modules.ContainsKey(rightName))
                    _modules.Add(rightName, new Broadcaster(rightName));

                var right = _modules[rightName];

                left.Connect(right);

                if (right is Conjunction)
                {
                    var conj = right as Conjunction;
                    conj?.RegisterInput(left);
                }
            }
        }
    }

    private void CreateModules()
    {
        foreach (var line in _lines)
        {
            var tokens = line.Split("->");

            var module = tokens[0].Trim();

            var type = module[0];

            var name = module.Trim('%', '&');

            if (type == '%')
            {
                _modules.Add(name, new FlipFlop(name));
            }
            else if (type == '&')
            {
                _modules.Add(name, new Conjunction(name));
            }
            else
            {
                _initiator = new Broadcaster(name);
                _modules.Add(name, _initiator);
            }
        }
    }
}
