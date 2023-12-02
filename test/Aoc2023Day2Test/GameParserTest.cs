
using Aoc2023Day2;

namespace Aoc2023Day2Test;

public class GameParserTest
{
    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green")]
    public void Given_ValidLine_Then_ReturnsGameParsed(string line)
    {
        var sut = new GameParser();

        var game = sut.ParseLine(line);

    }

}