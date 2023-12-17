namespace Aoc2023Day14;

public class PlatformSystemEx : IPlatformSystem
{
    private readonly PlatformTiltEx _platformTilt;

    public PlatformSystemEx(string[] lines)
    {
        var platform = lines.Select(p => p.ToArray());

        _platformTilt = new PlatformTiltEx(platform);
    }

    public long Calculate()
    {
        _platformTilt.TiltNorth();

        return CalculateInternal();
    }

    /*public long Cycle(long cycles)
    {
        //_platformTilt.Cycle(cycles);

        return CalculateInternal();
    }*/

    public long CalculateInternal()
    {
        var tilt = _platformTilt.Platform;
        var loadCalculator = new LoadCalculator(tilt.ToArray());

        return loadCalculator.Calculate();
    }

    public long Cycle(long cycles)
    {
        throw new NotImplementedException();
    }
}
