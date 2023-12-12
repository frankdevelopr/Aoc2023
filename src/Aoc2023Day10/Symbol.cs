namespace Aoc2023Day10;

public class Symbol
{
    public static string StartSymbol { get; } = "S";

    public char Label { get; }
    public IEnumerable<Direction> Endpoints { get; }

    public Symbol(char label, Direction start, Direction end)
    {
        Label = label;
        Endpoints = new[] { start, end };
    }

    public Direction NextFrom(Direction direction)
    {
        if (!Endpoints.Contains(direction))
        {
            throw new ArgumentException("Unexpected direction");
        }

        return Endpoints.Single(e => e != direction);
    }

    public bool HasConnection(Direction direction)
    {
        return Endpoints.Any(e => e == direction);
    }
}
