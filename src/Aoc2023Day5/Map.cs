namespace Aoc2023Day5;

public class Map
{
    public IEnumerable<long> Seeds { get; set; } = [];
    public RuleSet ToSoil { get; set; } = new RuleSet("empty");
    public RuleSet ToFertilizer { get; set; } = new RuleSet("empty");
    public RuleSet ToWater { get; set; } = new RuleSet("empty");
    public RuleSet ToLight { get; set; } = new RuleSet("empty");
    public RuleSet ToTemp { get; set; } = new RuleSet("empty");
    public RuleSet ToHumidity { get; set; } = new RuleSet("empty");
    public RuleSet ToLocation { get; set; } = new RuleSet("empty");
}