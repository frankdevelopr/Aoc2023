namespace Aoc2023Day18;

public class TrenchSize
{
    public int Height { get; private set; }
    public int Width { get; private set; }
    public Position InitialPosition { get; private set; }
    public List<Instruction> Instructions { get; }

    private readonly string[] _lines;

    public TrenchSize(string[] lines)
    {
        _lines = lines;
        Instructions = new List<Instruction>(lines.Length);
        Evaluate();
    }

    private void Evaluate()
    {
        var current = new Position(0, 0);
        var positions = new List<Position>([current]);

        foreach (var line in _lines)
        {
            var instruction = new Instruction(line);
            Instructions.Add(instruction);

            switch (instruction.Direction)
            {
                case 'U':
                    current = new Position(current.Y-instruction.Positions, current.X);
                    break;
                case 'D':
                    current = new Position(current.Y+instruction.Positions, current.X);
                    break;
                case 'L':
                    current = new Position(current.Y, current.X-instruction.Positions);
                    break;
                case 'R':
                    current = new Position(current.Y, current.X+instruction.Positions);
                    break;
            }

            positions.Add(current);
        }

        var upMost = positions.Min(t => t.Y);
        var downMost = positions.Max(t => t.Y);

        var leftMost = positions.Min(t => t.X);
        var rightMost = positions.Max(t => t.X);

        Height = downMost - upMost + 1;
        Width = rightMost - leftMost + 1;

        InitialPosition = new Position(-upMost, -leftMost);
    }
}
