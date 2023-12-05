using Aoc2023Day5;
using FluentAssertions;

namespace Aoc2023Day5Test;

public class RuleTest
{
    /*
      seeds: 79 14 55 13

      seed-to-soil map:
      50 98 2
      52 50 48*/

    [Theory]
    [InlineData("50 98 2", 98, 50)]
    [InlineData("50 98 2", 99, 51)]
    [InlineData("50 98 2", 100, 100)]
    [InlineData("50 98 2", 0, 0)]
    [InlineData("50 98 2", 97, 97)]
    [InlineData("50 98 2", 50, 50)]
    
    public void Given_Rule_When_Applied_Then_ReturnsExpectedValue(string line, int input, int expectedOutput)
    {
        var sut = new Rule(50, 98, 2);

        var result = sut.Apply(input);

        result.Should().Be(expectedOutput);

    }

    [Theory]
    [InlineData("52 50 48", 0, 0)]
    [InlineData("52 50 48", 1, 1)]
    [InlineData("52 50 48", 49, 49)]
    [InlineData("52 50 48", 50, 52)]
    [InlineData("52 50 48", 51, 53)]
    [InlineData("52 50 48", 97, 99)]
    public void Given_Rule2_When_Applied_Then_ReturnsExpectedValue(string line, int input, int expectedOutput)
    {
        var sut = new Rule(52, 50, 48);

        var result = sut.Apply(input);

        result.Should().Be(expectedOutput);
    }
}
