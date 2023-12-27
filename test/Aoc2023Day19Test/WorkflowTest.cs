using Aoc2023Day19;
using FluentAssertions;

namespace Aoc2023Day19Test;

public class WorkflowTest
{
    private readonly Workflow _sut;

    public WorkflowTest()
    {
        //ex{x>10:one,m<20:two,a>30:R,A}
        var rule1 = new Rule("one", new Condition('x', '>', 10));
        var rule2 = new Rule("two", new Condition('m', '<', 20));
        var rule3 = new Rule("R", new Condition('a', '>', 30));
        var rule4 = new Rule("A");

        _sut = new Workflow("ex", [rule1, rule2, rule3, rule4]);
    }

    
    [Fact]
    public void Given_Workflow_When_MatchingRule1_ReturnsRule1Workflow()
    {
        var part = new Part(11, 0, 0, 0);

        _sut.Eval(part).Should().Be("one");
    }

    [Fact]
    public void Given_Workflow_When_MatchingRule2_ReturnsRule2Workflow()
    {
        var part = new Part(0, 1, 0, 0);

        _sut.Eval(part).Should().Be("two");
    }

    [Fact]
    public void Given_Workflow_When_MatchingRule3_ReturnsRule3Workflow()
    {
        var part = new Part(0, 100, 31, 0);

        _sut.Eval(part).Should().Be("R");
    }
    
    [Fact]
    public void Given_Workflow_When_MatchingRule4_ReturnsRule4Workflow()
    {
        var part = new Part(0, 100, 0, 0);

        _sut.Eval(part).Should().Be("A");
    }
}
