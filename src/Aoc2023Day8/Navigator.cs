namespace Aoc2023Day8;

public class Navigator
{
    public string Directions { get; }

    private int _current = 0;

    public Navigator(string directions)
    {
        if (directions.Any(c => c != 'L' && c != 'R'))
            throw new ArgumentException(nameof(directions));

        Directions = directions;
    }

    public Direction Next()
    {
        if (_current >=  Directions.Length)
        {
            _current = 0;
        }

        return ToDirection(Directions[_current++]);
    }

    public void Reset()
    {
        _current = 0;
    }

    private Direction ToDirection(char direction)
    {
        switch (direction)
        {
            case 'L':
                return Direction.Left;
            case 'R':
                return Direction.Right;
        }

        throw new ArgumentException(nameof(direction));
    }
}
