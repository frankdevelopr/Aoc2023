﻿namespace Aoc2023Day20;

public class FlipFlop : PulseSender, IPulseReceiver
{
    public Status Status { get; private set; }

    public FlipFlop(string name) : base(name)
    {
    }

    public void Receive(Pulse pulse, IPulseReceiver? sender)
    {
        base.Receive(pulse);
    }

    public IList<IPulseReceiver> Process()
    {
        var pulse = PendingPulses.Dequeue();

        if (pulse == Pulse.High)
        {
            return new List<IPulseReceiver>();
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

        return _outputs;
    }
}
