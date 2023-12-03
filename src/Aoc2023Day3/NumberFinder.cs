using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aoc2023Day3;

public class NumberFinder
{
    public IEnumerable<NumberFound> Find(string line)
    {
        if (line == null)
        {
            return Enumerable.Empty<NumberFound>();
        }

        var numbers = new List<NumberFound>();

        var tokenizer = new StringBuilder();

        foreach (var item in line)
        {
            if (char.IsDigit(item))
            {
                tokenizer.Append(item);
            }
            else if (tokenizer.Length > 0) 
            {
                int.TryParse(tokenizer.ToString(), out var num);
                numbers.Add(new NumberFound(num));
                tokenizer.Clear();
            }
        }

        if (tokenizer.Length > 0)
        {
            int.TryParse(tokenizer.ToString(), out var num);
                numbers.Add(new NumberFound(num));
        }

        return numbers;
    }

    /*public NumberFound Find(string line)
    {
        if (line == null) return new NumberFound(0);

        var number = new StringBuilder();

        foreach (var item in line)
        {
            if (char.IsDigit(item))
            {
                number.Append(item);
            }
        }

        var strNumber = number.ToString();

        int.TryParse(strNumber, out var num);

        var numberFound = new NumberFound(num);

        return numberFound;
    }*/
}
