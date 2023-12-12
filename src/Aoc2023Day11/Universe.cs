using System.Text;

namespace Aoc2023Day11;

public class Universe
{
    private static char EmptySpace = '.';
    private static char Galaxy = '#';

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

    private string[] DoExpansion(string[] lines, IEnumerable<int> emptyRows, IEnumerable<int> emptyColumns)
    {
        var expanded = new string[lines.Length + emptyRows.Count()];

        var targetRow = 0;

        for (var y = 0; y < lines.Length; ++y)
        {
            var rowCreator = new StringBuilder();

            for (var x = 0; x < lines[0].Length; ++x)
            {
                var c = lines[y][x];

                rowCreator.Append(c);
                if (emptyColumns.Contains(x))
                {
                    rowCreator.Append(EmptySpace);
                }
            }

            expanded[targetRow] = rowCreator.ToString();
            targetRow++;
            
            if (emptyRows.Contains(y))
            {
                expanded[targetRow++] = new string(EmptySpace, rowCreator.Length);
            }
        }

        return expanded;
    }

    private IEnumerable<int> FindEmptyRows(string[] lines)
    {
        var empty = new List<int>();

        for (var i = 0; i < lines.Length; i++)
        {
            if (lines[i].All(c => c == EmptySpace))
            {
                empty.Add(i);
            }
        }

        return empty;
    }

    private IEnumerable<int> FindEmptyColumns(string[] lines)
    {
        var empty = new List<int>();

        for (var x = 0; x < lines[0].Length; ++x)
        {
            var isEmpty = true;

            foreach (var line in lines)
            {
                isEmpty = line[x] == EmptySpace;
                if (!isEmpty)
                {
                    break;
                }
            }

            if (isEmpty)
            {
                empty.Add(x);
            }
        }

        return empty;
    }


}
