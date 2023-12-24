namespace Aoc2023Day20;

public class Broadcaster : PulseSender, IPulseReceiver
{
    public Broadcaster(string name) : base(name)
    {
    }

    public void Process()
    {
        // Do nothing
    }

    public void Receive(Pulse pulse, IPulseReceiver? sender)
    {
        SendOthers(pulse);
    }
}
