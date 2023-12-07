namespace Aoc2023Day7;

public static class HandClassifier
{
    public static HandType Classify(Hand hand)
    {
        var dict = CountCards(hand);

        if (dict.Values.Any(t => t == 5))
        {
            return HandType.FiveKind;
        }

        if (dict.Values.Any(t => t == 4))
        {
            return HandType.FourKind;
        }

        if (dict.Values.Any(t => t == 3) && dict.Values.Any(t => t == 2))
        {
            return HandType.FullHouse;
        }

        if (dict.Values.Any(t => t == 3))
        {
            return HandType.ThreeKind;
        }

        if (dict.Values.Count(t => t == 2) == 2)
        {
            return HandType.TwoPair;
        }

        if (dict.Values.Any(t => t == 2))
        {
            return HandType.OnePair;
        }

        return HandType.HighCard;
    }

    private static Dictionary<char, int> CountCards(Hand hand)
    {
        var dict = new Dictionary<char, int>();

        foreach (var c in hand.Cards)
        {
            if (dict.ContainsKey(c))
            {
                dict[c]++;
            }
            else
            {
                dict[c] = 1;
            }
        }

        return dict;
    }
}
