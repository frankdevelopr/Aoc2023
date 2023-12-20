using Utils;

namespace Aoc2023Day18;

public class Trench
{
    private readonly TrenchSize _trenchSpecs;
    private readonly char[,] _layout;

    public long Perimeter { get; private set; }

    public Trench(TrenchSize trenchSpecs)
    {
        _trenchSpecs = trenchSpecs;
        _layout = InitializeLayout(trenchSpecs);

        Traverse();
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

            for (var i = 0; i < instruction.Positions;  i++)
            {
                var next = new Position(current.Y + nextY, current.X + nextX);
                _layout[next.Y, next.X] = '#';
                // Assumption there are no path overlaps in instructions
                Perimeter++;

                current = next;
            }
        }
    }

    public string Paint()
    {
        return ArrayUtils.ToString(_layout);
    }

    private static char[,] InitializeLayout(TrenchSize trenchSpecs)
    {
        var layout = new char[trenchSpecs.Height, trenchSpecs.Width];

        ArrayUtils.InitializeWith(layout, '.');

        return layout;
    }
}