using Aoc2023Day5;
using FluentAssertions;

namespace Aoc2023Day5Test;

public class RuleTest
{
    [Theory]
    [InlineData("50 98 2", 98, 50, true)]
    [InlineData("50 98 2", 99, 51, true)]
    [InlineData("50 98 2", 100, 100, false)]
    [InlineData("50 98 2", 0, 0, false)]
    [InlineData("50 98 2", 97, 97, false)]
    [InlineData("50 98 2", 50, 50, false)]
    public void Given_Rule_When_Applied_Then_ReturnsExpectedValue(string line, int input, int expectedOutput, bool applied)
    {
        var sut = new Rule(50, 98, 2);

        var result = sut.TryApply(input, out var output);

        result.Should().Be(applied);
        output.Should().Be(expectedOutput);
    }

    [Theory]
    [InlineData("52 50 48", 0, 0, false)]
    [InlineData("52 50 48", 1, 1, false)]
    [InlineData("52 50 48", 49, 49, false)]
    [InlineData("52 50 48", 50, 52, true)]
    [InlineData("52 50 48", 51, 53, true)]
    [InlineData("52 50 48", 97, 99, true)]
    [InlineData("52 50 48", 98, 98, false)]
    public void Given_Rule2_When_Applied_Then_ReturnsExpectedValue(string line, int input, int expectedOutput, bool applied)
    {
        var sut = new Rule(52, 50, 48);

        var result = sut.TryApply(input, out var output);

        result.Should().Be(applied);
        output.Should().Be(expectedOutput);
    }
}
