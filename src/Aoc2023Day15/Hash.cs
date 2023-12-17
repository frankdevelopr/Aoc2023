namespace Aoc2023Day15;

using System.Text;

public class Hash
{
    public long Calculate(string hash)
    {
        var value = 0L;

        var asciiBytes = Encoding.ASCII.GetBytes(hash);

        foreach (var c in asciiBytes)
        {
            value += c;
            value *= 17;
            value %= 256;
        }

        return value;
    }
}
