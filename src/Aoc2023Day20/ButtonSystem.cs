namespace Aoc2023Day20;

public class ButtonSystem
{
    private readonly string[] _lines;
    private readonly Broadcaster _initiator;

    public ButtonSystem(string[] lines)
    {
        _lines = lines;
    }

    public ButtonSystem(Broadcaster initiator)
    {
        _initiator = initiator;
    }

    public long LowPulses { get; set; }
    public long HighPulses { get; set; }
    public long Result => LowPulses * HighPulses;

    public void Push(int pushed)
    {
        for (var i = 0; i < pushed; ++i)
        {
            _initiator.Receive(Pulse.Low, null);
            _initiator.Process();
        }
    }
}
