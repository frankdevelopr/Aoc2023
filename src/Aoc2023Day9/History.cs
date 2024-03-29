﻿namespace Aoc2023Day9;

public class History
{
    public List<long> Values { get; }
    public long Prediction { get; private set; }
    public long PreviousPrediction { get; private set; }

    public History(IEnumerable<long> values)
    {
        Values = values.ToList();
    }

    public void Predict()
    {
        var _converging = new List<List<long>>
        {
            Values
        };

        Converge(_converging);
        Calculate(_converging);
    }

    private void Calculate(List<List<long>> _converging)
    {
        var lists = _converging.Count - 1;

        var firstValue = 0L;
        var  lastValue = 0L;

        for (var i = lists-1; i >= 0; i--)
        {
            var currentList = _converging[i];
            var myLastItem = currentList[^1];
            var lastListItem = _converging[i+1][^1];

            var firstItem = currentList[0];
            var lastListFirstItem = _converging[i+1][0];

            firstValue = firstItem - lastListFirstItem;
            lastValue = myLastItem+lastListItem;
            currentList.Add(lastValue);
            currentList.Insert(0, firstValue);
        }

        Prediction = lastValue;
        PreviousPrediction = firstValue;
    }

    private void Converge(List<List<long>> converging)
    {
        var lastCalculation = converging[^1];

        while (!Converged(lastCalculation))
        {
            lastCalculation = GenerateDiffs(lastCalculation);
            converging.Add(lastCalculation);
        }
    }

    private static List<long> GenerateDiffs(List<long> lastCalculation)
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

    private static bool Converged(List<long> list)
    {
        return list.TrueForAll(t => t == 0);
    }
}
