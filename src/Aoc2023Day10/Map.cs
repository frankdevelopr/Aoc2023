namespace Aoc2023Day10;

public class Map
{
    public Position StartPosition { get; }

    private readonly string[] _lines;

    public Map(string[] lines)
    {
        _lines = lines;
        StartPosition = FindSymbol(Symbol.StartSymbol);
    }

    private Position FindSymbol(string startSymbol)
    {
        for (var y = 0; y < _lines.Length; ++y)
        {
            var line = _lines[y];

            for (var x = 0; x < line.Length; ++x)
            {
                if (line[x].ToString() == startSymbol)
                    return new Position(x, y);
            }
        }

        return new Position(-1, -1);
    }
}
