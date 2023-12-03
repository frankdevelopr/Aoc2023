using System.Text;

namespace Aoc2023Day3;

public class NumberFinder
{
    public IEnumerable<NumberFound> Find(string line)
    {
        var numbers = new List<NumberFound>();
        var tokenizer = new StringBuilder();

        foreach (var item in line)
        {
            if (char.IsDigit(item))
            {
                tokenizer.Append(item);
            }
            else
            {
                TryAddNumber(numbers, tokenizer);
                tokenizer.Clear();
            }
        }

        TryAddNumber(numbers, tokenizer);

        return numbers;
    }

    private static void TryAddNumber(List<NumberFound> numbers, StringBuilder tokenizer)
    {
        if (tokenizer.Length == 0)
        {
            return;
        }

        numbers.Add(new NumberFound(int.Parse(tokenizer.ToString())));
    }
}
