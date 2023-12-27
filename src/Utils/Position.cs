namespace Utils;

public class Position
{
    public int Y { get; }
    public int X { get; }

    public Position(int y, int x)
    {
        Y = y;
        X = x;
    }

    public List<Position> Near()
    {
        return [North(), South(), East(), West()];
    }

    public Position North()
    {
        return new Position(Y-1, X);
    }

    public Position South()
    {
        return new Position(Y+1, X);
    }

    public Position West()
    {
        return new Position(Y, X-1);
    }

    public Position East()
    {
        return new Position(Y, X+1);
    }

    public override bool Equals(object? obj)
    {
        return obj is Position position &&
               Y == position.Y &&
               X == position.X;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Y, X);
    }
}