


namespace Aoc2023Day13;

public class MirrorFinder
{
    public long[] RowValues { get; private set; }
    public long[] ColumnValues { get; private set; }
    public long Result { get; private set; }

    private const int RowMultiplierFactor = 100;

    private string[] _pattern;

    public MirrorFinder(string[] pattern)
    {
        _pattern = pattern;
        RowValues = RowsSummary();
        ColumnValues = ColumnsSummary();
    }

    public long Find()
    {
        var firstVerticalRow = TryFindMirror(ColumnValues);
        var firstHorizontalRow = TryFindMirror(RowValues);

        // Reread the description, we don't want the minimum
        // We WANT JUST THE NEW LINE OF REFLECTION
        // So, previous and next calculation should be done?!
        // in previous case, the value was 5 in next it is 300
        // Note find previous returned 5
        // Note find next returned 300 and 5 (substract?) will always work? :/ fuck!

        // NOPE down
        // WRONG: Problem description is not clear enough for me
        // WRONG: I'm assuming we want the minimal of both (but not both at the same time)
        /*if (firstVerticalRow > 0 && firstHorizontalRow > 0)
        {
            if (firstVerticalRow <= firstHorizontalRow)
            {
                return firstVerticalRow;
            }

            return RowMultiplierFactor * firstHorizontalRow;
        }*/

        Result = firstVerticalRow + (RowMultiplierFactor * firstHorizontalRow);

        return Result;
    }

    public long FindSmudge()
    {
        // When smudge is fixed, the pattern should be updated and values recalculated (!)
        var previous = Find();

        if (!FixSmudge(RowValues, true))
        {
            FixSmudge(ColumnValues, false);
        }

        var next = Find();

        var real = next;
        if (Disjoint(previous, next))
        {
            real = next - previous;
        }

        // TODO: Program and see old and new values and figure out what's wrong
        Console.WriteLine($"Previous value {previous}, next value {next}, real {real}");

        return real;
    }

    public bool Disjoint(long prev, long next)
    {
        if ((prev < 100 && next >= 100 && next % 100 != 0)
            || (next >= 100 & prev >= 100 && next % 100 != 0))
        {
            return true;
        }

        return false;
    }

    private bool FixSmudge(long[] values, bool isRows)
    {
        // let's try all positions :/

        for (var prev = 0; prev < values.Length; ++prev)
        {
            for (var i = 1; i < values.Length; ++i)
            {
                if (IsSmudge(values[prev], values[i], out var pos))
                {
                    // not optimal
                    if (isRows)
                    {
                        EqualRows(prev, i);
                    }
                    else
                    {
                        EqualCols(prev, i);
                    }
                    var pattern = string.Join('\n', _pattern);

                    //_pattern[coord1][coord2] = _pattern[i][coord2];

                    values[prev] = values[i];
                    return true;
                }
            }
        }

        return false;
    }

    private void EqualRows(int prev, int i)
    {
        _pattern[prev] = _pattern[i];
        ColumnValues = ColumnsSummary();
    }

    private void EqualCols(int prev, int next)
    {
        // Dirty Frank - Pearl Jam ©

        for (var i = 0; i < _pattern.Length; ++i)
        {
            var allChars = _pattern[i].ToArray();
            allChars[prev] = allChars[next];
            _pattern[i] = new string(allChars);
        }

        RowValues = RowsSummary();
    }

    /* Only works when smudge is on reflection line (consecutive lines)
    private bool FixSmudge(long[] values)
    {
        var prev = values[0];

        for (var i = 1; i < values.Length; ++i)
        {
            var current = values[i];

            if (IsSmudge(prev, current))
            {
                values[i-1] = values[i];
                return true;
            }

            prev = current;
        }

        return false;
    }*/

    private bool IsSmudge(long prev, long current, out int position)
    {
        var diff = Math.Abs(prev - current);

        var result = Math.Log2(diff);
        position = (int)result;

        var isSmudge = result == position;

        return isSmudge;
    }

    private long[] RowsSummary()
    {
        var summary = new long[_pattern.Length];

        for (var y = 0; y < _pattern.Length; ++y)
        {
            summary[y] = Summarize(_pattern[y]);
        }

        return summary;
    }

    private long[] ColumnsSummary()
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
