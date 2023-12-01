namespace Aoc2023Day1;

public class Calibrator
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

    public int Calibrate(IEnumerable<string> calibrationLines)
    {
        var total = 0;

        foreach (var line in calibrationLines)
        {

            var first = FindFirstDigit(line);
            var last = FindLastDigit(line);

            Console.WriteLine(first + "" + last);

            total += first * 10 + int.Parse(last.ToString());
        }

        return total;
    }

    private int FindFirstDigit(string line)
    {
        for (var i = 0; i < line.Length; i++)
        {
            var value = 0;

            if (IsNumber(line[..(i)], ref value))
            {
                return value;
            }
        }

        return 0;
    }

    private int FindLastDigit(string line)
    {
        for (var i = 0; i < line.Length; i++)
        {
            var value = 0;

            if (IsNumber(line.Substring(line.Length-(i+1), i+1), ref value))
            {
                return value;
            }
        }

        return 0;
        //return line.Last(char.IsDigit);
    }

    private bool IsNumber(string word, ref int number)
    {
        if (string.IsNullOrEmpty(word)) return false;

        if (char.IsDigit(word[word.Length-1]))
        {
            number = int.Parse(word[word.Length-1].ToString());
            return true;
        }

        if (char.IsDigit(word[0]))
        {
            number = int.Parse(word[0].ToString());
            return true;
        }

        if (Numbers.TryGetValue(word, out number))
        {
            return true;
        }

        return false;
    }
}
