namespace Aoc2023Day7;

public class HandComparer : IComparer<Hand>
{
    public IHandClassifier Classifier { get; }

    public HandComparer(IHandClassifier classifier)
    {
        Classifier = classifier;
    }

    public int Compare(Hand? first, Hand? other)
    {
        if (other is null && first is null)
        {
            return 0;
        }

        if (first is null)
        {
            return -1;
        }

        if (other is null)
        {
            return 1;
        }

        var firstType = Classifier.Classify(first);
        var otherType = Classifier.Classify(other);

        if (firstType != otherType)
        {
            return firstType - otherType;
        }

        for (var i = 0; i < first.Cards.Length; ++i)
        {
            if (first.Cards[i] == other.Cards[i]) continue;

            return Classifier.CardValue(first.Cards[i]) - Classifier.CardValue(other.Cards[i]);
        }

        return 0;
    }
}
