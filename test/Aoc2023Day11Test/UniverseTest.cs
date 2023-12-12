using Aoc2023Day11;
using FluentAssertions;

namespace Aoc2023Day11Test;

public class UniverseTest
{
    [Theory]
    [InlineData("test.txt", "test-expanded.txt", Skip = "Doesn't make sense with new implementation")]
    public void Given_Universe_Then_ExpandedAsExpected(string file, string expandedFile)
    {
        var lines = Read(file);
        var expand = Read(expandedFile);

        var sut = new Universe(lines);

        var result = sut.Map;

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

    //Between galaxy 1 and galaxy 7: 15
    //Between galaxy 3 and galaxy 6: 17
    //Between galaxy 8 and galaxy 9: 5
    [Theory]
    [InlineData("test.txt", 1, 7, 15)]
    [InlineData("test.txt", 3, 6, 17)]
    [InlineData("test.txt", 8, 9, 5)]
    public void Given_Galaxies_When_Distance_Then_ReturnsExpectedValue(string file, int galaxyFrom, int galaxyTo, long expectedDistance)
    {
        var lines = Read(file);

        var sut = new Universe(lines);

        var distance = sut.DistanceBetween(galaxyFrom, galaxyTo);

        distance.Should().Be(expectedDistance);
    }

    [Theory]
    [InlineData("test-1.txt", 3)]
    [InlineData("test-2.txt", 4)]
    [InlineData("test.txt", 374)]
    [InlineData("problem.txt", 9403026L)]
    public void Given_Universe_Then_GalaxyDistanceAsExpected(string file, long distance)
    {
        var lines = Read(file);

        var sut = new Universe(lines);

        var result = sut.ShortestPath;

        result.Should().Be(distance);
    }

    [Theory]
    [InlineData("test.txt", 10, 1030)]
    [InlineData("test.txt", 100, 8410)]
    [InlineData("test.txt", 1000000, 82000210L)]
    [InlineData("problem.txt", 1000000, 543018317006L)]
    public void Given_Universe_When_BigExpansion_Then_GalaxyDistanceAsExpected(string file, int expansionFactor, long distance)
    {
        var lines = Read(file);

        var sut = new Universe(lines, expansionFactor);

        var result = sut.ShortestPath;

        result.Should().Be(distance);
    }

    public static string[] Read(string file)
    {
        return File.ReadAllLines($"data/{file}");
    }
}