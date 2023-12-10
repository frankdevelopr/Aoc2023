using Aoc2023Day9;
using FluentAssertions;

namespace Aoc2023Day9Test;

public class HistoryTest
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Given_History_Then_PredictionWellCalculated(long[] data, long expectedValue, long _)
    {
        var sut = new History(data);

        sut.Predict();
        sut.Prediction.Should().Be(expectedValue);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Given_History_Then_BackInTimePredictionWellCalculated(long[] data, long _, long expectedValue)
    {
        var sut = new History(data);

        sut.Predict();
        sut.PreviousPrediction.Should().Be(expectedValue);
    }


    public static TheoryData<long[], long, long> TestData
    {
        get
        {
            var data = new TheoryData<long[], long, long>();

            data.Add([ 0,  3,  6,  9, 12, 15], 18, -3);
            data.Add([ 1,  3,  6, 10, 15, 21], 28, 0);
            data.Add([10, 13, 16, 21, 30, 45], 68, 5);

            return data;
        }
    }
}
