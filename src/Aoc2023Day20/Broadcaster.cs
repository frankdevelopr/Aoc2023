namespace Aoc2023Day20;

public class Broadcaster : PulseSender, IPulseReceiver
{
    public void Receive(Pulse pulse, IPulseReceiver? sender)
    {
        SendOthers(pulse);
    }
}
