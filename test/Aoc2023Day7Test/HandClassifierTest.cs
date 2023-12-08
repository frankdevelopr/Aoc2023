using Aoc2023Day7;
using FluentAssertions;

namespace Aoc2023Day7Test;

public class HandClassifierTest
{
    [Theory]
    [InlineData("AAAAA", HandType.FiveKind)]
    [InlineData("2AAAA", HandType.FourKind)]
    [InlineData("AAAA3", HandType.FourKind)]
    [InlineData("33AAA", HandType.FullHouse)]
    [InlineData("3AAA3", HandType.FullHouse)]
    [InlineData("A2AA4", HandType.ThreeKind)]
    [InlineData("33AA2", HandType.TwoPair)]
    [InlineData("33AK2", HandType.OnePair)]
    [InlineData("38AK2", HandType.HighCard)]
    public void Given_ValidHand_Then_ReturnsType(string cards, HandType expectedType)
    {
        var hand = new Hand(cards);
        var sut = new HandClassifier();

        var result = sut.Classify(hand);
        result.Should().Be(expectedType);
    }

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
        var sut = new HandClassifier();

        sut.CardValue(label).Should().Be(expectedValue);
    }
}
