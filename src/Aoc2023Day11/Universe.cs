﻿using System.Text;

namespace Aoc2023Day11;

public class Universe
{
    private static readonly char EmptySpace = '.';
    private static readonly char Galaxy = '#';

    public string[] Expanded { get; }
    public IEnumerable<Galaxy> Galaxies { get; }
    public long ShortestPath { get; }

    public Universe(string[] lines)
    {
        Expanded = Expand(lines);
        Galaxies = FindGalaxies();
        ShortestPath = FindShortestPath();
    }

    private long FindShortestPath()
    {
        var galaxies = Galaxies.ToArray();
        var distance = 0L;

        for (var i = 0; i < galaxies.Length; ++i)
        {
            var coords = galaxies[i].Coordinates;

            for (var j = i+1; j < galaxies.Length; ++j)
            {
                distance += coords.DistanceTo(galaxies[j].Coordinates);
            }
        }

        return distance;
    }

    private IEnumerable<Galaxy> FindGalaxies()
    {
        var galaxies = new List<Galaxy>();
        var galaxyNumber = 1;

        for (var y = 0; y < Expanded.Length; ++y)
        {
            for (var x = 0; x < Expanded[y].Length; ++x)
            {
                if (IsGalaxy(Expanded[y][x]))
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

    private string[] Expand(string[] lines)
    {
        var emptyRows = FindEmptyRows(lines);
        var emptyColumns = FindEmptyColumns(lines);

        var expanded = DoExpansion(lines, emptyRows, emptyColumns);

        return expanded;
    }

    private static string[] DoExpansion(string[] lines, IEnumerable<int> emptyRows, IEnumerable<int> emptyColumns)
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
            if (lines[i].All(IsEmptySpace))
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
