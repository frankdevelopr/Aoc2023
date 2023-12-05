namespace Aoc2023Day4;

public class PileOfCards
{
    public IEnumerable<Card> Cards { get; }

    public int Score { get; }

    public PileOfCards(string[] lines)
    {
        var cardReader = new CardReader();

        Cards = cardReader.Read(lines);
        Score = Cards.Sum(x => x.Score);
    }
}
