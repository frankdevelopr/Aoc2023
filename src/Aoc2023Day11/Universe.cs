using System.Text;

namespace Aoc2023Day11;

public class Universe
{
    private const char EmptySpace = '.';
    private const char Galaxy = '#';

    private List<int> _cosmicExpansionRows;
    private List<int> _cosmicExpansionColumns;

    public int ExpansionFactor { get; }
    public string[] Map { get; }
    public IEnumerable<Galaxy> Galaxies { get; }
    public long ShortestPath { get; }

    public Universe(string[] lines, int expansionFactor = 2)
    {
        ExpansionFactor = expansionFactor;
        Map = lines;
        VirtualExpansion();
        Galaxies = FindGalaxies();
        ShortestPath = FindShortestPath();
    }

    private long FindShortestPath()
    {
        var galaxies = Galaxies.ToArray();
        var distance = 0L;

        for (var i = 0; i < galaxies.Length; ++i)
        {
            for (var j = i+1; j < galaxies.Length; ++j)
            {
                distance += CalculateDistance(galaxies[i], galaxies[j]);
            }
        }

        return distance;
    }

    public long DistanceBetween(int galaxyFrom, int galaxyTo)
    {
        var from = Galaxies.Single(g => g.Number == galaxyFrom);
        var to = Galaxies.Single(g => g.Number == galaxyTo);

        return CalculateDistance(from, to);
    }

    private long CalculateDistance(Galaxy from, Galaxy to)
    {
        var fromCoords = from.Coordinates;
        var toCoords = to.Coordinates;

        var distance = fromCoords.DistanceTo(toCoords);
        var expansions = CountExpansions(fromCoords, toCoords);

        // empty space already counted this is why we substract one
        distance += expansions * (ExpansionFactor - 1);

        return distance;
    }

    private long CountExpansions(Coordinates fromCoords, Coordinates toCoords)
    {
        var rows = _cosmicExpansionRows.Count(t => t > Math.Min(fromCoords.Y, toCoords.Y)
                    && t < Math.Max(fromCoords.Y, toCoords.Y));
        var cols = _cosmicExpansionColumns.Count(t => t > Math.Min(fromCoords.X, toCoords.X)
                    && t < Math.Max(fromCoords.X, toCoords.X));

        var cosmicsExpansions = rows + cols;

        return cosmicsExpansions;
    }

    private IEnumerable<Galaxy> FindGalaxies()
    {
        var galaxies = new List<Galaxy>();
        var galaxyNumber = 1;

        for (var y = 0; y < Map.Length; ++y)
        {
            for (var x = 0; x < Map[y].Length; ++x)
            {
                if (IsGalaxy(Map[y][x]))
                {
                    galaxies.Add(new Galaxy(galaxyNumber++, new Coordinates(y,x)));
                }
            }
        }

        return galaxies;
    }

    private static bool IsGalaxy(char point)
    {
        return point == Galaxy;
    }

    private void VirtualExpansion()
    {
        _cosmicExpansionRows = FindEmptyRows();
        _cosmicExpansionColumns = FindEmptyColumns();
    }

    private static string[] DoExpansion(string[] lines, IEnumerable<int> emptyRows, IEnumerable<int> emptyColumns, int expansionFactor)
    {
        var expanded = new string[lines.Length -emptyRows.Count() + (emptyRows.Count() * expansionFactor)];

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
                    rowCreator.Append(EmptySpace, expansionFactor - 1);
                }
            }

            expanded[targetRow] = rowCreator.ToString();
            targetRow++;

            if (emptyRows.Contains(y))
            {
                for (var expandDown = 1; expandDown < expansionFactor; ++expandDown)
                {
                    expanded[targetRow++] = new string(EmptySpace, rowCreator.Length);
                }
            }
        }

        return expanded;
    }

    private List<int> FindEmptyRows()
    {
        var empty = new List<int>();

        for (var i = 0; i < Map.Length; i++)
        {
            if (Map[i].All(IsEmptySpace))
            {
                empty.Add(i);
            }
        }

        return empty;
    }

    private bool IsEmptySpace(char arg)
    {
        return arg == EmptySpace;
    }

    private List<int> FindEmptyColumns()
    {
        var empty = new List<int>();

        for (var x = 0; x < Map[0].Length; ++x)
        {
            var isEmpty = true;

            foreach (var line in Map)
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
