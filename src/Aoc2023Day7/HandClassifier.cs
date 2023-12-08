namespace Aoc2023Day7;

public class HandClassifier : IHandClassifier
{
    public HandType Classify(Hand hand)
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

    public int CardValue(char labelValue)
    {
        if (ValueMapper.TryGetValue(labelValue, out var value))
        {
            return value;
        }

        return 0;
    }

    private Dictionary<char, int> CountCards(Hand hand)
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

    private static readonly Dictionary<char, int> ValueMapper = new()
    {
        ['A'] = 14,
        ['K'] = 13,
        ['Q'] = 12,
        ['J'] = 11,
        ['T'] = 10,
        ['9'] = 9,
        ['8'] = 8,
        ['7'] = 7,
        ['6'] = 6,
        ['5'] = 5,
        ['4'] = 4,
        ['3'] = 3,
        ['2'] = 2
        //['J'] = 1
    };
}
