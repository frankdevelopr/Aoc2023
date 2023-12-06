namespace Aoc2023Day5;

public class ChainMapper
{
    private readonly IEnumerable<RuleSet> _rulesets;

    public ChainMapper(IEnumerable<RuleSet> rulesets)
    {
        _rulesets = rulesets;
    }

    public long Apply(long input)
    {
        var output = input;

        foreach (var ruleset in _rulesets)
        {
            output = ruleset.Apply(output);
        }

        return output;
    }
}
