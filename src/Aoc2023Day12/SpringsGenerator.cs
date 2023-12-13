using System.Text;

namespace Aoc2023Day12;

public class SpringsGenerator
{
    public IEnumerable<string> Combinations(int digits)
    {
        var limit = (int) Math.Pow(2, digits);

        for (var i = 0; i < limit; i++)
        {
            var combination = i.ToString($"B{digits}");
            var springs = CombinationToSpring(combination);

            yield return springs;
        }
    }

    private string CombinationToSpring(string combination)
    {
        const char Operational = '.';
        const char Damage = '#';

        var b = new StringBuilder(combination);
        b.Replace('0', Operational).Replace('1', Damage);

        return b.ToString();
    }
}
