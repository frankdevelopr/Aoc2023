
namespace Aoc2023Day4;

public class Card
{
    public int Id { get; }

    public HashSet<int> WinningNumbers { get; }
    public HashSet<int> OwnNumbers { get; }
    public int Score { get; }

    public Card(int id, IEnumerable<int> winningNumbers, IEnumerable<int> ownNumbers)
    {
        Id = id;
        WinningNumbers = winningNumbers.ToHashSet();
        OwnNumbers = ownNumbers.ToHashSet();
        Score = CalculateScore();
    }

    public int CalculateScore()
    {
        var wins = WinningNumbers.Intersect(OwnNumbers);

        if (!wins.Any())
        {
            return 0;
        }

        return (int)Math.Pow(2, wins.Count() - 1);
    }
}
