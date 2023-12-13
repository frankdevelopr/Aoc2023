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
}
