namespace Aoc2023Day7;

public class Card
{
    public string Label { get; }
    public int Value { get; }

    public Card(string faceValue)
    {
        Label = faceValue;
        Value = GetValue(faceValue);
    }

    private static int GetValue(string labelValue)
    {
        if (ValueMapper.TryGetValue(labelValue, out var value))
        {
            return value;
        }

        return 0;
    }

    private static Dictionary<string, int> ValueMapper = new Dictionary<string, int>
    {
        ["A"] = 14,
        ["K"] = 13,
        ["Q"] = 12,
        ["J"] = 11,
        ["T"] = 10,
        ["9"] = 9,
        ["8"] = 8,
        ["7"] = 7,
        ["6"] = 6,
        ["5"] = 5,
        ["4"] = 4,
        ["3"] = 3,
        ["2"] = 2
    };
}


