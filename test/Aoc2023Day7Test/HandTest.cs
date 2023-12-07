using Aoc2023Day7;
using FluentAssertions;

namespace Aoc2023Day7Test;

public class HandTest
{
    private HandComparer _comparer;
    private HandComparer _comparerEx;

    public HandTest()
    {
        _comparer = new HandComparer(new HandClassifier());
        _comparerEx = new HandComparer(new HandWithJokerClassifier());
    }

    [Theory]
    [InlineData("AAAA1")]
    [InlineData("AAA11")]
    [InlineData("AAA12")]
    [InlineData("AA113")]
    [InlineData("AQ113")]
    [InlineData("AQK13")]
    public void Given_FiveKind_When_Compared_Then_ShouldBeBiggerThanOtherTypes(string hand)
    {
        var winner = new Hand("QQQQQ");
        var other = new Hand(hand);

        _comparer.Compare(winner, other).Should().BePositive();
    }

    [Theory]
    [InlineData("AAAA1")]
    [InlineData("AAA11")]
    [InlineData("AAA12")]
    [InlineData("AA113")]
    [InlineData("AQ113")]
    [InlineData("AQK13")]
    public void Given_FiveKindEx_When_Compared_Then_ShouldBeBiggerThanOtherTypes(string hand)
    {
        var classifier = new HandWithJokerClassifier();

        var winner = new Hand("QQQQQ", 0);
        var other = new Hand(hand, 0);

        _comparer.Compare(winner, other).Should().BePositive();
    }

    [Theory]
    [InlineData("AAAA1", "QQQQ1")]
    [InlineData("QQQQ1", "1AAAA")]
    [InlineData("TTT21", "1AAA2")]
    public void Given_CardTiesOfType_When_Compared_Then_ShouldBeBiggerCard(string winnerCard, string otherCard)
    {
        var winner = new Hand(winnerCard);
        var other = new Hand(otherCard);

        _comparer.Compare(winner, other).Should().BePositive();
    }

    [Theory]
    [InlineData("AAAJ1", "QQQQ1")]
    [InlineData("QQQJ1", "1AAAJ")]
    [InlineData("TJT21", "1AJA2")]
    [InlineData("AAAAJ", "JJJJJ")]
    public void Given_CardTiesOfTypeWithJoker_When_Compared_Then_ShouldBeBiggerCard(string winnerCard, string otherCard)
    {
        var classifier = new HandWithJokerClassifier();

        var winner = new Hand(winnerCard, 0);
        var other = new Hand(otherCard, 0);

        _comparerEx.Compare(winner, other).Should().BePositive();
    }

    [Theory]
    [InlineData("AAAAA")]
    [InlineData("AAAA1")]
    [InlineData("AAA11")]
    [InlineData("AAA12")]
    [InlineData("AA113")]
    [InlineData("AQ113")]
    [InlineData("AQK13")]
    public void Given_EqualCards_When_Compared_Then_ShouldBeEqual(string hand)
    {
        var tie = new Hand(hand);
        var other = new Hand(hand);

        // TODO
        //tie.Should().BeRankedEquallyTo(other);
    }

    [Theory]
    [InlineData("AAAAA")]
    [InlineData("AAAA1")]
    [InlineData("AAA11")]
    [InlineData("AAA12")]
    [InlineData("AA113")]
    [InlineData("AQ113")]
    [InlineData("AQK13")]
    [InlineData("JJJJJ")]
    public void Given_EqualCardsEx_When_Compared_Then_ShouldBeEqual(string hand)
    {
        var classifier = new HandWithJokerClassifier();

        var tie = new Hand(hand, 0);
        var other = new Hand(hand, 0);

        // TODO
        //tie.Should().BeRankedEquallyTo(other);
    }
}
