using System.Diagnostics;

namespace Aoc2023Day20;

public abstract class PulseSender
{
    protected readonly List<IPulseReceiver> _outputs = new();

    public string Name { get; protected set; }
    public long SentLow { get; protected set; }
    public long SentHigh { get; protected set; }
    public Queue<Pulse> PendingPulses { get; }

    protected PulseSender(string name)
    {
        Name = name;
        PendingPulses = new Queue<Pulse>();
    }

    public void Receive(Pulse pulse)
    {
        PendingPulses.Enqueue(pulse);
    }

    public PulseSender Connect(IPulseReceiver module)
    {
        _outputs.Add(module);

        return this;
    }

    public void SendOthers(Pulse pulse)
    {
        CountPulse(pulse, _outputs.Count);

        foreach (var module in _outputs)
        {
            Debug.WriteLine($"{Name} -{pulse.ToString().ToLowerInvariant()}-> {module.Name}");

            module.Receive(pulse, this as IPulseReceiver);
        }
    }

    protected void CountPulse(Pulse pulse, int times = 1)
    {
        if (pulse == Pulse.Low)
            SentLow += times;
        else
            SentHigh += times;
    }
}
