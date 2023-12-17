using System.Diagnostics;

namespace Aoc2023Day15;

public class HashSumer
{
    public long Sum(string line)
    {
        var parts = line.Split(',').Select(s => s.Trim());

        var hash = new Hash();
        var total = 0L;

        Parallel.ForEach(parts, part =>
        {
            var value = hash.Calculate(part);
            Debug.WriteLine($"{part} = {value}");

            Interlocked.Add(ref total, value);
        });

        return total;
    }
}