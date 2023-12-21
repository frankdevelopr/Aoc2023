namespace Aoc2023Day19;

public class Rule
{
    
    // TODO: IsAccepted(), IsRejected() here or in Workflow
    private readonly string _nextWorkflow;
    private readonly Condition? _condition;

    public Rule(string nextWorkflow)
    {
        _nextWorkflow = nextWorkflow;
    }

    public Rule(Condition condition, string nextWorkflow) : this(nextWorkflow)
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
