
namespace Aoc2023Day3;

public class Symbol
{
    public const string SymbolList = "+-/\\$*";

    public bool IsSymbol(char symbol)
    {
        return SymbolList.Contains(symbol);
    }
}
