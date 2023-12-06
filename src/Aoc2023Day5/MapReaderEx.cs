namespace Aoc2023Day5;

// First try for attempt 2, didn't realize it would exhaust all memory :/
public class MapReaderEx : MapReader
{
    public MapReaderEx(IEnumerable<string> lines) : base(lines)
    {
        Map.Seeds = ConvertSeedsToRange();
    }

    private IEnumerable<long> ConvertSeedsToRange()
    {
        var newSeeds = new List<long>();
        var oldSeeds = Map.Seeds.ToList();

        for (var i = 0; i < oldSeeds.Count; i+=2)
        {
            var ini = oldSeeds[i];
            var end = oldSeeds[i+1] + ini;

            for (var j = ini; j < end; j++)
            {
                newSeeds.Add(j);
            }
        }

        return newSeeds;
    }
}
