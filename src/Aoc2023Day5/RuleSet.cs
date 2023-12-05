
namespace Aoc2023Day5;

public class RuleSet
{
    private readonly IEnumerable<Rule> _rules;

    public RuleSet(IEnumerable<Rule> rules)
    {
        _rules = rules;
    }

    public int Apply(int input)
    {
        foreach (var rule in _rules)
        {
            if (rule.TryApply(input, out var output))
            {
                return output;
            }
        }

        return input;
    }
}
