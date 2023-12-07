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

        var result = HandClassifier.Classify(hand);
        result.Should().Be(expectedType);
    }
}
