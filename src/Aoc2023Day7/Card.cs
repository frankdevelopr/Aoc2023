namespace Aoc2023Day7;

public class Card
{
    public char Label { get; }
    public int Value { get; }

    public Card(char faceValue)
    {
        Label = faceValue;
        Value = GetValue(faceValue);
    }

    public static int GetValue(char labelValue)
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
    };
}
