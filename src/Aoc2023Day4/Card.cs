namespace Aoc2023Day4;

public class Card
{
    public int Id { get; }

    public IEnumerable<int> WinningNumbers { get; }

    public Card(int id, IEnumerable<int> winningNumbers)
    {
        Id = id;
        WinningNumbers = winningNumbers.ToHashSet();
    }

    public int Score(IEnumerable<int> numbers)
    {
        var wins = WinningNumbers.Intersect(numbers);

        if (!wins.Any())
        {
            return 0;
        }

        return (int)Math.Pow(2, wins.Count() - 1);
    }

}
