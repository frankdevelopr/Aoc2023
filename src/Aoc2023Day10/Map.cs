namespace Aoc2023Day10;

public class Map
{
    public Position StartPosition { get; }
    public long Steps { get; }

    private readonly string[] _lines;
    private readonly int _maxX;
    private readonly int _maxY;

    public Map(string[] lines)
    {
        _lines = lines;
        StartPosition = FindSymbol(Symbol.StartSymbol);
        Steps = RoundTrip();

        _maxY = _lines.Length-1;
        _maxX = _lines[0].Length-1;
    }

    private long RoundTrip()
    {
        var table = new SymbolTable();

        var steps = 0;
        var s = StartPosition;
        var openTile = FindOpenTile(s);

        var lastDirection = Direction.West;

        while (openTile.X != s.X || openTile.Y != s.Y)
        {
            steps++;
            var label = _lines[openTile.Y][openTile.X];
            var symbol = table.Get(label);
            var direction = symbol.NextFrom(lastDirection);

            openTile = Navigate(direction, openTile);

            lastDirection = Negate(direction);
        }

        return steps+1;
    }

    // For connectors, it connects from, but don't navigate to
    private Direction Negate(Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                return Direction.South;
            case Direction.South:
                return Direction.North;
            case Direction.West:
                return Direction.East;
            case Direction.East:
                return Direction.West;
        }

        throw new NotImplementedException();
    }

    private Position Navigate(Direction direction, Position position)
    {
        switch (direction)
        {
            case Direction.North:
                return GetNorth(position);
            case Direction.South:
                return GetSouth(position);
            case Direction.West:
                return GetWest(position);
            case Direction.East:
                return GetEast(position);
        }

        throw new NotImplementedException();
    }

    private Position FindOpenTile(Position position)
    {
        // TODO: should find any connected tile to Start
        return GetEast(position);
    }

    private Position GetNorth(Position position)
    {
        var next = new Position(position.X, position.Y-1);

        return next;
    }

    private Position GetEast(Position position)
    {
        var next = new Position(position.X+1, position.Y);

        return next;
    }

    private Position GetSouth(Position position)
    {
        var next = new Position(position.X, position.Y+1);

        return next;
    }

    private Position GetWest(Position position)
    {
        var next = new Position(position.X-1, position.Y);

        return next;
    }

    public bool OutOfBound(Position position)
    {
        return position.X < 0 || position.Y < 0 || position.X > _maxX || position.Y > _maxY;
    }

    private Position FindSymbol(string startSymbol)
    {
        for (var y = 0; y < _lines.Length; ++y)
        {
            var line = _lines[y];

            for (var x = 0; x < line.Length; ++x)
            {
                if (line[x].ToString() == startSymbol)
                    return new Position(x, y);
            }
        }

        return new Position(-1, -1);
    }
}
