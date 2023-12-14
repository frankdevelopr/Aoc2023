using Aoc2023Day13;
using FluentAssertions;

namespace Aoc2023Day13Test;

public class MirrorFinderTest
{
    [Fact]
    public void Given_PatternWithVerticalMirror_Then_FindsMirror()
    {
        const string pattern = """
            #.##..##.
            ..#.##.#.
            ##......#
            ##......#
            ..#.##.#.
            ..##..##.
            #.#.##.#.
            """;

        var inlines = pattern.Split(Environment.NewLine);

        var sut = new MirrorFinder(inlines);

        sut.Find().Should().Be(5);
    }

    [Fact]
    public void Given_PatternWithHorizontalMirror_Then_FindsMirror()
    {
        const string pattern = """
            #...##..#
            #....#..#
            ..##..###
            #####.##.
            #####.##.
            ..##..###
            #....#..#
            """;

        var inlines = pattern.Split(Environment.NewLine);

        var sut = new MirrorFinder(inlines);

        sut.Find().Should().Be(400);
    }
}
