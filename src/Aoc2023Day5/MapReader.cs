
namespace Aoc2023Day5;

public class MapReader
{
    // Can be made more generic with List (order is important) from section to 

    public List<string> Lines { get; }
    public IEnumerable<long> Seeds { get; }
    public RuleSet ToSoil { get; }
    public RuleSet ToFertilizer { get; }
    public RuleSet ToWater { get; }
    public RuleSet ToLight { get; }
    public RuleSet ToTemp { get; }
    public RuleSet ToHumidity { get; }
    public RuleSet ToLocation { get; }

    // Dirty reader

    public MapReader(IEnumerable<string> lines)
    {
        Lines = lines.ToList();

        Seeds = ReadSeeds();
        ToSoil = ReadSection("seed-to-soil");
        ToFertilizer = ReadSection("soil-to-fertilizer");
        ToWater = ReadSection("fertilizer-to-water");
        ToLight = ReadSection("water-to-light");
        ToTemp = ReadSection("light-to-temperature");
        ToHumidity = ReadSection("temperature-to-humidity");
        ToLocation = ReadSection("humidity-to-location");
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
