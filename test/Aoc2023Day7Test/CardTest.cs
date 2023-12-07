using Aoc2023Day7;
using FluentAssertions;

namespace Aoc2023Day7Test;

public class CardTest
{
    [Theory]
    [InlineData('A', 14)]
    [InlineData('K', 13)]
    [InlineData('Q', 12)]
    [InlineData('J', 11)]
    [InlineData('T', 10)]
    [InlineData('9', 9)]
    [InlineData('8', 8)]
    [InlineData('7', 7)]
    [InlineData('6', 6)]
    [InlineData('5', 5)]
    [InlineData('4', 4)]
    [InlineData('3', 3)]
    [InlineData('2', 2)]
    public void Given_Label_Then_CardHasItsExpectedValue(char label, int expectedValue)
    {
        var card = new Card(label);

        card.Value.Should().Be(expectedValue);
    }
}
