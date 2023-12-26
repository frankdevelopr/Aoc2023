using Utils;

namespace Aoc2023Day21;

public class StepsAwayCounter
{
    public long PlotsReached { get; set; }

    private readonly char[][] _map;
    private readonly int _height;
    private readonly int _width;

    private readonly Position _startPosition;
    private HashSet<Position> _plots = [];

    public StepsAwayCounter(string[] lines)
    {
        _height = lines.Length;
        _width = lines[0].Length;

        _map = lines.Select(t => t.ToArray()).ToArray();
        _startPosition = FindStartPosition();
        _plots.Add(_startPosition);
    }

    public void Walk(int steps)
    {
        for (var i = 0; i < steps; ++i)
        {
            var newPositions = new HashSet<Position>();

            foreach (var current in _plots)
            {
                foreach (var position in current.Near())
                {
                    if (IsValid(position))
                        newPositions.Add(position);
                }
            }

            _plots = newPositions;
        }

        PlotsReached = _plots.Count;
    }

    private bool IsValid(Position position)
    {
        if (position.Y < 0 || position.Y >= _height)
            return false;

        if (position.X < 0 || position.X >= _width)
            return false;

        return _map[position.Y][position.X] == '.' || _map[position.Y][position.X] == 'S';
    }

    private Position FindStartPosition()
    {
        for (var y = 0; y < _height; y++)
        {
            for (var x = 0; x < _width; x++)
            {
                if (_map[y][x] == 'S')
                {
                    return new Position(y, x);
                }
            }
        }

        return new Position(0, 0);
    }

    
}
