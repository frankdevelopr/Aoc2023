namespace Aoc2023Day10;

public class SymbolTable
{
    private readonly Dictionary<char, Symbol> _symbols;

    public SymbolTable()
    {
        _symbols = new Dictionary<char, Symbol>
        {
            ['|'] = new Symbol('|', Direction.North, Direction.South),
            ['-'] = new Symbol('-', Direction.East, Direction.West),
            ['L'] = new Symbol('L', Direction.North, Direction.East),
            ['J'] = new Symbol('J', Direction.North, Direction.West),
            ['7'] = new Symbol('7', Direction.South, Direction.West),
            ['F'] = new Symbol('F', Direction.South, Direction.East)
        };

        //_symbols.Add(new Symbol('.');
        //_symbols.Add(new Symbol('S');
    }

    public Symbol? Get(char label)
    {
        if (_symbols.TryGetValue(label, out var symbol))
        {
            return symbol;
        }

        return null;
    }
}
