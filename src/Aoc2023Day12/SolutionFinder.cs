using System.Text;
using System.Text.RegularExpressions;

namespace Aoc2023Day12;

public class SolutionFinder
{
    public IList<int> Groups { get; }

    private readonly Regex _regex;

    public SolutionFinder(IList<int> groups)
    {
        Groups = groups;
        _regex = RegexCreator();
    }

    public bool IsSolution(string spring)
    {
        return _regex.IsMatch(spring);
    }

    public int CountSolutions(IEnumerable<string> allPossibleSprings)
    {
        var result = allPossibleSprings.Count(IsSolution);

        return result;
    }

    private Regex RegexCreator()
    {
        const string OptionalSeparator = "\\.*";
        const string Separator = "\\.+";

        var regexTxt = new StringBuilder();
        regexTxt.Append($"^{OptionalSeparator}");

        for (var i = 0; i < Groups.Count; ++i)
        {
            regexTxt.Append("#{").Append(Groups[i]).Append('}');
            if (i  < Groups.Count - 1)
            {
                regexTxt.Append(Separator);
            }
        }
        regexTxt.Append(OptionalSeparator);
        regexTxt.Append('$');

        var regex = new Regex(regexTxt.ToString());

        return regex;
    }
}
