
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

    public IEnumerable<Card> PileUp()
    {
        var cards = new List<Card>(Cards);

        for (var i = 0; i < cards.Count; ++i)
        {
            var matchs = cards[i].MatchingNumbers;
            var id = cards[i].Id;

            for (var j = 1; j <= matchs; ++j)
            {
                cards.Add(cards[id-1+j]);
            }
        }

        return cards;
    }
}
