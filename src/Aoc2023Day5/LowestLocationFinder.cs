
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
    }

    public long FindLowestLocation()
    {
        return FindLowestLocationInternal();
    }

    public long ExpectedExecutions()
    {
        var executions = 0L;
        var seeds = Map.Seeds.ToArray();

        for (long i = 0; i < seeds.Length; i+=2)
        {
            var ini = seeds[i];
            var end = seeds[i+1] + ini;

            executions += end - ini - 1;
        }

        return executions;
    }

    public long FindLowestParallel()
    {
        var seeds = Map.Seeds.ToArray();
        var lowest = long.MaxValue;

        for (long i = 0; i < seeds.Length; i+=2)
        {
            var ini = seeds[i];
            var end = seeds[i+1] + ini;

            // Parallel for (! don't use shared vars)
            // https://learn.microsoft.com/en-us/previous-versions/msp-n-p/ff963552(v=pandp.10)
            // see also https://learn.microsoft.com/en-us/previous-versions/msp-n-p/ff963547(v=pandp.10)

            Parallel.For(ini, end, j =>
            {
                var value = ApplyMap(j);
                lowest = Math.Min(lowest, value);
            });
        }

        return lowest;
    }

    // Right solution
    public long FindLowestLocationRange()
    {
        var executions = 0L;

        var seeds = Map.Seeds.ToArray();
        var lowest = long.MaxValue;

        for (long i = 0; i < seeds.Length; i+=2)
        {
            var ini = seeds[i];
            var end = seeds[i+1] + ini;

            for (var j = ini; j < end; j++)
            {
                var value = ApplyMap(j);
                lowest = Math.Min(lowest, value);

                executions++;
                if (executions % 20000000 == 0)
                {
                    Console.WriteLine($"executed: {executions} times already");
                }
            }
        }

        return lowest;
    }

    private long FindLowestLocationInternal()
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
