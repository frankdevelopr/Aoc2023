using Aoc2023Day18;
using FluentAssertions;

namespace Aoc2023Day18Test;

public class TrenchSizeTest
{
    [Theory]
    [InlineData("data/test.txt", 10, 7, 0, 0)]
    [InlineData("data/test-differentStart.txt", 10, 7, 7, 1)]
    [InlineData("data/test-2.txt", 6, 7, 5, 6)]
    [InlineData("data/test-3.txt", 6, 11, 5, 8)]
    public void Given_ValidTrenchInstructions_Then_SizesAreWellCalculated(string file, int height, int width, int y, int x)
    {
        var lines = File.ReadAllLines(file);

        var sut = new TrenchSize(lines);
        sut.Height.Should().Be(height);
        sut.Width.Should().Be(width);

        sut.InitialPosition.Should().BeEquivalentTo(new Position(y, x));
    }
}
