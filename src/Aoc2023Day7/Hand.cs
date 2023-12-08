namespace Aoc2023Day7;

public class Hand
{
    public string Cards { get; }
    public int Bid { get; }

    public Hand(string cards, int bid = 0)
    {
        if (cards.Length != 5)
        {
            throw new ArgumentException(nameof(cards));
        }

        Cards = cards;
        Bid = bid;
    }
}
