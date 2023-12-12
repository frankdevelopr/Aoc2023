using Aoc2023Day11;
using FluentAssertions;

namespace Aoc2023Day11Test;

public class UniverseNaiveTest
{
    [Theory]
    [InlineData("test.txt", "test-expanded.txt")]
    public void Given_Universe_Then_ExpandedAsExpected(string file, string expandedFile)
    {
        var lines = Read(file);
        var expand = Read(expandedFile);

        var sut = new UniverseNaive(lines);

        var result = sut.Expanded;

        result.Should().BeEquivalentTo(expand);
    }

    [Theory]
    [InlineData("test-1.txt", "test-1-expanded.txt", 10)]
    [InlineData("test-2.txt", "test-2-expanded.txt", 10)]
    public void Given_Universe_Then_ExpandedMultipleAsExpected(string file, string expandedFile, int factor)
    {
        var lines = Read(file);
        var expand = Read(expandedFile);

        var sut = new UniverseNaive(lines, factor);

        var result = sut.Expanded;

        result.Should().BeEquivalentTo(expand);
    }

    [Theory]
    [InlineData("test.txt", 9)]
    public void Given_Universe_Then_GalaxyCountAsExpected(string file, int galaxies)
    {
        var lines = Read(file);

        var sut = new UniverseNaive(lines);

        var result = sut.Galaxies;

        result.Should().HaveCount(galaxies);
    }

    [Theory]
    [InlineData("test.txt", 374)]
    [InlineData("problem.txt", 9403026L)]
    public void Given_Universe_Then_GalaxyDistanceAsExpected(string file, long distance)
    {
        var lines = Read(file);

        var sut = new UniverseNaive(lines);

        var result = sut.ShortestPath;

        result.Should().Be(distance);
    }

    [Theory]
    [InlineData("test.txt", 10, 1030)]
    [InlineData("test.txt", 100, 8410)]
    // [InlineData("test.txt", 1000000, 8410)] --> Out of Memory!
    //[InlineData("problem.txt", 1000000, 9403026L)]
    public void Given_Universe_When_BigExpansion_Then_GalaxyDistanceAsExpected(string file, int expansionFactor, long distance)
    {
        var lines = Read(file);

        var sut = new UniverseNaive(lines, expansionFactor);

        var result = sut.ShortestPath;

        result.Should().Be(distance);
    }

    public static string[] Read(string file)
    {
        return File.ReadAllLines($"data/{file}");
    }
}