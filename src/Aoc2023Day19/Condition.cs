
namespace Aoc2023Day19;

public class Condition
{
    private readonly char _targetVar;
    private readonly char _operator;
    private readonly long _value;

    public Condition(char targetVar, char @operator, long value)
    {
        _targetVar = targetVar;
        _operator = @operator;
        _value = value;
    }

    public bool Eval(Part part)
    {
        var value = GetVarValue(_targetVar, part);

        switch (_operator)
        {
            case '<':
                return value < _value;
            case '>':
                return value > _value;
        }

        throw new NotImplementedException();
    }

    private long GetVarValue(char targetVar, Part part)
    {
        switch (targetVar)
        {
            case 'x': return part.X;
            case 'm': return part.M;
            case 'a': return part.A;
            case 's': return part.S;
        }

        throw new NotImplementedException();
    }
}