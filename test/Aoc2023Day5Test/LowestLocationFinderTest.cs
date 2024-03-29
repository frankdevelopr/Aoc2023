﻿using Aoc2023Day5;
using FluentAssertions;

namespace Aoc2023Day5Test;

public class LowestLocationFinderTest
{
    [Theory]
    [InlineData("test5.txt", 35)]
    [InlineData("problem5.txt", 836040384)]

    public void Given_ValidMap_Then_ReturnsLowestLocation(string file, long expectedLocation)
    {
        var lines = ReadFile(file);

        var mapReader = new MapReader(lines);

        var sut = new LowestLocationFinder(mapReader.Map);

        sut.FindLowestLocation().Should().Be(expectedLocation);
    }

    [Theory]
    [InlineData("test5.txt", 46)]
    [InlineData("problem5.txt", 10834440)]
    public void Given_ValidMapEx_Then_ReturnsLowestLocation(string file, long expectedLocation)
    {
        var lines = ReadFile(file);

        var mapReader = new MapReader(lines);

        var sut = new LowestLocationFinder(mapReader.Map);

        sut.FindLowestLocationRange().Should().Be(expectedLocation);
    }


    private string[] ReadFile(string fileName)
    {
        var lines = File.ReadAllLines($"data/{fileName}");

        return lines;
    }
}
