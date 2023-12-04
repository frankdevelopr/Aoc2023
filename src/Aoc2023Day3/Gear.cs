namespace Aoc2023Day3;

public class Gear
{
    private int Column { get; }

    private readonly List<NumberFound> _numbers = new List<NumberFound>();

    public Gear(int column)
    {
        Column = column;
    }

    public Gear LookForAdjacents(IEnumerable<NumberFound> currentLine, IEnumerable<NumberFound> prevLine, IEnumerable<NumberFound> nextLine)
    {
        foreach (var number in currentLine)
        {
            if (IsBeforeOrAfter(number))
            {
                _numbers.Add(number);
            }
        }

        foreach (var number in prevLine)
        {
            if (Overlaps(number))
            {
                _numbers.Add(number);
            }
        }

        foreach (var number in nextLine)
        {
            if (Overlaps(number))
            {
                _numbers.Add(number);
            }
        }

        return this;
    }

    private bool IsBeforeOrAfter(NumberFound num)
    {
        var result = (Column == num.StartPosition -1
            || Column == num.EndPosition +1);

        return result;
    }

    private bool Overlaps(NumberFound num)
    {
        var result = (Column >= num.StartPosition -1
            && Column <= num.EndPosition +1);

        return result;
    }

    public long Result()
    {
        if (_numbers.Count != 2)
        {
            return 0;
        }

        var el1 = _numbers[0];
        var el2 = _numbers[1];

        return el1.Value * el2.Value;
    }

    
}
