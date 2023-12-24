namespace Aoc2023Day20;

public class FlipFlop : PulseSender, IPulseReceiver
{
    public Status Status { get; private set; }

    public void Receive(Pulse pulse, IPulseReceiver? sender)
    {
        if (pulse == Pulse.High)
        {
            return;
        }

        if (Status == Status.Off)
        {
            Status = Status.On;
            SendOthers(Pulse.High);
        }
        else
        {
            Status = Status.Off;
            SendOthers(Pulse.Low);
        }
    }
}
