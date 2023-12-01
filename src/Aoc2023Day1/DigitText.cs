namespace Aoc2023Day1;

public class DigitText : IDigit
{
    private static readonly Dictionary<string, int> Numbers = new Dictionary<string, int>()
    {
        ["one"] = 1,
        ["two"] = 2,
        ["three"] = 3,
        ["four"] = 4,
        ["five"] = 5,
        ["six"] = 6,
        ["seven"] = 7,
        ["eight"] = 8,
        ["nine"] = 9
    };

    public bool IsDigit(string text, out int value)
    {
        return Numbers.TryGetValue(text, out value);
    }

    public bool ContainsDigit(string textWithNumber, out int value)
    {
        var nums = Numbers.Keys.Where(key => textWithNumber.Contains(key));

        if (nums?.Count() != 1)
        {
            value = 0;
            return false;
        }

        value = Numbers[nums.First()];
        return true;
    }
}
