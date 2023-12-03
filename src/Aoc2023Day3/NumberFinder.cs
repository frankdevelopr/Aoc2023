using System.Text;

namespace Aoc2023Day3;

public class NumberFinder
{
    public IEnumerable<NumberFound> Find(string line)
    {
        var numbers = new List<NumberFound>();
        var tokenizer = new StringBuilder();

        var lastPosition = 0;

        foreach (var item in line)
        {
            if (char.IsDigit(item))
            {
                tokenizer.Append(item);
            }
            else
            {
                TryAddNumber(numbers, tokenizer, lastPosition);
                tokenizer.Clear();
            }

            lastPosition++;
        }

        TryAddNumber(numbers, tokenizer, lastPosition);

        return numbers;
    }

    private static void TryAddNumber(List<NumberFound> numbers, StringBuilder tokenizer, int lastPosition)
    {
        var len = tokenizer.Length;

        if (len == 0)
        {
            return;
        }

        var start = lastPosition - len;
        var number = new NumberFound(int.Parse(tokenizer.ToString()), start, lastPosition);

        numbers.Add(number);
    }
}
