namespace Aoc2023Day6;

public class RaceSpec
{
    public long Time { get; set; }
    public long MaxDistance { get; set; }

    public RaceSpec(long time, long maxDistance)
    {
        Time = time;
        MaxDistance = maxDistance;
    }
}
