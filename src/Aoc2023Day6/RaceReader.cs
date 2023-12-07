namespace Aoc2023Day6;

public class RaceReader
{
    public IEnumerable<RaceSpec> Races { get; } = Enumerable.Empty<RaceSpec>();

    public RaceReader(string[] lines)
    {
        if (lines.Length != 2)
        {
            return;
        }

        var timesTxt = lines[0].Split(':')[1];
        var times = Parse(timesTxt);
        var distanceTxt = lines[1].Split(':')[1];
        var distances = Parse(distanceTxt);

        if (times.Count != distances.Count)
        {
            return;
        }

        var races = new List<RaceSpec>();

        for (var i = 0; i < times.Count; i++)
        {
            races.Add(new RaceSpec(times[i], distances[i]));
        }

        Races = races;
    }

    private static List<int> Parse(string numbers)
    {
        var parsed = numbers.Trim().Split(" ")
            .Where(t => !string.IsNullOrEmpty(t))
            .Select(i => int.Parse(i.Trim()));

        return parsed.ToList();
    }
}
