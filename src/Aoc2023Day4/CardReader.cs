
namespace Aoc2023Day4;

public class CardReader
{
    public IEnumerable<Card> Read(IEnumerable<string> lines)
    {
        var empty = Enumerable.Empty<Card>();

        if (!lines.Any())
        {
            return empty;
        }

        var cards = new List<Card>();

        foreach (var line in lines)
        {
            var parts = line.Split(':');
            if (parts.Length != 2)
            {
                continue;
            }

            if (!int.TryParse(parts[0].Split(" ")[1], out var cardNo))
            {
                continue;
            }

            var numbers = parts[1].Split("|");
            if (numbers.Length != 2)
            {
                continue;
            }

            var winning = Parse(numbers[0]);
            var own = Parse(numbers[1]);

            cards.Add(new Card(cardNo, winning, own));
        }

        return cards;
    }

    private static IEnumerable<int> Parse(string numbers)
    {
        var parsed = numbers.Split(" ")
            .Where(t => !string.IsNullOrEmpty(t))
            .Select(i => int.Parse(i.Trim()));

        return parsed;
    }
}
