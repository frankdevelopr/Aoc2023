using Aoc2023Day21;
using FluentAssertions;

namespace Aoc2023Day21Test;

public class StepsAwayCounterTest
{
    [Theory]
    [InlineData("data/test.txt", 6, 16)]
    [InlineData("data/problem.txt", 64, 3764L)]
    public void Given_Map_When_WalkingSteps_Then_ShouldReachPlots(string file, int steps, long plots)
    {
        var lines = File.ReadAllLines(file);

        var sut = new StepsAwayCounter(lines);

        sut.Walk(steps);

        sut.PlotsReached.Should().Be(plots);
    }
}
