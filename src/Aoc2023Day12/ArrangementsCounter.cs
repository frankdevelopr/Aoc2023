namespace Aoc2023Day12;

public class ArrangementsCounter
{
    private readonly string[] _lines;
    private readonly Arranger _arranger;

    public IEnumerable<SpringRow> SpringRows { get; }
    public long Arrangements { get; set; }

    public ArrangementsCounter(string[] lines)
    {
        _lines = lines;
        _arranger = new Arranger();

        SpringRows = Parse();
        Arrangements = Evaluate();
    }

    private long Evaluate()
    {
        var total = 0L;

        foreach (var spring in SpringRows)
        {
            total += _arranger.Evaluate(spring);
        }

        return total;
    }

    private IEnumerable<SpringRow> Parse()
    {
        var rows = new List<SpringRow>(_lines.Length);

        foreach (var line in _lines)
        {
            var parts = line.Split(' ');
            var springs = parts[0];
            var groups = Parse(parts[1]);

            rows.Add(new SpringRow(springs, groups));
        }

        return rows;
    }

    private static List<int> Parse(string numbers)
    {
        var parsed = numbers.Trim().Split(",")
            .Where(t => !string.IsNullOrEmpty(t))
            .Select(i => int.Parse(i.Trim()));

        return parsed.ToList();
    }
}
