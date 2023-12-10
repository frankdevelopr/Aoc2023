



namespace Aoc2023Day9;

public class History
{
    public List<long> Values { get; }
    public long Prediction { get; private set; }


    public History(IEnumerable<long> values)
    {
        Values = values.ToList();
    }

    public void Predict()
    {
        var _converging = new List<List<long>>();
        _converging.Add(Values);

        Converge(_converging);
        Prediction = Calculate(_converging);

        Prediction = Values[Values.Count-1];
    }

    private long Calculate(List<List<long>> _converging)
    {
        var lists = _converging.Count - 1;

        var  lastValue = 0L;

        for (var i = lists-1; i >= 0; i--)
        {
            var currentList = _converging[i];
            var myListItem = currentList[currentList.Count-1];
            var lastListItem = _converging[i+1][_converging[i+1].Count-1];

            lastValue = myListItem+lastListItem;
            currentList.Add(lastValue);
        }

        return lastValue;
    }

    private void Converge(List<List<long>> converging)
    {
        var lastCalculation = converging[converging.Count-1];

        while (!Converged(lastCalculation))
        {
            lastCalculation = GenerateDiffs(lastCalculation);
            converging.Add(lastCalculation);
        }
    }

    private List<long> GenerateDiffs(List<long> lastCalculation)
    {
        var lastItem = lastCalculation.Count - 1;
        var nextCalc = new List<long>(lastItem);

        for (var i = 1; i <= lastItem; ++i)
        {
            var diff = lastCalculation[i] - lastCalculation[i-1];
            nextCalc.Add(diff);
        }

        return nextCalc;
    }

    private bool Converged(List<long> list)
    {
        return list.All(t => t == 0);
    }
}
