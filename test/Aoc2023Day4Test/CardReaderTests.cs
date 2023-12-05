using Aoc2023Day4;
using FluentAssertions;

namespace Aoc2023Day4Test;

public class CardReaderTests
{
    private readonly CardReader _sut;

    public CardReaderTests()
    {
        _sut = new CardReader();
    }

    [Theory]
    [MemberData(nameof(MultiCards))]
    public void Given_MultipleCards_Then_AllReturned(string[] lines, int[] ids, int[] scores)
    {
        var cards = _sut.Read(lines);

        cards.Select(c =>  c.Id).Should().BeEquivalentTo(ids);
        cards.Select(c =>  c.Score).Should().BeEquivalentTo(scores);
    }

    [Theory]
    [InlineData("Card 1: 1 | 1", 1, 1)]
    [InlineData("Card 2: 3 2 11 | 99 2 3", 2, 2)]
    [InlineData("Card 3: 1 2 11 4 1928 | 97 1 2 11", 3, 4)]
    public void Given_ValidSingleCard_Then_ReturnsExpectedCard(string line, int cardNo, int expectedScore)
    {
        var cards = _sut.Read([line]).ToList();

        cards.Should().ContainSingle();

        var card = cards.Single();
        card.Id.Should().Be(cardNo);
        card.Score.Should().Be(expectedScore);
    }

    [Theory]
    [InlineData("")]
    [InlineData("Bla bla bla")]
    public void Given_NoValidCard_Then_ReturnsEmptyList(string noCard)
    {
        var cards = _sut.Read([noCard]);

        cards.Should().BeEmpty();
    }

    public static TheoryData<string[], int[], int[]> MultiCards
    {
        get
        {
            var data = new TheoryData<string[], int[], int[]>();

            data.Add(["Card 1: 1 | 1", "Card 2: 3 2 11 | 99 2 3", "Card 3: 1 2 11 4 1928 | 97 1 2 11"], [1, 2, 3], [1, 2, 4]);
            data.Add(["1", "Card 2: 3 2 11 99 2 3", ""], [], []);
            data.Add(["1", "Card 2: 3 2 11 99 2 3 | 88", ""], [2], [0]);

            return data;
        }
    }
}
