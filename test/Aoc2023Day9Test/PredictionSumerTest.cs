using Aoc2023Day9;
using FluentAssertions;

namespace Aoc2023Day9Test;

public class PredictionSumerTest
{
    [InlineData("test.txt")]
    public void Given_Histories_Then_PredictionSumAsExpected(string file, long expectedSum)
    {
        var lines = File.ReadAllLines(file);

        var sut = new PredictionSumer(lines);

        var result = sut.Sum;

        result.Should().Be(expectedSum);
   }
}