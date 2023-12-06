namespace Aoc2023Day5;

public class RuleSet
{
    public List<Rule> Rules { get; } = [];

    public string Name { get; }

    public RuleSet(IEnumerable<Rule> rules, string name = "") : this(name)
    {
        Rules = rules.ToList();
    }

    public RuleSet(string name)
    {
        Name = name;
    }

    public long Apply(long input)
    {
        foreach (var rule in Rules)
        {
            if (rule.TryApply(input, out var output))
            {
                return output;
            }
        }

        return input;
    }

    public RuleSet Add(Rule rule)
    {
        Rules.Add(rule);

        return this;
    }
}
