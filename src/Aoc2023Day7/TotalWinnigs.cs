namespace Aoc2023Day7;

public class TotalWinnigs
{
    public long Winnings { get; }

    public TotalWinnigs(IEnumerable<Hand> hands, IHandClassifier classifier)
    {
        var sorted = hands.ToList();
        var comparer = new HandComparer(classifier);
        sorted.Sort(comparer);

        var result = 0L;
        for (var i = 0; i < sorted.Count; i++)
        {
            result += sorted[i].Bid * (i+1);
        }

        Winnings = result;
    }
}
