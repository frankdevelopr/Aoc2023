namespace Aoc2023Day5;

public class Rule
{
    private readonly long _destinationRange;
    private readonly long _sourceRange;
    private readonly long _sourceRangeEnd;

    public Rule(long destinationRange, long sourceRange, long rangeLength)
	{
		_destinationRange = destinationRange;
		_sourceRange = sourceRange;
        _sourceRangeEnd = sourceRange + rangeLength;
	}

	public bool TryApply(long input, out long value)
    {
        if (!(input >= _sourceRange && input < _sourceRangeEnd))
        {
            value = input;
            return false;
        }

        var diff = input - _sourceRange;
        var output = _destinationRange + diff;
        value = output;

        return true;
    }
}
