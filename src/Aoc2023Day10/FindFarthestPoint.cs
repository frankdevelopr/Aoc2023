namespace Aoc2023Day10;

public class FindFarthestPoint
{
    private readonly string[] _lines;

    public FindFarthestPoint(string[] lines)
    {
        _lines = lines;
    }

    public long Find()
    {
        var map = new Map(_lines);

        return map.Steps / 2;
    }
}
