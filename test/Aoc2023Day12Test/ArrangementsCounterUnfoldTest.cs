using Aoc2023Day12;
using FluentAssertions;

namespace Aoc2023Day12Test;

public class ArrangementsCounterUnfoldTest
{
    [Theory]
    [InlineData("data/test.txt", 525152L)]
    //[InlineData("data/problem.txt", 6488L)]
    public void Given_SpringsList_When_Calculate_Then_ReturnsExpectedNumber(string file, long expectedArrangements)
    {
        var lines = File.ReadAllLines(file);

        var sut = new ArrangementsCounterUnfold(lines);

        sut.Arrangements.Should().Be(expectedArrangements);
    }
}
