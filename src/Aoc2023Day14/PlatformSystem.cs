namespace Aoc2023Day14;

public class PlatformSystem : IPlatformSystem
{
    private readonly PlatformTilt _platformTilt;

    public PlatformSystem(string[] lines)
    {
        var platform = lines.Select(p => p.ToArray());

        _platformTilt = new PlatformTilt(platform);
    }

    public long Calculate()
    {
        _platformTilt.TiltNorth();

        return CalculateInternal();
    }

    public long Cycle(long cycles)
    {
        _platformTilt.Cycle(cycles);

        return CalculateInternal();
    }

    public long CalculateInternal()
    {
        var tilt = _platformTilt.Platform;
        var loadCalculator = new LoadCalculator(tilt.ToArray());

        return loadCalculator.Calculate();
    }
}
