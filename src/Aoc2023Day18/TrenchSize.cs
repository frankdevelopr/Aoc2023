namespace Aoc2023Day18;

public class TrenchSize
{
    public int Height { get; private set; }
    public int Width { get; private set; }
    public Position InitialPosition { get; private set; }

    private readonly string[] _lines;

    public TrenchSize(string[] lines)
    {
        _lines = lines;
        Evaluate();
    }

    private void Evaluate()
    {
        var current = new Position(0, 0);
        var positions = new List<Position>([current]);

        foreach (var line in _lines)
        {
            var instruction = new Instruction(line);

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

        var upMost = positions.Select(t => t.Y).Min();
        var downMost = positions.Select(t => t.Y).Max();

        var leftMost = positions.Select(t => t.X).Min();
        var rightMost = positions.Select(t => t.X).Max();

        Height = downMost - upMost + 1;
        Width = rightMost - leftMost + 1;

        InitialPosition = new Position(-upMost, -leftMost);
    }
}

public class Position
{
    public int Y { get; }
    public int X { get; }

    public Position(int y, int x)
    {
        Y = y; 
        X = x;
    }
}

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
