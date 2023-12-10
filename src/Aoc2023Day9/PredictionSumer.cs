namespace Aoc2023Day9;

public class PredictionSumer
{
    public long Sum { get; } = 0;
    public long SumPrevious { get; } = 0;

    public PredictionSumer(IEnumerable<string> lines)
    {
        var hists = Parse(lines);

        Process(hists);
        Sum = SumUp(hists);
        SumPrevious = SumUpPrevious(hists);
    }

    private static long SumUp(IEnumerable<History> hists)
    {
        var sum = 0L;

        foreach(var hist in hists)
        {
            sum += hist.Prediction;
        }

        return sum;
    }

    private static long SumUpPrevious(IEnumerable<History> hists)
    {
        var sum = 0L;

        foreach(var hist in hists)
        {
            sum += hist.PreviousPrediction;
        }

        return sum;
    }

    private IEnumerable<History> Parse(IEnumerable<string> lines)
    {
        var lists = new List<History>();

        foreach (var line in lines)
        {
            lists.Add(new History(Parse(line)));
        }

        return lists;
    }

    private void Process(IEnumerable<History> hists)
    {
        Parallel.ForEach(hists, hist =>
        {
            hist.Predict();
        });
    }

    private static List<long> Parse(string numbers)
    {
        var parsed = numbers.Trim().Split(" ")
            .Where(t => !string.IsNullOrEmpty(t))
            .Select(i => long.Parse(i.Trim()));

        return parsed.ToList();
    }
}
