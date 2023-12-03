namespace Aoc2023Day3;

public class Symbol
{
    public const string SymbolList = "+-/\\$*";

    public bool ContainsSymbol(string str)
    {
        foreach (var substr in str)
        {
            if (IsSymbol(substr))
            {
                return true;
            }
        }

        return false;
    }

    public bool IsSymbol(char symbol)
    {
        return SymbolList.Contains(symbol);
    }
}
