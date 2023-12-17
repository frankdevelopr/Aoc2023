namespace Aoc2023Day14;

public class PlatformTiltEx : IPlatformTilt
{
    private readonly char[][] _platform;
    private readonly int _height;
    private readonly int _width;
    private readonly List<int>[] _stoppers;

    private const char RoundedRock = 'O';
    private const char FixedRock = '#';
    private const char FreePosition = '.';

    public IEnumerable<string> Platform => _platform.Select(p => new string(p.ToArray()));

    public PlatformTiltEx(IEnumerable<char[]> platform)
    {
        _platform = platform.ToArray();
        _height = _platform.Length;
        _width = _platform[0].Length;

        _stoppers = FindStoppers();
    }

    public void TiltNorth()
    {
        // if empty, just move the O up (optimized enough?)
        Parallel.For(0, _width, x =>
        {
            var last = 0;

            // can be parallelized?
            foreach (var stop in _stoppers[x])
            {
                MoveRoundRock(x, last, stop);
                last = stop+1;
            }

            MoveRoundRock(x, last, _height);
        });
    }

    private void MoveRoundRock(int x, int startY, int limit)
    {
        for (var y = startY; y < limit; ++y)
        {
            if (_platform[y][x] == RoundedRock)
            {
                if (y != startY)
                {
                    _platform[startY][x] = RoundedRock;
                    _platform[y][x] = FreePosition;
                }

                startY++;
            }
        }
    }

    private List<int>[]? FindStoppers()
    {
        var stoppers = new List<int>[_width];

        for (var x = 0; x < _width; ++x)
        {
            stoppers[x] = [];

            for (var y = 0; y < _height; ++y)
            {
                if (_platform[y][x] == FixedRock)
                {
                    stoppers[x].Add(y);
                }
            }
        }

        return stoppers;
    }

    /*public void Cycle(long cycles)
    {
        for (var i = 0L; i < cycles; ++i)
        {
            TiltNorth();
            TiltWest();
            TiltSouth();
            TiltEast();

            if (i % 10_000_000 == 0)
            {
                Console.WriteLine($"Cycles done {i}");
            }
        }
    }*/


    private static bool IsFreePosition(char pos)
    {
        return pos == FreePosition;
    }

    private static bool IsRoundedRock(char pos)
    {
        return pos == RoundedRock;
    }


}
