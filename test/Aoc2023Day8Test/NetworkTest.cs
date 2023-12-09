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

    [Fact]
    public void Given_Nodes_When_StartingNodes_ReturnsNodesEndingWithA()
    {
        var sut = new Network();

        var a1 = new Node("A", "B", "C"); 
        sut.Add(a1);
        var a2 = new Node("TTA", "B", "C"); 
        sut.Add(a2);
        sut.Add(new Node("B", "B", "C"));
        sut.Add(new Node("AAX", "B", "C"));
        var a3 = new Node("XPA", "B", "C"); 
        sut.Add(a3);

        var result = sut.StartingNodes();
        result.Should().BeEquivalentTo(new Node[] {a1, a2, a3});
    }

    [Fact]
    public void Given_Nodes_When_AllNodesEndingWithZ_ReturnsTrue()
    {
        var a1 = new Node("AZ", "B", "C"); 
        var a2 = new Node("TTAZ", "B", "C"); 
        var a3 = new Node("XPAZ", "B", "C"); 

        var sut = new Network();

        var result = sut.AreAllEnding([a1, a2, a3]);
        result.Should().BeTrue();
    }

    [Fact]
    public void Given_Nodes_When_NotAllNodesEndingWithZ_ReturnsFalse()
    {
        var a1 = new Node("AZ", "B", "C"); 
        var a2 = new Node("ZZA", "B", "C"); 
        var a3 = new Node("XPAZ", "B", "C"); 

        var sut = new Network();

        var result = sut.AreAllEnding([a1, a2, a3]);
        result.Should().BeFalse();
    }
}
