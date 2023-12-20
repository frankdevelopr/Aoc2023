namespace Aoc2023Day18;

public class Instruction
{
    public char Direction { get; }
    public int Positions { get; }
    public string Color { get; }

    public Instruction(string line)
    {
        var parts = line.Split(' ').Select(t => t.Trim()).ToArray();

        Direction = parts[0][0];
        Positions = int.Parse(parts[1]);
        Color = parts[2];
    }
}
