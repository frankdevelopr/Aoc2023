using Aoc2023Day18;
using FluentAssertions;

namespace Aoc2023Day18Test;

public class TrenchTest
{
    [Theory]
    [InlineData("data/test.txt", 38)]
    [InlineData("data/test-differentStart.txt", 38)]
    [InlineData("data/problem.txt", 3568L)]

    public void Given_ValidTrenchInstructions_Then_PerimeterSizeIsWellCalculated(string file, long perimeter)
    {
        var lines = File.ReadAllLines(file);

        var sut = new Trench(new TrenchSize(lines));

        sut.Perimeter.Should().Be(perimeter);
    }

    [Theory]
    [InlineData("data/test.txt", "data/test-perimeter.txt")]
    [InlineData("data/test-differentStart.txt", "data/test-perimeter.txt")]
    [InlineData("data/problem.txt", "data/problem-perimeter.txt")]
    public void Given_ValidTrenchInstructions_Then_TrenchIsWellCalculated(string file, string perimeter)
    {
        var lines = File.ReadAllLines(file);

        var sut = new Trench(new TrenchSize(lines));

        var painted = File.ReadAllText(perimeter);

        sut.Paint().Should().BeEquivalentTo(painted);
    }
}