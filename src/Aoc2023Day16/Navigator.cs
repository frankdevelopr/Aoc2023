namespace Aoc2023Day16;

public class Navigator
{
    private readonly int _height;
    private readonly int _width;

    public Navigator(char[][] layout)
    {
        _height = layout.Length;
        _width = layout[0].Length;
    }

    public Navigator(int height, int width)
    {
        _height = height;
        _width = width;
    }

    public Coordinate? Next(Coordinate current, Direction next)
    {
        switch (next)
        {
            case Direction.North:
                if (current.Y == 0) return null;
                return new Coordinate(current.Y-1, current.X);
            case Direction.South:
                if (current.Y == _height-1) return null;
                return new Coordinate(current.Y+1, current.X);
            case Direction.West:
                if (current.X == 0) return null;
                return new Coordinate(current.Y, current.X-1);
            case Direction.East:
                if (current.X == _width-1) return null;
                return new Coordinate(current.Y, current.X+1);
        }

        return null;
    }
}
