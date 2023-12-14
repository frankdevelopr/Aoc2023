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
}
