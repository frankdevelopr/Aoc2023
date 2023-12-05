namespace Aoc2023Day5;

public class Rule
{
    private readonly int _destinationRange;
    private readonly int _sourceRange;
    private readonly int _sourceRangeEnd;

    public Rule(int destinationRange, int sourceRange, int rangeLength)
	{
		_destinationRange = destinationRange;
		_sourceRange = sourceRange;
        _sourceRangeEnd = sourceRange + rangeLength;
	}

	public int Apply(int input)
    {
        if (!(input >= _sourceRange && input < _sourceRangeEnd))
        {
            return input;
        }

        var diff = input - _sourceRange;
        var output = _destinationRange + diff;

        return output;
    }
}
