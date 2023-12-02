
namespace Aoc2023Day2;

public class GameParser
{
    public IEnumerable<Game> Parse(IEnumerable<string> lines)
    {
        var games = new List<Game>();

        foreach (var line in lines)
        {
            games.Add(ParseLine(line));
        }

        return games;
    }

    public Game ParseLine(string line)
    {
        var game = new Game();

        var parts = line.Split(":");
        var numberPart = parts[0].Split(" ");

        game.Id = int.Parse(numberPart[1]);

        var cubeSets = parts[1].Split(";");

        foreach (var cubeSet in cubeSets)
        {
            game.Add(ParseCubeSet(cubeSet));
        }

        return game;
    }

    private CubeSet ParseCubeSet(string cubeSet)
    {
        var cube = new CubeSet();

        var colors = cubeSet.Split(',');

        foreach (var color in colors)
        {
            var trimmed = color.Trim();

            var colorValues = trimmed.Split(" ");

            var colorName = colorValues[1];
            var colorValue = colorValues[0];

            if (colorName == "red")
            {
                cube.Red = int.Parse(colorValue);
            }

            if (colorName == "green")
            {
                cube.Green = int.Parse(colorValue);
            }

            if (colorName == "blue")
            {
                cube.Blue = int.Parse(colorValue);
            }
        }

        return cube;

    }
}
