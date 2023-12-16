using Aoc2023Day14;
using FluentAssertions;

namespace Aoc2023Day14Test;

public class PlatformTiltTest
{
    [Theory]
    [InlineData("data/test-easy-tilt.txt", "data/test-easy-tilt-expected.txt")]
    [InlineData("data/test-tilt.txt", "data/test-tilt-expected.txt")]
    public void Given_Platform_When_TiltNorth_Then_ReturnExpectedPlatform(string file, string expectedFile)
    {
        var platform = File.ReadAllLines(file);
        var expected = File.ReadAllLines(expectedFile);

        var sut = new PlatformTilt(platform.Select(p => p.ToArray()));
        sut.TiltNorth();

        sut.Platform.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData("data/test.txt", 1, "data/test-1cycle.txt")]
    [InlineData("data/test.txt", 2, "data/test-2cycles.txt")]
    [InlineData("data/test.txt", 3, "data/test-3cycles.txt")]
    public void Given_Platform_When_Cycled_Then_ReturnExpectedPlatform(string file, long cycles, string expectedFile)
    {
        var platform = File.ReadAllLines(file);
        var expected = File.ReadAllLines(expectedFile);

        var sut = new PlatformTilt(platform.Select(p => p.ToArray()));
        sut.Cycle(cycles);

        sut.Platform.Should().BeEquivalentTo(expected);
    }
}
