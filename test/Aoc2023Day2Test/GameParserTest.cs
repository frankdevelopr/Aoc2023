
using Aoc2023Day2;
using FluentAssertions;

namespace Aoc2023Day2Test;

public class GameParserTest
{
    [Theory]
    [InlineData("test2-1.txt")]
    public void Given_Lines_Then_ReturnsGames(string file)
    {
        var lines = File.ReadAllLines($"data/{file}");

        var sut = new GameParser();

        var games = sut.Parse(lines);

        games.Should().HaveCount(5);
        games.Should().BeEquivalentTo(
            new[] {
                new Game(1, new CubeSet(4, 2, 6)),
                new Game(2, new CubeSet(1, 3, 4)),
                new Game(3, new CubeSet(20, 13, 6)),
                new Game(4, new CubeSet(14, 3, 15)),
                new Game(5, new CubeSet(6, 3, 2))
            });
    }

    [Theory]
    [InlineData("Game 1: 3 blue, 4 red")]
    public void Given_ValidLine_Then_ReturnsGameParsed(string line)
    {
        var sut = new GameParser();

        var game = sut.ParseLine(line);

        game.Id.Should().Be(1);

        game.AcceptedCubeSet.Should().BeEquivalentTo(new CubeSet(4, 0, 3));
    }

    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green")]
    public void Given_ValidMultipleLine_Then_ReturnsGameParsed(string line)
    {
        var sut = new GameParser();

        var game = sut.ParseLine(line);

        game.Id.Should().Be(1);
        game.AcceptedCubeSet.Should().BeEquivalentTo(new CubeSet(4, 2, 6));
    }
}