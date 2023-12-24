
using System.Diagnostics;

namespace Aoc2023Day19;

public class AcceptedPartsSumer
{
    private readonly int _partsStart;
    private readonly IEnumerable<Part> _parts;
    private readonly WorkflowSystem _workflowSystem;
    private readonly string[] _data;

    public AcceptedPartsSumer(string[] data)
    {
        _data = data;
        _partsStart = FindPartsStart();

        _parts = ParseParts();

        _workflowSystem = new WorkflowSystem(ParseWorkflows());
    }

    public long Sum()
    {
        var sum = 0L;

        foreach (var part in _parts)
        {
            if (_workflowSystem.Eval(part))
            {
                sum += part.Rating;
            }
        }

        return sum;
    }

    public long AcceptedCombinations()
    {
        var watch = new Stopwatch();
        watch.Start();

        var processed = 0L;
        var accepted = 0L;

        for (var x = 1; x <= 4000; ++x)
        {
            for (var m = 1; m <= 4000; ++m)
            {
                for (var a = 1; a <= 4000; ++a)
                {
                    for (var s = 1; s <= 4000; ++s)
                    {
                        processed++;

                        if (processed % 1_000_000_000 == 0)
                        {
                            Console.WriteLine($"Processed {processed} took {watch.Elapsed} so far");
                        }

                        if (_workflowSystem.Eval(new Part(x, m, a, s)))
                        {
                            accepted++;
                        }
                    }
                }
            }
        }

        return accepted;
    }

    private IEnumerable<Workflow> ParseWorkflows()
    {
        var workflows = new List<Workflow>();

        for (var i = 0; i < _partsStart; ++i)
        {
            workflows.Add(ParseWorkflow(_data[i]));
        }

        return workflows;
    }

    private Workflow ParseWorkflow(string line)
    {
        //px{a<2006:qkq,m>2090:A,rfg}
        var tokens = line.Split('{');
        var name = tokens[0];

        var rulesTxt = tokens[1].Trim('}').Split(',');

        var rules = new List<Rule>();
        foreach (var ruleTxt in rulesTxt)
        {
            rules.Add(ParseRule(ruleTxt));
        }

        return new Workflow(name, rules);
    }

    private Rule ParseRule(string ruleTxt)
    {
        // a<2006:qkq
        var tokens = ruleTxt.Split(':');

        if (tokens.Length == 1)
        {
            return new Rule(tokens[0]);
        }

        var nextWorkflow = tokens[1];

        var variable = tokens[0][0];
        var @operator = tokens[0][1];
        var num = tokens[0][2..];
        var condition = new Condition(variable, @operator, long.Parse(num));

        return new Rule(nextWorkflow, condition);
    }

    private IEnumerable<Part> ParseParts()
    {
        var parts = new List<Part>();

        for (var i = _partsStart+1; i < _data.Length; ++i)
        {
            parts.Add(ParsePart(_data[i]));
        }

        return parts;
    }

    private Part ParsePart(string line)
    {
        // {x=787,m=2655,a=1222,s=2876}
        var tokens = line.Trim(['{', '}']).Split(',');

        var values = GetValues(tokens);

        return new Part(values[0], values[1], values[2], values[3]);
    }

    private List<long> GetValues(string[] tokens)
    {
        var values = new List<long>();
        foreach (var token in tokens)
        {
            var value = long.Parse(token.Substring(token.IndexOf('=')+1));
            values.Add(value);
        }

        return values;
    }

    private int FindPartsStart()
    {
        for (var i = 0; i < _data.Length; i++)
        {
            if (string.IsNullOrEmpty(_data[i]))
                return i;
        }

        throw new NotImplementedException();
    }
}
