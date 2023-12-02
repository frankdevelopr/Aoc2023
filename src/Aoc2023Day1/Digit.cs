namespace Aoc2023Day1;

public class Digit : IDigit
{
    public bool IsDigit(string text, out int value)
    {
        if (text?.Length != 1 || !char.IsDigit(text[0])) 
        {
            value = 0;
            return false;
        }

        value = int.Parse(text[0].ToString());

        return true;
    }

    public bool ContainsDigit(string textWithNumber, out int value)
    {
        if (string.IsNullOrEmpty(textWithNumber))
        {
            value = 0;
            return false;
        }

        foreach (var item in textWithNumber)
        {
            if (IsDigit(item.ToString(), out value))
            {
                return true;
            }
        }

        value = 0;
        return false;
    }
}
