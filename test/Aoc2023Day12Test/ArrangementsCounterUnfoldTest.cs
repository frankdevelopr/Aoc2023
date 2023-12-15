using Aoc2023Day12;
using FluentAssertions;

namespace Aoc2023Day12Test;

public class ArrangementsCounterUnfoldTest
{
    [Theory]
    [InlineData("data/test.txt", 525152L)]
    //[InlineData("data/problem.txt", 6488L)]
    public void Given_SpringsList_When_Calculate_Then_ReturnsExpectedNumber(string file, long expectedArrangements)
    {
        var lines = File.ReadAllLines(file);

        var sut = new ArrangementsCounterUnfold(lines);

        sut.Arrangements.Should().Be(expectedArrangements);
    }

    [Theory]
    [InlineData("???.### 1,1,3", 1)]
    [InlineData(".??..??...?##. 1,1,3", 16384)]
    [InlineData("?#?#?#?#?#?#?#? 1,3,1,6", 1)]
    [InlineData("????.#...#... 4,1,1", 16)]
    [InlineData("????.######..#####. 1,6,5", 2500)]
    [InlineData("?###???????? 3,2,1", 506250)]
    public void Given_Line_When_Calculate_Then_ReturnsExpected(string line, long expectedArrangements)
    {
        var sut = new ArrangementsCounterUnfold([line]);

        sut.Arrangements.Should().Be(expectedArrangements);
    }
}
