using Aoc2023Day16;
using FluentAssertions;

namespace Aoc2023Day16Test;

public class DirectionCalculatorTest
{
    private readonly DirectionCalculator _sut;

    public DirectionCalculatorTest()
    {
        _sut = new DirectionCalculator();
    }

    [Theory]
    [InlineData(Direction.East, '/', Direction.North)]
    [InlineData(Direction.West, '/', Direction.South)]
    [InlineData(Direction.North, '/', Direction.East)]
    [InlineData(Direction.South, '/', Direction.West)]
    [InlineData(Direction.East, '\\', Direction.South)]
    [InlineData(Direction.West, '\\', Direction.North)]
    [InlineData(Direction.North, '\\', Direction.West)]
    [InlineData(Direction.South, '\\', Direction.East)]
    [InlineData(Direction.East, '.', Direction.East)]
    [InlineData(Direction.West, '.', Direction.West)]
    [InlineData(Direction.North, '.', Direction.North)]
    [InlineData(Direction.South, '.', Direction.South)]
    [InlineData(Direction.North, '|', Direction.North)]
    [InlineData(Direction.South, '|', Direction.South)]
    [InlineData(Direction.East, '-', Direction.East)]
    [InlineData(Direction.West, '-', Direction.West)]
    public void Given_Char_When_GivenPreviousDirection_Then_ReturnsDirection(Direction goingTo, char tile, Direction expected)
    {
        _sut.Next(tile, goingTo).Should().ContainSingle(x => x == expected);
    }

    [Theory]
    [InlineData(Direction.West, '|', new Direction[] {Direction.North, Direction.South})]
    [InlineData(Direction.East, '|', new Direction[] {Direction.North, Direction.South})]
    [InlineData(Direction.North, '-', new Direction[] {Direction.West, Direction.East})]
    [InlineData(Direction.South, '-', new Direction[] {Direction.West, Direction.East})]
    public void Given_CharSplit_When_GivenPreviousDirection_Then_ReturnsAllDirections(Direction goingTo, char tile, IEnumerable<Direction> expected)
    {
        _sut.Next(tile, goingTo).Should().BeEquivalentTo(expected);
    }
}