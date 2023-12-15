using System.Text;

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

    public SpringRow Unfold(int factor = 5)
    {
        var b = new StringBuilder(Spring);
        b.Append('?');
        b.Append(Spring);
        b.Append('?');
        b.Append(Spring);
        b.Append('?');
        b.Append(Spring);
        b.Append('?');
        b.Append(Spring);


        var groups = new List<int>(Groups);
        groups.AddRange(Groups);
        groups.AddRange(Groups);
        groups.AddRange(Groups);
        groups.AddRange(Groups);

        return new SpringRow(b.ToString(), groups);
    }
}
