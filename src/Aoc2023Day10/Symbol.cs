
namespace Aoc2023Day10;

public class Symbol
{
    public string Name { get; set; }
    public Direction Starts { get; set; }
    public Direction Ends { get; set; }

    public static string StartSymbol { get; } = "S";
}
