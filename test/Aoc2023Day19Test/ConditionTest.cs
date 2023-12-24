using Aoc2023Day19;
using FluentAssertions;

namespace Aoc2023Day19Test;

public class ConditionTest
{
    private readonly Part _part;

    public ConditionTest()
    {
        _part = new Part(10, 20000, 30, 40000);
    }

    [Fact]
    public void Given_ConditionIsFullFilled_Returns_True()
    {
        var sut  = new Condition('a', '<', 24000);
        var suta  = new Condition('x', '>', 2);

        sut.Eval(_part).Should().BeTrue();
        suta.Eval(_part).Should().BeTrue();
    }

    [Fact]
    public void Given_ConditionIsNotMet_Returns_False()
    {
        var sut  = new Condition('a', '<', 30);
        var suta  = new Condition('x', '>', 10);

        sut.Eval(_part).Should().BeFalse();
        suta.Eval(_part).Should().BeFalse();
    }

    [Fact]
    public void Given_ConditionIsNotMet2_Returns_False()
    {
        var sut  = new Condition('a', '<', 29);
        var suta  = new Condition('x', '>', 11);

        sut.Eval(_part).Should().BeFalse();
        suta.Eval(_part).Should().BeFalse();
    }
}
