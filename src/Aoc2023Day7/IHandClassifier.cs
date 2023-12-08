namespace Aoc2023Day7
{
    public interface IHandClassifier
    {
        HandType Classify(Hand hand);
        int CardValue(char labelValue);
    }
}