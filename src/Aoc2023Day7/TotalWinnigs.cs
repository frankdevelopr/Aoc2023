namespace Aoc2023Day7;

public class TotalWinnigs
{
    public long Winnings { get; }

    public TotalWinnigs(IEnumerable<Hand> hands)
    {
        var sorted = hands.ToList();
        sorted.Sort();

        var result = 0L;
        for (var i = 0; i < sorted.Count; i++)
        {
            result += sorted[i].Bid * (i+1);
        }

        Winnings = result;
    }
}
