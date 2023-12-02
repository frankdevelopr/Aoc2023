using Aoc2023Day2;
using FluentAssertions;

namespace Aoc2023Day2Test;

public class GameCalculatorTests
{
    [Theory]
    [InlineData("test2-1.txt", 8)]
    [InlineData("problem2.txt", 2331)]
    public void Given_TestInput_Then_Returns8(string file, int expectedIdSum)
    {
        var lines = File.ReadAllLines($"data/{file}");
        var parser = new GameParser();
        var games = parser.Parse(lines);

        var calculator = new GameCalculator(games);

        var result = calculator.PossibleGamesSumId(new CubeSet(12, 13, 14));

        result.Should().Be(expectedIdSum);
    }
}
