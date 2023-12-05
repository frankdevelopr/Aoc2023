using Aoc2023Day4;
using FluentAssertions;

namespace Aoc2023Day4Test;

public class PileOfCardsTests
{
    [Theory]
    [InlineData("test4.txt", 13)]
    [InlineData("problem4.txt", 15268)]
    public void Given_PileOfCards_Then_ScoreIsExpected(string file, int expectedScore)
    {
        var data = File.ReadAllLines($"data/{file}");

        var sut = new PileOfCards(data);

        sut.Score.Should().Be(expectedScore);
    }

    [Theory]
    [InlineData("test4.txt", 30)]
    [InlineData("problem4.txt", 6283755)]
    public void Given_PileOfCards_Then_HowItGrows(string file, int expectCards)
    {
        var data = File.ReadAllLines($"data/{file}");

        var sut = new PileOfCards(data);

        var num = sut.PileUp();

        num.Should().HaveCount(expectCards);
    }
}
