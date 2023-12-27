using FluentAssertions;
using Utils;

namespace Aoc2023Day21Test;

public class PositionTest
{
    [Fact]
    public void Given_EqualPositions_Then_RemovedFromSet()
    {
        var p1 = new Position(1, 1);
        var p2 = new Position(1, 1);

        var sut = new HashSet<Position>();
        sut.Add(p1);
        sut.Add(p2);

        sut.Count.Should().Be(1);
    }

}