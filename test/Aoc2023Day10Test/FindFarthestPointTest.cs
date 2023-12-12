using Aoc2023Day10;
using FluentAssertions;

namespace Aoc2023Day10Test;

public class FindFarthestPointTest
{
    [Theory]
    [InlineData("test.txt", 4)]
    [InlineData("test-dirty.txt", 4)]
    [InlineData("test-2.txt", 8)]
    [InlineData("test-2-dirty.txt", 8)]
    [InlineData("problem.txt", 6968L)]
    public void Given_ValidMaps_Returns_ExpectedFarthestPoint(string file, long expectedDistance)
    {
        var lines = Read(file);
        var finder = new FindFarthestPoint(lines);

        finder.Find().Should().Be(expectedDistance);
    }

    public string[] Read(string file)
    {
        return File.ReadAllLines($"data/{file}");
    }
}