using Aoc2023Day19;
using FluentAssertions;

namespace Aoc2023Day19Test;

public class RuleTest
{
    private readonly Part _part;

    public RuleTest()
    {
        _part = new Part(10, 20000, 30, 40000);
    }

    [Fact]
    public void Given_RuleWithoutCondition_Then_ReturnsNextWorkflow()
    {
        var sut = new Rule("A");

        sut.Eval(_part).Should().Be("A");
    }

    [Fact]
    public void Given_Rule_When_ConditionMet_Then_ReturnsNextWorkflow()
    {
        var sut = new Rule("A", new Condition('a', '<', 24000));

        sut.Eval(_part).Should().Be("A");
    }

    [Fact]
    public void Given_Rule_When_ConditionNotMet_Then_ReturnsNull()
    {
        var sut = new Rule("A", new Condition('a', '<', 4));

        sut.Eval(_part).Should().BeNull();
    }
}
