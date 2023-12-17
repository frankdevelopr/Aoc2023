namespace Aoc2023Day14;

public class PlatformTilt : IPlatformTilt
{
    private readonly char[][] _platform;
    private readonly int _height;
    private readonly int _width;

    private const char RoundedRock = 'O';
    private const char FreePosition = '.';

    public IEnumerable<string> Platform => _platform.Select(p => new string(p.ToArray()));

    public PlatformTilt(IEnumerable<char[]> platform)
    {
        _platform = platform.ToArray();
        _height = _platform.Length;
        _width = _platform[0].Length;
    }

    public void Cycle(long cycles)
    {
        for (var i = 0L; i < cycles; ++i)
        {
            TiltNorth();
            TiltWest();
            TiltSouth();
            TiltEast();

            /*if (i % 10_000_000 == 0)
            {
                Console.WriteLine($"Cycles done {i}");
            }*/
        }
    }

    public void TiltNorth()
    {
        for (var y = 1; y < _height; ++y)
        {
            for (var x = 0; x < _width; ++x)
            {
                var pos = _platform[y][x];

                if (IsRoundedRock(pos))
                {
                    TiltNorthEx(pos, y, x);
                }
            }
        }
    }

    private void TiltNorth(char pos, int y, int x)
    {
        for (var i = y-1; i >= 0; --i)
        {
            if (!IsFreePosition(_platform[i][x]))
            {
                return;
            }

            // TODO: no need to do so many changes, just do it at the end of the loop
            _platform[i][x] = pos;
            _platform[i+1][x] = FreePosition;
        }
    }

    private void TiltNorthEx(char pos, int y, int x)
    {
        var last = -1;

        for (var i = y-1; i >= 0; --i)
        {
            if (!IsFreePosition(_platform[i][x]))
            {
                break;
            }

            last = i;
        }

        if (last != -1)
        {
            _platform[last][x] = pos;
            _platform[y][x] = FreePosition;
        }
    }

    public void TiltWest()
    {
        for (var x = 1; x < _width; ++x)
        {
            for (var y = 0; y < _height; ++y)
            {
                var pos = _platform[y][x];

                if (IsRoundedRock(pos))
                {
                    TiltWestEx(pos, y, x);
                }
            }
        }
    }

    private void TiltWestEx(char pos, int y, int x)
    {
        var last = -1;

        for (var i = x-1; i >= 0; --i)
        {
            if (!IsFreePosition(_platform[y][i]))
            {
                break;
            }

            last = i;
        }

        if (last != -1)
        {
            _platform[y][last] = pos;
            _platform[y][x] = FreePosition;
        }
    }

    public void TiltSouth()
    {
        for (var y = _height-2; y >= 0; --y)
        {
            for (var x = 0; x < _width; ++x)
            {
                var pos = _platform[y][x];

                if (IsRoundedRock(pos))
                {
                    TiltSouthEx(pos, y, x);
                }
            }
        }
    }

    private void TiltSouthEx(char pos, int y, int x)
    {
        var last = -1;

        for (var i = y+1; i < _height; ++i)
        {
            if (!IsFreePosition(_platform[i][x]))
            {
                break;
            }

            last = i;
        }

        if (last != -1)
        {
            _platform[last][x] = pos;
            _platform[y][x] = FreePosition;
        }
    }

    public void TiltEast()
    {
        for (var x = _width-2; x >= 0; --x)
        {
            for (var y = 0; y < _height; ++y)
            {
                var pos = _platform[y][x];

                if (IsRoundedRock(pos))
                {
                    TiltEastEx(pos, y, x);
                }
            }
        }
    }

    private void TiltEastEx(char pos, int y, int x)
    {
        var last = -1;

        for (var i = x+1; i < _width; ++i)
        {
            if (!IsFreePosition(_platform[y][i]))
            {
                break;
            }

            last = i;
        }

        if (last != -1)
        {
            _platform[y][last] = pos;
            _platform[y][x] = FreePosition;
        }
    }

    private static bool IsFreePosition(char pos)
    {
        return pos == FreePosition;
    }

    private static bool IsRoundedRock(char pos)
    {
        return pos == RoundedRock;
    }


}
