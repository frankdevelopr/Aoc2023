namespace Aoc2023Day7;

public class Hand
{
    public string Cards { get; }

    public Hand(string cards)
    {
        if (cards.Length != 5)
        {
            throw new ArgumentException(nameof(cards));
        }

        Cards = cards;
    }

}
