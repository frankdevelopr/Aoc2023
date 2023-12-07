namespace Aoc2023Day7;

public class Hand : IComparable<Hand>
{
    public string Cards { get; }
    public HandType HandType { get; }
    public int Bid { get; }

    public Hand(string cards, int bid = 0)
    {
        if (cards.Length != 5)
        {
            throw new ArgumentException(nameof(cards));
        }

        Cards = cards;
        HandType = HandClassifier.Classify(this);
        Bid = bid;
    }

    public int CompareTo(Hand? other)
    {
        if (other is null)
        {
            return 1;
        }

        if (HandType != other.HandType)
        {
            return HandType - other.HandType;
        }

        for (var i = 0; i < Cards.Length; ++i)
        {
            if (Cards[i] == other.Cards[i]) continue;

            return Card.GetValue(Cards[i]) - Card.GetValue(other.Cards[i]);
        }

        return 0;
    }
}
