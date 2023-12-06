namespace Aoc2023Day5;

public class MapReader
{
    public List<string> Lines { get; }

    public Map Map { get; } = new Map();

    // Dirty reader

    public MapReader(IEnumerable<string> lines)
    {
        Lines = lines.ToList();

        Map.Seeds = ReadSeeds();
        Map.ToSoil = ReadSection("seed-to-soil");
        Map.ToFertilizer = ReadSection("soil-to-fertilizer");
        Map.ToWater = ReadSection("fertilizer-to-water");
        Map.ToLight = ReadSection("water-to-light");
        Map.ToTemp = ReadSection("light-to-temperature");
        Map.ToHumidity = ReadSection("temperature-to-humidity");
        Map.ToLocation = ReadSection("humidity-to-location");
    }

    private IEnumerable<long> ReadSeeds()
    {
        var seeds = Lines[0].Split(':')[1].Trim();

        var parsed = StringToLongList(seeds);

        return parsed;
    }

    private RuleSet ReadSection(string section)
    {
        var ruleset = new RuleSet(section);

        var linePosition = FindStartPosition(section);
        
        for (var i = linePosition; i < Lines.Count; ++i)
        {
            if (string.IsNullOrWhiteSpace(Lines[i]))
            {
                break;
            }

            var nums = StringToLongList(Lines[i]);

            if (nums.Count != 3)
            {
                continue;
            }

            ruleset.Add(new Rule(nums[0], nums[1], nums[2]));
        }

        return ruleset;
    }

    private int FindStartPosition(string section)
    {
        for (var i = 1; i < Lines.Count; i++)
        {
            if (Lines[i].StartsWith(section, StringComparison.InvariantCultureIgnoreCase))
            {
                return i+1;
            }
        }

        return -1;
    }

    private List<long> StringToLongList(string stringWithNumbers)
    {
        var parsed = stringWithNumbers.Split(" ")
            .Where(t => !string.IsNullOrEmpty(t))
            .Select(i => long.Parse(i.Trim())).ToList();

        return parsed;
    }
}
