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

    [Fact]
    public void Given_SmudgePatternMirror_Then_FindsMirror()
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

        sut.FindSmudge().Should().Be(300);
    }

    [Fact]
    public void Given_SmudgePatternWithHorizontalMirror_Then_FindsMirror()
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

        sut.FindSmudge().Should().Be(100);
    }

    [Fact]
    public void Given_SmudgePatternWithHorizontalMirror_Then_FindsMirror2()
    {
        const string pattern = """
            ##..#.##..###
            ....##...#.##
            ##.....##..##
            ...#..##..###
            ####..##..#..
            ..##..##.#.#.
            ...##.#...###
            """;

        var inlines = pattern.Split(Environment.NewLine);

        var sut = new MirrorFinder(inlines);

        sut.FindSmudge().Should().NotBe(1);
    }

    [Fact]
    public void Given_SmudgePatternWithHorizontalMirror_Then_FindsMirror3()
    {
        const string pattern = """
            #.##..#.##.
            ###.#....##
            .#.##..####
            .#.#.......
            #..#..##..#
            #..#..##..#
            .#.#.......
            .#.##..####
            ###.#....##
            #.##..#.##.
            .#.####..#.
            #.#####.###
            #.#####.###
            .#.####..#.
            #.##..#.#..
            """;

        var inlines = pattern.Split(Environment.NewLine);

        var sut = new MirrorFinder(inlines);

        sut.FindSmudge().Should().NotBe(0);
    }
}
