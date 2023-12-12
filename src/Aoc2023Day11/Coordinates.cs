namespace Aoc2023Day11;

public class Coordinates
{
    public int Y { get; }
    public int X { get; }

    public Coordinates(int y, int x)
    {
        Y = y;
        X = x;
    }

    public long DistanceTo(Coordinates other)
    {
        return Math.Abs(Y - other.Y) + Math.Abs(X - other.X);
    }
}
