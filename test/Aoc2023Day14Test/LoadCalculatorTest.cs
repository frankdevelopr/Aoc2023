using Aoc2023Day14;
using FluentAssertions;

namespace Aoc2023Day14Test;

public class LoadCalculatorTest
{
    [Theory]
    [InlineData("data/test-load.txt", 136)]
    public void Given_ValidPlatform_Then_ReturnsExpectedLoad(string file, long expectedLoad)
    {
        var lines = File.ReadAllLines(file);

        var sut = new LoadCalculator(lines);

        sut.Calculate().Should().Be(expectedLoad);
    }
}
