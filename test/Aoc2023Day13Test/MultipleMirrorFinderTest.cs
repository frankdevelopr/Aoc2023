using Aoc2023Day13;
using FluentAssertions;

namespace Aoc2023Day13Test;

public class MultipleMirrorFinderTest
{
    [Theory]
    [InlineData("data/test.txt", 405)]
    [InlineData("data/problem.txt", 39939L)]
    public void Given_MutiplePatterns_Then_CalculationAsExpected(string file, long expectedValue)
    {
        var lines = File.ReadAllText(file);

        var finder = new MultipleMirrorFinder(lines);

        finder.Calculate().Should().Be(expectedValue);
    }

    [Theory]
    [InlineData("data/test.txt", 400)]
    // 20508L too low, 24999L too low, 33299L too high, debug 1 by 1 and see
    [InlineData("data/problem.txt", 24999L)]
    public void Given_MutiplePatterns_Then_SmudgeCalculationAsExpected(string file, long expectedValue)
    {
        var lines = File.ReadAllText(file);

        var finder = new MultipleMirrorFinder(lines);

        finder.CalculateSmudge().Should().Be(expectedValue);
    }
}
