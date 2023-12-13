using Aoc2023Day12;
using FluentAssertions;

namespace Aoc2023Day12Test;

public class SpringsGeneratorTest
{
    [Fact]
    public void Given_ValidDigits_Then_ReturnsSprings()
    {
        var sut = new SpringsGenerator();

        var combinations = sut.Combinations(2).ToList();

        combinations.Should().BeEquivalentTo(["..", ".#", "#.", "##"]);
    }
}
