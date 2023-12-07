using Aoc2023Day7;
using FluentAssertions;

namespace Aoc2023Day7Test;

public class TotalWinningsTest
{
    [Theory]
    [InlineData("test7.txt", 6440)]
    [InlineData("problem7.txt", 248569531L)]
    public void Given_Hands_Then_CalculatesWinnings(string file, long expectedWinnings)
    {
        var classifier = new HandClassifier();

        var lines = File.ReadAllLines($"data/{file}");
        var reader = new HandReader(lines);

        var sut = new TotalWinnigs(reader.Hands, classifier);
        
        sut.Winnings.Should().Be(expectedWinnings);
    }

    [Theory]
    [InlineData("test7.txt", 5905)]
    [InlineData("problem7.txt", 250382098L)]
    public void Given_HandsWithJokerRules_Then_CalculatesWinnings(string file, long expectedWinnings)
    {
        var classifier = new HandWithJokerClassifier();

        var lines = File.ReadAllLines($"data/{file}");
        var reader = new HandReader(lines);

        var sut = new TotalWinnigs(reader.Hands, classifier);

        sut.Winnings.Should().Be(expectedWinnings);
    }
}
