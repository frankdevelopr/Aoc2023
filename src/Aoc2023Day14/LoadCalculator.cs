namespace Aoc2023Day14;

public class LoadCalculator
{
    private readonly string[] _lines;

    public LoadCalculator(string[] lines)
    {
        _lines = lines;
    }

    public long Calculate()
    {
        var sum = 0L;
        var length = _lines.Length;

        for (var i = 0; i < length; ++i)
        {
            var multiplier = length - i;

            var roundedRocks = _lines[i].Count(t => t == 'O') * multiplier;
            sum += roundedRocks;
        }

        return sum;
    }
}