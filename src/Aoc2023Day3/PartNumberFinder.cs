



namespace Aoc2023Day3;

public class PartNumberFinder
{
    private readonly NumberFinder _numberFinder;
    private readonly Symbol _symbol;

    public PartNumberFinder()
    {
        _numberFinder = new NumberFinder();
        _symbol = new Symbol();
    }

    public IEnumerable<NumberFound> Find(string[] lines)
    {
        var found = new List<NumberFound>();

        for (var i = 0; i < lines.Length; ++i)
        { 
            var prev = i > 0 ? lines[i-1] : string.Empty;
            var line = lines[i];
            var next = i < lines.Length-1 ? lines[i+1] : string.Empty;

            var numbers = _numberFinder.Find(line).ToArray();

            if (!numbers.Any()) 
                continue;

            foreach (var number in numbers)
            {
                if (HasSymbolNear(number, line, prev, next))
                {
                    found.Add(number);
                }
            }
        }

        return found;
    }

    public IEnumerable<NumberFound> Find(string line)
    {
        var numbers = _numberFinder.Find(line).ToArray();

        if (!numbers.Any())
        {
            return Enumerable.Empty<NumberFound>();
        }

        var parts = numbers.Where(number => HasSymbol(line, number));

        return parts;
    }

    private bool HasSymbol(string partNumber, NumberFound numberFound)
    {
        var start = numberFound.StartPosition;
        var end = numberFound.EndPosition;

        var result = IsSymbol(partNumber, start-1) || IsSymbol(partNumber, end+1);

        return result;
    }

    private bool HasSymbolNear(NumberFound number, string line, string prev, string next)
    {
        var start = number.StartPosition - 1;
        var end = number.EndPosition + 1;

        var result = IsSymbol(line, start) || IsSymbol(line, end);

        result = result || HasSymbolIn(prev, start, end);
        result = result || HasSymbolIn(next, start, end);

        return result;

    }

    private bool HasSymbolIn(string otherLine, int start, int end)
    {
        var fixStart = Math.Max(start, 0);
        var fixEnd = Math.Min(end, otherLine.Length-1);

        if (string.IsNullOrEmpty(otherLine)) 
        {
            return false;
        }

        var len = fixEnd - fixStart + 1;
        var substr = otherLine.Substring(fixStart, len);

        return _symbol.ContainsSymbol(substr);
    }

    private bool IsSymbol(string partNumber, int pos)
    {
        if (pos < 0 || pos >= partNumber.Length)
        {
            return false;
        }

        return _symbol.IsSymbol(partNumber[pos]);
    }
}
