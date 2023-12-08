namespace Aoc2023Day7;

public class HandReader
{
    public IEnumerable<Hand> Hands { get; }

    public HandReader(string[] lines)
    {
        var hands = new List<Hand>();

        foreach (var line in lines)
        {
            var parts = line.Split(' ');

            hands.Add(new Hand(parts[0].Trim(), int.Parse(parts[1].Trim())));
        }

        Hands = hands;
    }
}
