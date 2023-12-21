namespace Aoc2023Day19;

public class Workflow
{
    public string Name { get; }
    public IEnumerable<Rule> Rules { get; }

    public Workflow(string name, IEnumerable<Rule> rules)
    {
        Name = name;
        Rules = rules;
    }

    public string Eval(Part part)
    {
        foreach (var rule in Rules)
        {
            var evaluation = rule.Eval(part);

            if (evaluation == null) continue;

            return evaluation;
        }

        throw new Exception("Unexpected data");
    }
}
