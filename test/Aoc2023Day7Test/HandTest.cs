using Aoc2023Day7;
using FluentAssertions;

namespace Aoc2023Day7Test;

public class HandTest
{
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

        winner.Should().BeGreaterThan(other);
    }

    [Theory]
    [InlineData("AAAA1", "QQQQ1")]
    [InlineData("QQQQ1", "1AAAA")]
    [InlineData("TTT21", "1AAA2")]
    public void Given_CardTiesOfType_When_Compared_Then_ShouldBeBiggerCard(string winnerCard, string otherCard)
    {
        var winner = new Hand(winnerCard);
        var other = new Hand(otherCard);

        winner.Should().BeGreaterThan(other);
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

        tie.Should().BeRankedEquallyTo(other);
    }

}
