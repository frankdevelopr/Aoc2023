
namespace Aoc2023Day6;

public class SingleRaceReader : IRaceReader
{
    public IEnumerable<RaceSpec> Races { get; } = Enumerable.Empty<RaceSpec>();

    public SingleRaceReader(string[] lines)
    {
        if (lines.Length != 2)
        {
            return;
        }

        var timesTxt = lines[0].Split(':')[1];
        var time = Parse(timesTxt);
        var distanceTxt = lines[1].Split(':')[1];
        var distance = Parse(distanceTxt);

        Races = new List<RaceSpec>([new RaceSpec(time, distance)]);
    }

    private static long Parse(string numbersWithSpaces)
    {
        var numberTxt = string.Concat(numbersWithSpaces.Where(c => char.IsDigit(c)));

        var number = long.Parse(numberTxt);

        return number;
    }
}
