using Aoc2023Day1;
using FluentAssertions;

namespace Aoc2023Day1Test;

public class DigitTextTest
{
    [Theory]
    [InlineData("one", 1)]
    [InlineData("two", 2)]
    [InlineData("three", 3)]
    [InlineData("four", 4)]
    [InlineData("five", 5)]
    [InlineData("six", 6)]
    [InlineData("seven", 7)]
    [InlineData("eight", 8)]
    [InlineData("nine", 9)]
    public void Given_ValidTextNumber_Then_ReturnsItsValue(string textNumber, int expectedValue)
    {
        var sut = new DigitText();

        var isDigit = sut.IsDigit(textNumber, out var value);

        isDigit.Should().BeTrue();
        value.Should().Be(expectedValue);
    }

    [Fact]
    public void Given_ZeroTextNumber_Then_ReturnsFalse()
    {
        var sut = new DigitText();

        var isDigit = sut.IsDigit("zero", out var value);

        isDigit.Should().BeFalse();
    }

    [Theory]
    [InlineData("lolo")]
    [InlineData("nine8")]
    [InlineData("ninenine")]
    [InlineData("nineninetxt")]
    [InlineData("9")]
    public void Given_InvalidTextNumber_ThenReturnsFalse(string textNumber)
    {
        var sut = new DigitText();

        var isDigit = sut.IsDigit(textNumber, out var value);

        isDigit.Should().BeFalse();
    }

    [Theory]
    [InlineData("two", 2)]
    [InlineData("xxtwo", 2)]
    [InlineData("twoxx", 2)]
    [InlineData("three", 3)]
    [InlineData("aljalfathree", 3)]
    [InlineData("threekiwlo", 3)]
    [InlineData("44three44", 3)]
    public void Given_TextContainigTextNumber_Then_ReturnsItsValue(string textWithNumber, int expectedValue)
    {
        var sut = new DigitText();

        var isDigit = sut.ContainsDigit(textWithNumber, out var value);

        isDigit.Should().BeTrue();
        value.Should().Be(expectedValue);
    }

    [Theory]
    [InlineData("ninetwotwo")]
    [InlineData("threeone")]
    public void Given_TextContainigTwoDifferentTextNumbers_Then_ReturnsFalse(string textWithNumber)
    {
        var sut = new DigitText();

        var isDigit = sut.ContainsDigit(textWithNumber, out var value);

        isDigit.Should().BeFalse();
    }

    [Theory]
    [InlineData("oh no number here")]
    [InlineData("almost1")]
    public void Given_TextNotContainigTextNumber_Then_ReturnsFalse(string textWithNumber)
    {
        var sut = new DigitText();

        var isDigit = sut.ContainsDigit(textWithNumber, out var value);

        isDigit.Should().BeFalse();
    }
}