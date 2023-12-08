namespace Aoc2023Day8;

public class Navigator
{
    private readonly string _directions;
    private int _current = 0;

    public Navigator(string directions)
    {
        if (directions.Any(c => c != 'L' && c != 'R'))
            throw new ArgumentException(nameof(directions));

        _directions = directions;
    }

    public Direction Next()
    {
        if (_current >=  _directions.Length)
        {
            _current = 0;
        }

        return ToDirection(_directions[_current++]);
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
