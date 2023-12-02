using Aoc2023Day1;
using FluentAssertions;

namespace Aoc2023Day1Test;

public class DigitTest
{
    [Theory]
    [InlineData("0", 0)]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("3", 3)]
    [InlineData("4", 4)]
    [InlineData("5", 5)]
    [InlineData("6", 6)]
    [InlineData("7", 7)]
    [InlineData("8", 8)]
    [InlineData("9", 9)]
    public void Given_ValidNumber_ReturnTrue_AndItsValue(string number, int expectedValue)
    {
        var sut = new Digit();

        var isDigit = sut.IsDigit(number, out var value);

        isDigit.Should().BeTrue();
        value.Should().Be(expectedValue);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("12")]
    [InlineData("346")]
    [InlineData("A")]
    [InlineData("lolo lo")]
    public void Given_InvalidNumber_Or_MultipleDigits_ReturnFalse(string text)
    {
        var sut = new Digit();

        var isDigit = sut.IsDigit(text, out var value);

        isDigit.Should().BeFalse();
    }

    [Theory]
    [InlineData("12", 1)]
    [InlineData("346", 3)]
    [InlineData("Aaa2", 2)]
    [InlineData("lolo lo9", 9)]
    [InlineData("lolo lo7xx1", 7)]
    public void Given_SomeDigits_ReturnsTrue_And_FirstValidDigit(string text, int expectedValue)
    {
        var sut = new Digit();

        var isDigit = sut.ContainsDigit(text, out var value);

        isDigit.Should().BeTrue();
        value.Should().Be(expectedValue);
    }

    [Theory]
    [InlineData("abcde")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("a b c d one")]
    public void Given_NoDigits_ReturnsFalse(string text)
    {
        var sut = new Digit();

        var isDigit = sut.ContainsDigit(text, out var value);

        isDigit.Should().BeFalse();
    }
}
