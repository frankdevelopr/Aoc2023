namespace Aoc2023Day6;

public class RaceCalculator
{
    public int WaysToWin(RaceSpec raceSpec)
    {
        return WaysToWin(raceSpec.Time, raceSpec.MaxDistance);
    }

    private int WaysToWin(int time, int maxDistance)
    {
        var wins = 0;

        for (var i = 1; i < time; ++i)
        {
            var speed = i;
            var timeInMovement = time - i;

            var distance = timeInMovement * speed;

            if (distance > maxDistance)
            {
                wins++;
            }
        }

        return wins;
    }
}
