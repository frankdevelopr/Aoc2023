using Aoc2023Day19;
using FluentAssertions;

namespace Aoc2023Day19Test;

public class WorkflowSystemTest
{
    private readonly WorkflowSystem _sut;

    public WorkflowSystemTest()
    {
        var rule1 = new Rule("one", new Condition('x', '>', 10));
        var rule2 = new Rule("two", new Condition('m', '<', 20));
        var rule3 = new Rule("R", new Condition('a', '>', 30));
        var rule4 = new Rule("A");
        var w1 = new Workflow("in", [rule1, rule2, rule3, rule4]);

        var w2r1 = new Rule("A", new Condition('x', '>', 20));
        var w2r2 = new Rule("R");
        var w2 = new Workflow("one", [w2r1, w2r2] );

        _sut = new WorkflowSystem([w1, w2]);
    }

    [Fact]
    public void Given_System_When_PartAccepted_Then_ReturnsPartAccepted()
    {
        var part = new Part(0, 20, 30, 0);
        var part2 = new Part(22, 20, 30, 0);

        _sut.Eval(part).Should().BeTrue();
        _sut.Eval(part2).Should().BeTrue();
    }

    [Fact]
    public void Given_System_When_PartRejected_Then_ReturnsPartRejected()
    {
        var part = new Part(0, 20, 31, 0);
        var part2 = new Part(11, 20, 30, 0);

        _sut.Eval(part).Should().BeFalse();
        _sut.Eval(part2).Should().BeFalse();

    }
}