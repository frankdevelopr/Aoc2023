namespace Aoc2023Day20;

public abstract class PulseSender
{
    protected readonly List<IPulseReceiver> _outputs = new();

    public void Connect(IPulseReceiver module)
    {
        _outputs.Add(module);
    }

    public void SendOthers(Pulse pulse)
    {
        foreach(var module in _outputs)
        {
            module.Receive(pulse, this as IPulseReceiver);
        }
    }
}
