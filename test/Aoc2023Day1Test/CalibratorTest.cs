using Aoc2023Day1;
using FluentAssertions;

namespace Aoc2023Day1Test;

public class CalibratorTest
{
    [Theory]
    [InlineData("test1.txt", 142)]
    [InlineData("problem1.txt", 53334)]
    public void Given_FirstCalibratorVersion_Returns_ExpectedNumber(string file, int expectedNumber)
    {
        var sut = new Calibrator();

        var lines = File.ReadAllLines($"./data/{file}");

        var result = sut.Calibrate(lines);

        result.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("test2.txt", 281)]
    public void Given_SecondCalibratorVersion_Returns_ExpectedNumber(string file, int expectedNumber)
    {
        var sut = new Calibrator();

        var lines = File.ReadAllLines($"./data/{file}");

        var result = sut.Calibrate(lines);

        result.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("two1nine", 29)]
    [InlineData("eightwothree", 83)]
    [InlineData("abcone2threexyz", 13)]
    public void Given_SecondCalibratorVersion_When_GivenLine_Returns_ExpectedNumber(string line, int expectedNumber)
    {
        var sut = new Calibrator();

        var result = sut.Calibrate([line]);

        result.Should().Be(expectedNumber);
    }

}
