using Aoc2023Day3;
using FluentAssertions;

namespace Aoc2023Day3Test;

public class EngineSolverTest
{
    private readonly EngineSolver _sut;

    public EngineSolverTest()
    {
        _sut = new EngineSolver();
    }

    [Theory]
    [InlineData("test3.txt", 4361)]
    [InlineData("problem3.txt", 521515)]
    public void Given_FileWithEngineSchema_When_Parsed_Then_ReturnSumOfItsParts(string file, int expectedValue)
    {
        var data = File.ReadAllLines($"data/{file}");

        var result = _sut.Solve(data);

        result.Should().Be(expectedValue);
    }

    [Theory]
    [InlineData("test3-gears.txt", 467835)]
    [InlineData("problem3.txt", 69527306L)]
    public void Given_Gears_Then_ReturnsExpectedRatio(string file, long expectedValue)
    {
        var data = File.ReadAllLines($"data/{file}");

        var result = _sut.GearsRatio(data);

        result.Should().Be(expectedValue);
    }

    [Theory]
    [InlineData("problem3.txt")]
    public void GetSymbols(string file)
    {
        var data = File.ReadAllLines($"data/{file}");
        var set = new HashSet<string>();

        foreach (var line in data)
        {
            foreach (var c in line)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    set.Add(c.ToString());
                }
            }
        }

        var all = string.Join("", set);
    }

}