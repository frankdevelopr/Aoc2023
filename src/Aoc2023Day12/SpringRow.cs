using System.Text;
using System.Text.RegularExpressions;

namespace Aoc2023Day12;

public class SpringRow
{
    private const char Operational = '.';
    private const char Damage = '#';
    private const char Unknown = '?';

    public string Spring { get; }
    public IList<int> Groups { get; }

    public SpringRow(string spring, IEnumerable<int> groups)
    {
        Spring = spring;
        Groups = groups.ToList();
    }

    public static bool IsSolution(string spring, IList<int> groups)
    {
        const string OptionalSeparator = "\\.*";
        const string Separator = "\\.+";

        var regexTxt = new StringBuilder();
        regexTxt.Append($"^{OptionalSeparator}");

        for (var i = 0; i < groups.Count; ++i)
        {
            regexTxt.Append("#{").Append(groups[i]).Append('}');
            if (i  < groups.Count - 1)
            {
                regexTxt.Append(Separator);
            }
        }
        regexTxt.Append(OptionalSeparator);
        regexTxt.Append('$');

        var regex = new Regex(regexTxt.ToString());

        var isSolution = regex.IsMatch(spring);

        return isSolution;
    }
}
