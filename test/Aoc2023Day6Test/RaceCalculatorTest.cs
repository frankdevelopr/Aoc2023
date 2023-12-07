using Aoc2023Day6;
using FluentAssertions;

namespace Aoc2023Day6Test;

public class RaceCalculatorTest
{
    [Theory]
    [InlineData(7, 9, 4)]
    [InlineData(15, 40, 8)]
    [InlineData(30, 200, 9)]
    public void Given_TimeDistance_Then_ReturnsExpectedWins(int time, int targetDistance, int expectedWins)
    {
        var sut = new RaceCalculator();

        var wins = sut.WaysToWin(time, targetDistance);

        wins.Should().Be(expectedWins);
    }
}