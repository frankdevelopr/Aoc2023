
namespace Aoc2023Day5;

public class LowestLocationFinder
{
    public Map Map { get; }
    public IEnumerable<RuleSet> AllRulesSets { get; }
    public long LowestLocation { get; }

    public LowestLocationFinder(Map map)
    {
        Map = map;
        AllRulesSets = [map.ToSoil, map.ToFertilizer, map.ToWater, map.ToLight, map.ToTemp, map.ToHumidity, map.ToLocation];

        LowestLocation = FindLowestLocation();
    }

    private long FindLowestLocation()
    {
        var lowest = long.MaxValue;

        foreach (var seed in Map.Seeds)
        {
            var value = ApplyMap(seed);
            lowest = Math.Min(lowest, value);
        }

        return lowest;
    }

    private long ApplyMap(long seed)
    {
        var value = seed;

        foreach (var ruleset in AllRulesSets)
        {
            value = ruleset.Apply(value);
        }

        return value;
    }
}
