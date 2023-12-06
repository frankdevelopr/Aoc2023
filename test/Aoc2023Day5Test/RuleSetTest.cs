using Aoc2023Day5;
using FluentAssertions;

namespace Aoc2023Day5Test;

public class RuleSetTest
{
    [Theory]
    [InlineData(79, 81)]
    [InlineData(14, 14)]
    [InlineData(55, 57)]
    [InlineData(13, 13)]
    public void Given_RuleSet_Then_ReturnsExpectedValue(int input, int expectedOutput)
    {
        var rule1 = new Rule(50, 98, 2);
        var rule2 = new Rule(52, 50, 48);
        var ruleSet = new RuleSet([rule1, rule2]);

        var result = ruleSet.Apply(input);

        result.Should().Be(expectedOutput);
    }
}
