﻿using Aoc2023Day16;
using FluentAssertions;

namespace Aoc2023Day16Test;

public class MultiTraversorTest
{
    [Theory]
    [InlineData("data/test.txt", 51)]
    [InlineData("data/problem.txt", 7513L)]
    public void Given_Layout_Then_EnergyWellCalculated(string file, long energized)
    {
        var lines = File.ReadAllLines(file);
        var layout = lines.Select(t => t.ToArray()).ToArray();

        var sut = new MultiTraversor(layout);

        sut.Traverse();

        sut.Energy().Should().Be(energized);
    }
}
