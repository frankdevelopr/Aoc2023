namespace Aoc2023Day13;

public class MirrorFinder
{
    private readonly string[] _pattern;

    public long[] RowValues { get; }
    public long[] ColumnValues { get; }
    public long Result { get; private set; }

    public MirrorFinder(string[] pattern)
    {
        _pattern = pattern;
        RowValues = RowsSummary();
        ColumnValues = ColumnsSummary();
    }

    public long[] RowsSummary()
    {
        var summary = new long[_pattern.Length];

        for (var y = 0; y < _pattern.Length; ++y)
        {
            summary[y] = Summarize(_pattern[y]);
        }

        return summary;
    }

    public long[] ColumnsSummary()
    {
        var row = _pattern[0];
        var summary = new long[row.Length];

        for (var x = 0; x < row.Length; ++x)
        {
            var line = string.Join(string.Empty, _pattern.Select(r => r[x]));
            summary[x] = Summarize(line);
        }

        return summary;
    }

    private static long Summarize(string line)
    {
        var value = 1L;
        var total = 0L;

        for (var x = 0; x < line.Length; ++x)
        {
            total += line[x] == '#' ? value : 0;
            value *= 2;
        }

        return total;
    }

    public long Find()
    {
        const int RowMultiplierFactor = 100;

        var firstVerticalRow = TryFindMirror(ColumnValues);
        var firstHorizontalRow = TryFindMirror(RowValues);

        Result = firstVerticalRow + (RowMultiplierFactor * firstHorizontalRow);

        return Result;
    }

    private static int TryFindMirror(long[] values)
    {
        var prev = values[0];

        for (var xy = 1; xy < values.Length; ++xy)
        {
            var current = values[xy];

            if (current == prev && IsSymmetric(xy, values))
            {
                return xy;
            }

            prev = current;
        }

        return 0;
    }

    private static bool IsSymmetric(int x, long[] values)
    {
        var left = x-2;
        var right = x+1;

        while (left >= 0 && right < values.Length)
        {
            if (values[left] != values[right])
            {
                return false;
            }

            left--;
            right++;
        }

        return true;
    }
}
