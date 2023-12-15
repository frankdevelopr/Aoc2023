﻿namespace Aoc2023Day14;

public class PlatformSystem
{
    private readonly PlatformTilt _platformTilt;

    public PlatformSystem(string[] lines)
    {
        var platform = lines.Select(p => p.ToArray());

        _platformTilt = new PlatformTilt(platform);
    }

    public long Calculate()
    {
        var tilt = _platformTilt.TiltNorth();
        var loadCalculator = new LoadCalculator(tilt.ToArray());

        return loadCalculator.Calculate();
    }
}
