namespace Aoc2023Day11;

public class Universe
{
    public string[] Expanded { get; }

    public Universe(string[] lines)
    {
        Expanded = Expand(lines);
    }

    private string[] Expand(string[] lines)
    {
        var emptyRows = FindEmptyRows(lines);
        var emptyColumns = FindEmptyColumns(lines);

        var expanded = DoExpansion(lines, emptyRows, emptyColumns);

        return expanded;
    }

    private IEnumerable<int> FindEmptyRows(string[] lines)
    {
        throw new NotImplementedException();
    }

    private IEnumerable<int> FindEmptyColumns(string[] lines)
    {
        throw new NotImplementedException();
    }

    private string[] DoExpansion(string[] lines, IEnumerable<int> emptyRows, IEnumerable<int> emptyColumns)
    {
        throw new NotImplementedException();
    }
}
