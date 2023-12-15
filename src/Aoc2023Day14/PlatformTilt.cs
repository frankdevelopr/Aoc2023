
namespace Aoc2023Day14;

public class PlatformTilt
{
    private readonly char[][] _platform;
    private readonly int _height;
    private readonly int _width;

    private const char RoundedRock = 'O';
    private const char FreePosition = '.';

    public PlatformTilt(IEnumerable<char[]> platform)
    {
        _platform = platform.ToArray();
        _height = _platform.Length;
        _width = _platform[0].Length;
    }

    public IEnumerable<string> Cycle(long cycles)
    {
        return TiltNorth();
    }

    public IEnumerable<string> TiltNorth()
    {
        for (var y = 1; y < _height; ++y)
        {
            for (var x = 0; x < _width; ++x)
            {
                var pos = _platform[y][x];

                if (IsRoundedRock(pos))
                {
                    TiltNorth(pos, y, x);
                }
            }
        }

        return _platform.Select(p => new string(p.ToArray()));
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

    private static bool IsFreePosition(char pos)
    {
        return pos == FreePosition;
    }

    private static bool IsRoundedRock(char pos)
    {
        return pos == RoundedRock;
    }

    
}
