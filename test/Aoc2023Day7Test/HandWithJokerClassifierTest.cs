using Aoc2023Day7;
using FluentAssertions;

namespace Aoc2023Day7Test;

public class HandWithJokerClassifierTest
{
    private readonly HandWithJokerClassifier _sut;

    public HandWithJokerClassifierTest()
    {
        _sut = new HandWithJokerClassifier();
    }

    [Theory]
    [InlineData("32TJK", HandType.OnePair)]
    [InlineData("32T3K", HandType.OnePair)]
    [InlineData("KK677", HandType.TwoPair)]
    [InlineData("AAA1T", HandType.ThreeKind)]
    [InlineData("AJ1JT", HandType.ThreeKind)]
    [InlineData("32TJJ", HandType.ThreeKind)]
    [InlineData("T55J5", HandType.FourKind)]
    [InlineData("KTJJT", HandType.FourKind)]
    [InlineData("QQQJA", HandType.FourKind)]
    [InlineData("AAAAA", HandType.FiveKind)]
    [InlineData("AAAJJ", HandType.FiveKind)]
    [InlineData("JJJJJ", HandType.FiveKind)]
    public void Given_ValidHand_Then_ReturnsType(string cards, HandType expectedType)
    {
        var hand = new Hand(cards);
        var sut = new HandWithJokerClassifier();

        var result = sut.Classify(hand);
        result.Should().Be(expectedType);
    }

    [Theory]
    [InlineData('A', 14)]
    [InlineData('K', 13)]
    [InlineData('Q', 12)]
    [InlineData('T', 10)]
    [InlineData('9', 9)]
    [InlineData('8', 8)]
    [InlineData('7', 7)]
    [InlineData('6', 6)]
    [InlineData('5', 5)]
    [InlineData('4', 4)]
    [InlineData('3', 3)]
    [InlineData('2', 2)]
    [InlineData('J', 1)]
    public void Given_Label_Then_CardHasItsExpectedValue(char label, int expectedValue)
    {
        var sut = new HandWithJokerClassifier();

        sut.CardValue(label).Should().Be(expectedValue);
    }

    [Theory]
    [InlineData("72772", HandType.FullHouse)]
    [InlineData("8Q278", HandType.OnePair)]
    [InlineData("QQJQQ", HandType.FiveKind)]
    [InlineData("77778", HandType.FourKind)]
    [InlineData("QAJ8A", HandType.ThreeKind)]
    [InlineData("87A6K", HandType.HighCard)]
    [InlineData("TTTT5", HandType.FourKind)]
    [InlineData("QJ4QA", HandType.ThreeKind)]
    [InlineData("6K688", HandType.TwoPair)]
    [InlineData("93A4Q", HandType.HighCard)]
    [InlineData("A66J9", HandType.ThreeKind)]
    [InlineData("J7773", HandType.FourKind)]
    [InlineData("88Q88", HandType.FourKind)]
    [InlineData("TTT48", HandType.ThreeKind)]
    [InlineData("88887", HandType.FourKind)]
    [InlineData("27227", HandType.FullHouse)]
    [InlineData("JQQ54", HandType.ThreeKind)]
    [InlineData("67666", HandType.FourKind)]
    [InlineData("5AT77", HandType.OnePair)]
    [InlineData("A96AA", HandType.ThreeKind)]
    public void Given_Data_Then_WellClassified(string handText, HandType expected)
    {
        var hand = new Hand(handText, 0);

        var result = _sut.Classify(hand);
        
        result.Should().Be(expected);
    }




















}
