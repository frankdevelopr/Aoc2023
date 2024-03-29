﻿namespace Aoc2023Day19;

public class Rule
{
    private readonly string _nextWorkflow;
    private readonly Condition? _condition;

    public Rule(string nextWorkflow)
    {
        _nextWorkflow = nextWorkflow;
    }

    public Rule(string nextWorkflow, Condition condition) : this(nextWorkflow)
    {
        _condition = condition;
    }

    public string? Eval(Part part)
    {
        if (_condition == null)
        {
            return _nextWorkflow;
        }

        var result = _condition.Eval(part);

        return result ? _nextWorkflow : null;
    }
}
