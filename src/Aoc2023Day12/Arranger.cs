using System.Text;

namespace Aoc2023Day12;

public class Arranger
{
    private readonly SpringsGenerator _generator;

    public Arranger()
    {
        _generator = new SpringsGenerator();
    }

    public long Evaluate(SpringRow spring)
    {
        return Evaluate(spring.Spring, spring.Groups);
    }

    public int Evaluate(string springs, IList<int> groups)
    {
        var unknowns = springs.Count(t => t == '?');

        var replacements = _generator.Combinations(unknowns);
        var good = 0;

        foreach (var replace in replacements)
        {
            var replaced = Replace(springs, replace);

            good += SpringRow.IsSolution(replaced, groups) ? 1 : 0;
        }

        return good;
    }

    private string Replace(string springs, string replace)
    {
        var replaced = new StringBuilder();
        var current = 0;

        for (var i = 0;  i < springs.Length; i++)
        {
            if (springs[i] == '?')
            {
                replaced.Append(replace[current++]);
            }
            else
            {
                replaced.Append(springs[i]);
            }
        }

        return replaced.ToString();
    }
}
