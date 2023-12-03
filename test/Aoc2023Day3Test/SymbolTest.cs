using Aoc2023Day3;
using FluentAssertions;

namespace Aoc2023Day3Test;

public class SymbolTest
{
    private readonly Symbol _sut;

    public SymbolTest()
    {
        _sut = new Symbol();
    }

    [Theory]
    [InlineData('-')]
    [InlineData('+')]
    [InlineData('*')]
    [InlineData('/')]
    [InlineData('\\')]
    [InlineData('$')]
    public void Given_ValidSymbol_Then_ReturnsTrue(char symbol)
    {
        var result = _sut.IsSymbol(symbol);

        result.Should().BeTrue();
    }

    [Theory]
    [InlineData('>')]
    [InlineData('<')]
    [InlineData('{')]
    [InlineData('0')]
    [InlineData('1')]
    [InlineData('9')]
    [InlineData('z')]
    public void Given_NoSymbol_Then_ReturnsFalse(char input)
    {
        var result = _sut.IsSymbol(input);

        result.Should().BeFalse();
    }

    [Theory]
    [InlineData(".....*..")]
    [InlineData("-......")]
    [InlineData("......+")]
    [InlineData("aaaa$")]
    public void Given_StringWithSymbol_Then_ReturnsTrue(string str)
    {
        var result = _sut.ContainsSymbol(str);

        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("......")]
    [InlineData("a......")]
    [InlineData("......<")]
    [InlineData("abcde")]
    [InlineData("")]
    public void Given_StringWithoutSymbol_Then_ReturnsFalse(string str)
    {
        var result = _sut.ContainsSymbol(str);

        result.Should().BeFalse();
    }
}
