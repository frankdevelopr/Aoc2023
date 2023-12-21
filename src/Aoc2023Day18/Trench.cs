using Utils;

namespace Aoc2023Day18;

public class Trench
{
    private readonly TrenchSize _trenchSpecs;
    private readonly char[,] _layout;
    private readonly long _height;
    private readonly long _width;

    public long Perimeter { get; private set; }
    public long Size { get; private set; }
    public long FillVisits { get; private set; }

    private readonly string _paintedPerimeter;

    public Trench(TrenchSize trenchSpecs)
    {
        _trenchSpecs = trenchSpecs;
        _height = _trenchSpecs.Height;
        _width = _trenchSpecs.Width;
        _layout = InitializeLayout(trenchSpecs);

        Traverse();
        _paintedPerimeter = ArrayUtils.ToString(_layout);
        FillIn();
    }

    public string Paint()
    {
        return ArrayUtils.ToString(_layout);
    }

    public string PaintPerimeter()
    {
        return _paintedPerimeter;
    }

    private void FillIn()
    {
        var inTile = FindInTile();
        Size = Perimeter;
        FillFrom(inTile);
    }

    private void FillFrom(Position inTile)
    {
        var queue = new Queue<Position>();
        queue.Enqueue(inTile);

        var visits = 0L;

        while (queue.Count > 0)
        {
            visits++;
            var position = queue.Dequeue();

            var y = position.Y;
            var x = position.X;

            if (!InBound(position) || _layout[y, x] == '#')
            {
                continue;
            }

            _layout[y, x] = '#';
            Size++;

            queue.Enqueue(new Position(y, x-1));
            queue.Enqueue(new Position(y, x+1));
            queue.Enqueue(new Position(y-1, x));
            queue.Enqueue(new Position(y+1, x));
        }

        FillVisits = visits;
    }

    /* Stackoverflow exception
    private void FillFrom(Position inTile)
    {
        var y = inTile.Y;
        var x = inTile.X;

        if (!InBound(inTile) || _layout[y, x] == '#')
        {
            return;
        }

        _layout[y, x] = '#';
        Size++;

        var positions = new List<Position>
        {
            new Position(y, x-1),
            new Position(y, x+1),
            new Position(y-1, x),
            new Position(y+1, x)
        };

        // use queue and process current and add others

        foreach (var position in positions.Where(InBound).Where(t => _layout[t.Y, t.X] != '#'))
        {
            FillFrom(position);
        }
    }*/

    private Position FindInTile()
    {
        var pos = _trenchSpecs.InitialPosition;

        // TODO: Partial solution, this will only work for current input data
        // but will not work in all cases
        // in fact for current data new Position(Initial+1 in y & x will work)
        var topLeft = new Position(pos.Y-1, pos.X-1);
        var topRight = new Position(pos.Y-1, pos.X+1);
        var bottomLeft = new Position(pos.Y+1, pos.X-1);
        var bottomRight = new Position(pos.Y+1, pos.X+1);

        var positions = new Position[] { topLeft, topRight, bottomLeft, bottomRight };

        foreach (var position in positions)
        {
            if (IsInside(position))
            {
                return position;
            }
        }

        throw new Exception("No position found");
    }

    private bool IsInside(Position position)
    {
        if (!InBound(position))
        {
            return false;
        }

        var traversedBorder = 0;
        for (var x = position.X; x >= 0 ; --x)
        {
            if (_layout[position.Y, x] == '#')
            {
                traversedBorder++;
            }
        }

        return traversedBorder % 2 != 0;
    }

    private bool InBound(Position p)
    {
        return p.Y >= 0 && p.X >= 0 && p.Y < _height && p.X < _width;
    }

    private void Traverse()
    {
        var current = _trenchSpecs.InitialPosition;

        foreach (var instruction in _trenchSpecs.Instructions)
        {
            var nextY = 0;
            var nextX = 0;

            switch (instruction.Direction)
            {
                case 'U':
                    nextY = -1;
                    break;
                case 'D':
                    nextY = 1;
                    break;
                case 'L':
                    nextX = -1;
                    break;
                case 'R':
                    nextX = 1;
                    break;
            }

            for (var i = 0; i < instruction.Positions; i++)
            {
                var next = new Position(current.Y + nextY, current.X + nextX);
                _layout[next.Y, next.X] = '#';
                // Assumption there are no path overlaps in instructions
                Perimeter++;

                current = next;
            }
        }
    }

    private static char[,] InitializeLayout(TrenchSize trenchSpecs)
    {
        var layout = new char[trenchSpecs.Height, trenchSpecs.Width];

        ArrayUtils.InitializeWith(layout, '.');

        return layout;
    }
}