namespace Aoc2023Day6;

public class RaceSpec
{
    public int Time { get; set; }
    public int MaxDistance { get; set; }

    public RaceSpec(int time, int maxDistance)
    {
        Time = time;
        MaxDistance = maxDistance;
    }
}
