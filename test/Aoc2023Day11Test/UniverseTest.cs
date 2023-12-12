using Aoc2023Day11;
using FluentAssertions;

namespace Aoc2023Day11Test;

public class UniverseTest
{
    [Theory]
    [InlineData("test.txt", "test-expanded.txt")]
    public void Given_Universe_Then_ExpandedAsExpected(string file, string expandedFile)
    {
        var lines = Read(file);
        var expand = Read(expandedFile);

        var sut = new Universe(lines);

        var result = sut.Expanded;

        result.Should().BeEquivalentTo(expand);
    }

    [Theory]
    [InlineData("test.txt", 9)]
    public void Given_Universe_Then_GalaxyCountAsExpected(string file, int galaxies)
    {
        var lines = Read(file);

        var sut = new Universe(lines);

        var result = sut.Galaxies;

        result.Should().HaveCount(galaxies);
    }

    [Theory]
    [InlineData("test.txt", 374)]
    [InlineData("problem.txt", 9403026L)]
    public void Given_Universe_Then_GalaxyDistanceAsExpected(string file, long distance)
    {
        var lines = Read(file);

        var sut = new Universe(lines);

        var result = sut.ShortestPath;

        result.Should().Be(distance);
    }

    public static string[] Read(string file)
    {
        return File.ReadAllLines($"data/{file}");
    }
}