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
        var games = ReadGames(file);
        var calculator = new GameCalculator(games);

        var result = calculator.PossibleGamesSumId(new CubeSet(12, 13, 14));

        result.Should().Be(expectedIdSum);
    }

    [Theory]
    [InlineData("test2-1.txt", 2286)]
    [InlineData("problem2.txt", 71585)]
    public void Given_TestInput_Then_MinimumPowerSum(string file, int expectedPowerSum)
    {
        var games = ReadGames(file);
        var calculator = new GameCalculator(games);

        var result = calculator.MinimumPowerSum();

        result.Should().Be(expectedPowerSum);
    }

    [Theory]
    [InlineData(3, 4, 5, 60)]
    [InlineData(10, 20, 30, 6000)]
    [InlineData(11, 20, 0, 0)]
    public void Given_GameWithCube_Then_MinimumPowerSum(int red, int green, int blue, int expectedPower)
    {
        var game = new Game(1, new CubeSet(red, green, blue));
        var calculator = new GameCalculator(new[]{ game });

        var result = calculator.MinimumPowerSum();

        result.Should().Be(expectedPower);
    }

    private static IEnumerable<Game> ReadGames(string file)
    {
        var lines = File.ReadAllLines($"data/{file}");
        var parser = new GameParser();
        var games = parser.Parse(lines);

        return games;
    }
}
