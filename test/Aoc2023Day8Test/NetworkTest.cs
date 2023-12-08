using Aoc2023Day8;
using FluentAssertions;

namespace Aoc2023Day8Test;

public class NetworkTest
{
    [Fact]
    public void Given_ValidNode_Returns_ExpectedNode()
    {
        var sut = new Network();

        var nodeA = new Node("A", "B", "C");
        var nodeB = new Node("B", "B", "C");
        var nodeC = new Node("C", "A", "C");

        sut.Add(nodeA).Add(nodeB).Add(nodeC);

        sut.Get("A").Should().BeEquivalentTo(nodeA);
        sut.Get("B").Should().BeEquivalentTo(nodeB);
        sut.Get("C").Should().BeEquivalentTo(nodeC);

        sut.Get("D").Should().BeNull();
    }
}
