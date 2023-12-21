namespace Aoc2023Day18;

public class Instruction
{
    public char Direction { get; }
    public long Positions { get; }
    public string Color { get; }

    public Instruction(string line)
    {
        var parts = line.Split(' ').Select(t => t.Trim()).ToArray();

        var num = parts[2].Trim(new char[] { '(', ')', '#' });

        var numReal = num.Substring(0, num.Length - 1);
        var direction = num.Substring(num.Length - 1, 1)[0];

        Direction = GetDirection(direction);
        Positions = Convert.ToInt64(numReal, 16);
        Color = parts[0];
    }

    private char GetDirection(char direction)
    {
        // 0 means R, 1 means D, 2 means L, and 3 means U.
        switch (direction)
        {
            case '0':
                return 'R';
            case '1':
                return 'D';
            case '2':
                return 'L';
            case '3':
                return 'U';
        }
        
        throw new NotImplementedException();
    }
}

public class InstructionOld
{
    public char Direction { get; }
    public long Positions { get; }
    public string Color { get; }

    public InstructionOld(string line)
    {
        var parts = line.Split(' ').Select(t => t.Trim()).ToArray();

        Direction = parts[0][0];
        Positions = int.Parse(parts[1]);
        Color = parts[2];
    }
}
