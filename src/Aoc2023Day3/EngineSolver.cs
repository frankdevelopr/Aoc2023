namespace Aoc2023Day3;

public class EngineSolver
{
    private readonly PartNumberFinder _partsFinder;
    private readonly GearFinder _gearsFinder;

    public EngineSolver()
    {
        _partsFinder = new PartNumberFinder();
        _gearsFinder = new GearFinder();
    }

    public long GearsRatio(string[] data)
    {
        var gears = _gearsFinder.Find(data);

        return gears.Sum(g => g.Result());
    }

    public int Solve(string[] lines)
    {
        var numbers = _partsFinder.Find(lines);

        return numbers.Sum(t => t.Value);
    }
}
