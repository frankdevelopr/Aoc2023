namespace Aoc2023Day20;

public class ButtonSystem
{
    private readonly string[] _lines;

    public ButtonSystem(string[] lines)
    {
        _lines = lines;
    }

    public long LowPulses { get; set; }
    public long HighPulses { get; set; }
    public long Result => LowPulses * HighPulses;

    public void Push(int pushed)
    {
        throw new NotImplementedException();
    }
}
