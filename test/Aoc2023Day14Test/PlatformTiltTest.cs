using Aoc2023Day14;
using FluentAssertions;

namespace Aoc2023Day14Test;

public class PlatformTiltTest
{
    [Theory]
    [InlineData("data/test-easy-tilt.txt", "data/test-easy-tilt-expected.txt")]
    [InlineData("data/test-tilt.txt", "data/test-tilt-expected.txt")]
    public void Given_Platform_When_TiltNorht_Then_ReturnExpectedPlatform(string file, string expectedFile)
    {
        var platform = File.ReadAllLines(file);
        var expected = File.ReadAllLines(expectedFile);

        var sut = new PlatformTilt(platform.Select(p => p.ToArray()));
        var result = sut.TiltNorth();

        result.Should().BeEquivalentTo(expected);
    }
}
