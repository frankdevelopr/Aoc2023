namespace Aoc2023Day20;

public class Conjunction : PulseSender, IPulseReceiver
{
    private readonly Dictionary<IPulseReceiver, Pulse> _inputs = new();

    public void RegisterInput(IPulseReceiver input)
    {
        _inputs.Add(input, Pulse.Low);
    }

    public void Receive(Pulse pulse, IPulseReceiver? sender)
    {
        _inputs[sender!] = pulse;

        if (_inputs.Values.Any(v => v == Pulse.Low) || !_inputs.Any())
        {
            SendOthers(Pulse.High);
        }
        else
        {
            SendOthers(Pulse.Low);
        }
    }
}
