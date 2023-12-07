namespace Aoc2023Day7;

public class HandWithJokerClassifier : IHandClassifier
{
    public HandType Classify(Hand hand)
    {
        var dict = CountCards(hand, out var jokers);

        if (dict.Values.Any(t => t + jokers == 5) || jokers == 5)
        {
            return HandType.FiveKind;
        }

        if (dict.Values.Any(t => t+jokers == 4))
        {
            return HandType.FourKind;
        }

        if (dict.Values.Any(t => t + jokers == 3) && dict.Values.Any(t => t == 2))
        {
            return HandType.FullHouse;
        }

        if (dict.Values.Any(t => t + jokers == 3))
        {
            return HandType.ThreeKind;
        }

        if (dict.Values.Count(t => t + jokers == 2) == 2)
        {
            return HandType.TwoPair;
        }

        if (dict.Values.Any(t => t + jokers == 2))
        {
            return HandType.OnePair;
        }

        return HandType.HighCard;
    }

    private Dictionary<char, int> CountCards(Hand hand, out int jokers)
    {
        var dict = new Dictionary<char, int>();
        jokers = 0;

        foreach (var c in hand.Cards)
        {
            if (c == 'J')
            {
                jokers++;
                continue;
            }

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

    public int CardValue(char labelValue)
    {
        if (ValueMapper.TryGetValue(labelValue, out var value))
        {
            return value;
        }

        return 0;
    }

    private static readonly Dictionary<char, int> ValueMapper = new()
    {
        ['A'] = 14,
        ['K'] = 13,
        ['Q'] = 12,
        ['T'] = 10,
        ['9'] = 9,
        ['8'] = 8,
        ['7'] = 7,
        ['6'] = 6,
        ['5'] = 5,
        ['4'] = 4,
        ['3'] = 3,
        ['2'] = 2,
        ['J'] = 1
    };
}
