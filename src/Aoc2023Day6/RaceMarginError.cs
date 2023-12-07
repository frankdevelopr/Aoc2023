namespace Aoc2023Day6;

public class RaceMarginError
{
    public int ErrorMargin { get; }

    public RaceMarginError(IEnumerable<RaceSpec> raceSpecs)
    {
        var raceCalculator = new RaceCalculator();
        var errorMargin = 1;

        foreach (var raceSpec in raceSpecs)
        {
            errorMargin *= raceCalculator.WaysToWin(raceSpec);
        }

        ErrorMargin = errorMargin;
    }
}
