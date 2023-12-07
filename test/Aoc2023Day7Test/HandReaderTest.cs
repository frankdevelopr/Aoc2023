using Aoc2023Day7;
using FluentAssertions;

namespace Aoc2023Day7Test;

public class HandReaderTest
{
    [Fact]
    public void Given_KnownHandsRead_Then_ReturnsExpectedData()
    {
        var lines = File.ReadAllLines("data/test7.txt");

        var sut = new HandReader(lines);
        var hands = sut.Hands;

        var expectedHands = new []
        {
            new Hand("32T3K", 765),
            new Hand("T55J5", 684),
            new Hand("KK677",  28),
            new Hand("KTJJT", 220),
            new Hand("QQQJA", 483)
        };

        hands.Should().BeEquivalentTo(expectedHands);
        hands.Select(t => t.Cards).Should().ContainInOrder(expectedHands.Select(t => t.Cards));
    }
}
