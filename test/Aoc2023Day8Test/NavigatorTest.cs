using Aoc2023Day8;
using FluentAssertions;

namespace Aoc2023Day8Test;

public class NavigatorTest
{
    [Theory]
    [InlineData("LR", 0, Direction.Left)]
    [InlineData("LR", 1, Direction.Right)]
    [InlineData("LR", 20, Direction.Left)]
    [InlineData("LR", 21, Direction.Right)]
    [InlineData("LLR", 0, Direction.Left)]
    [InlineData("LLR", 1, Direction.Left)]
    [InlineData("LLR", 2, Direction.Right)]
    [InlineData("LLR", 21, Direction.Left)]
    [InlineData("LLR", 22, Direction.Left)]
    [InlineData("LLR", 23, Direction.Right)]
    public void Given_Navigator_Then_ReturnsExpectedDirection(string directions, int steps, Direction expectedDirection)
    {
        var sut = new Navigator(directions);

        for (var i = 0; i < steps; i++)
        {
            sut.Next();
        }

        var direction = sut.Next();

        direction.Should().Be(expectedDirection);
    }
}
