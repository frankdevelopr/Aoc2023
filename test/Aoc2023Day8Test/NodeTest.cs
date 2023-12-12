using Aoc2023Day8;
using FluentAssertions;

namespace Aoc2023Day8Test;

public class NodeTest
{
    [Fact]
    public void Given_ValidNode_Then_BuildCorrectly()
    {
        var node = new Node("A", "B", "C");

        node.Label.Should().Be("A");
        node.Left.Should().Be("B");
        node.Right.Should().Be("C");
    }
}
