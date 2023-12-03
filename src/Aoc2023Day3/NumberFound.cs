namespace Aoc2023Day3;

public class NumberFound
{
    public NumberFound(int value, int startPosition, int endPosition)
    {
        Value = value;
        StartPosition = startPosition;
        EndPosition = endPosition;
    }

    public int Value { get; }
    public int StartPosition { get; }
    public int EndPosition { get; }
}
