﻿using Aoc2023Day10;
using FluentAssertions;

namespace Aoc2023Day10Test;

public class MapTest
{
    [Theory]
    [InlineData("test.txt", 1, 1)]
    [InlineData("test-2.txt", 0, 2)]
    public void Given_ValidMap_When_QueryingStartingPoint_Then_ReturnsItsCoordinates(string file, int x, int y)
    {
        var lines = Read(file);

        var map = new Map(lines);

        map.StartPosition.Should().BeEquivalentTo(new Position(x, y));
    }

    [Theory]
    [InlineData("test.txt", 8)]
    [InlineData("test-2.txt", 16)]
    [InlineData("problem.txt", 13936L)]
    public void Given_ValidMap_When_Navigating_Then_ReturnsAllStepes(string file, int steps)
    {
        var lines = Read(file);

        var map = new Map(lines);

        map.Steps.Should().Be(steps);
    }

    public string[] Read(string file)
    {
        return File.ReadAllLines($"data/{file}");
    }
}
