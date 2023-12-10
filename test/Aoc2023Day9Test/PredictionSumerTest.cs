using Aoc2023Day9;
using FluentAssertions;

namespace Aoc2023Day9Test;

public class PredictionSumerTest
{
    [Theory]
    [InlineData("test.txt", 114)]
    [InlineData("problem.txt", 1934898178L)]
    public void Given_Histories_Then_PredictionSumAsExpected(string file, long expectedSum)
    {
        var lines = File.ReadAllLines($"data/{file}");

        var sut = new PredictionSumer(lines);

        var result = sut.Sum;

        result.Should().Be(expectedSum);
   }

    [Theory]
    [InlineData("test.txt", 2)]
    [InlineData("problem.txt", 1129L)]
    public void Given_Histories_Then_PreviousPredictionSumAsExpected(string file, long expectedSum)
    {
        var lines = File.ReadAllLines($"data/{file}");

        var sut = new PredictionSumer(lines);

        var result = sut.SumPrevious;

        result.Should().Be(expectedSum);
   }
}