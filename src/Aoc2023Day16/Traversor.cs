
using System.Collections.Concurrent;
using System.Collections.Frozen;
using System.Text;

namespace Aoc2023Day16;

public class Traversor
{
    private static readonly FrozenSet<char> DirectionTiles = (new char[] { '|', '-', '\\', '/' }).ToFrozenSet();

    private readonly char[][] _layout;
    private readonly ConcurrentDictionary<Direction, bool>[,] _visitedFrom;
    private readonly bool[,] _visited;
    private readonly DirectionCalculator _directionCalculator;
    private readonly Navigator _navigator;
    private readonly int _height;
    private readonly int _width;

    public Traversor(char[][] layout)
    {
        _height = layout.Length;
        _width = layout[0].Length;

        _layout = layout;
        _visited = new bool[_height, _width];
        _visitedFrom = new ConcurrentDictionary<Direction, bool>[_height, _width];

        _directionCalculator = new DirectionCalculator();
        _navigator = new Navigator(layout);
    }

    public void Traverse()
    {
        TraverseFrom(0, 0, Direction.East);
    }

    public string PaintVisited()
    {
        var paint = new StringBuilder();

        for (var y = 0; y < _height; ++y)
        {
            for (var x = 0; x < _width; ++x)
            {
                paint.Append( _visited[y,x] ? '#' : '.');
            }

            paint.Append('\r').Append('\n');
        }

        paint.Remove(paint.Length-2, 2);

        return paint.ToString();
    }

    public void TraverseFrom(int y, int x, Direction goingTo)
    {
        if (HasBeenVisitedFrom(y, x, goingTo))
        {
            return;
        }

        var tile = _layout[y][x];
        var directions = _directionCalculator.Next(tile, goingTo);

        Parallel.ForEach(directions, direction =>
        {
            var pos = _navigator.Next(new Coordinate(y,x), direction);

            if (pos != null)
            {
                TraverseFrom(pos.Y, pos.X, direction);
            }
        });
    }

    private bool HasBeenVisitedFrom(int y, int x, Direction goingTo)
    {
        var tile = _layout[y][x];

        _visited[y,x] = true;

        if (!DirectionTiles.Contains(tile))
        {
            return false;
        }

        if (_visitedFrom[y, x]?.ContainsKey(goingTo) == true)
        {
            return true;
        }

        if (_visitedFrom[y,x] == null)
        {
            _visitedFrom[y,x] = new ConcurrentDictionary<Direction, bool>();
        }

        _visitedFrom[y,x].GetOrAdd(goingTo, true);

        return false;
    }

    public long Energy()
    {
        var total = 0L;

        foreach (var visited in _visited)
        {
            total += visited ? 1 : 0;
        }

        return total;
    }
}
