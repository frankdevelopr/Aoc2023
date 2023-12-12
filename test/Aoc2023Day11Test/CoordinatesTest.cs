using Aoc2023Day11;
using FluentAssertions;

namespace Aoc2023Day11Test;

public class CoordinatesTest
{
    [Theory]
    [InlineData(1, 2)]
    [InlineData(7, 8)]
    public void Given_Coords_Then_PropertiesSet(int y, int x)
    {
        var sut = new Coordinates(y, x);

        sut.Y.Should().Be(y);
        sut.X.Should().Be(x);
    }

    [Theory]
    [MemberData(nameof(CoordinatesTestData))]
    public void Given_TwoCoordinates_When_Distance_Then_CalculateAsExpected(Coordinates p, Coordinates q, int expectedDistance)
    {
        p.DistanceTo(q).Should().Be(expectedDistance);
    }

    public static TheoryData<Coordinates, Coordinates, int> CoordinatesTestData
    {
        get
        {
            var data = new TheoryData<Coordinates, Coordinates, int>();

            var p1 = new Coordinates(0, 2);
            var p2 = new Coordinates(0, 5);
            var p3 = new Coordinates(2, 8);

            data.Add(p1, p1, 0);
            data.Add(p1, p2, 3);
            data.Add(p2, p1, 3);
            data.Add(p2, p3, 5);
            data.Add(p3, p2, 5);
            data.Add(p1, p3, 8);
            data.Add(p3, p1, 8);

            return data;
        }
    }
}
