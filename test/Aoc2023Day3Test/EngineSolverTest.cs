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
    [InlineData("test3", 4361)]
    public void Given_FileWithEngineSchema_When_Parsed_ReturnSumOfItsParts(string file, int expectedValue)
    {
        var result = _sut.Solve();

        result.Should().Be(expectedValue);
    }
}