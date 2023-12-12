using Aoc2023Day10;
using FluentAssertions;

namespace Aoc2023Day10Test;

public class SymbolTest
{
    private readonly SymbolTable _symbolTable;

    public SymbolTest()
    {
        _symbolTable = new SymbolTable();
    }

    [Theory]
    [InlineData('|', Direction.North, Direction.South)]
    [InlineData('|', Direction.South, Direction.North)]
    [InlineData('-', Direction.East, Direction.West)]
    [InlineData('-', Direction.West, Direction.East)]
    [InlineData('L', Direction.North, Direction.East)]
    [InlineData('L', Direction.East, Direction.North)]
    [InlineData('J', Direction.North, Direction.West)]
    [InlineData('J', Direction.West, Direction.North)]
    [InlineData('7', Direction.South, Direction.West)]
    [InlineData('7', Direction.West, Direction.South)]
    [InlineData('F', Direction.South, Direction.East)]
    [InlineData('F', Direction.East, Direction.South)]
    public void Given_ADirection_Then_ReturnsOtherDirection(char label, Direction input, Direction expected)
    {
        var sut = _symbolTable.Get(label);
        sut.Should().NotBeNull();

        var result = sut.NextFrom(input);

        result.Should().Be(expected);
    }


    [Theory]
    [InlineData('|', Direction.East)]
    public void Given_InvalidDirection_Then_Throws(char label, Direction input)
    {
        var sut = _symbolTable.Get(label);
        sut.Should().NotBeNull();

        sut.Invoking(y => y.NextFrom(input))
            .Should().Throw<ArgumentException>();
    }
}
