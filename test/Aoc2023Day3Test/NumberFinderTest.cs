using Aoc2023Day3;
using FluentAssertions;

namespace Aoc2023Day3Test;

public class NumberFinderTest
{
    private readonly NumberFinder _sut;

    public NumberFinderTest()
    {
        _sut = new NumberFinder();
    }

    [Theory]
    [InlineData("101", 101)]
    [InlineData("928", 928)]
    public void Given_ValidNumber_Then_ItsFound(string line, int expectedNum)
    {
        var result = _sut.Find(line);

        result.Should().ContainSingle(s => s.Value == expectedNum);
    }

    [Theory]
    [InlineData("101..---", 101)]
    [InlineData(".-akjj928aaaa", 928)]
    public void Given_ValidNumberWithNoise_Then_ItsFound(string line, int expectedNum)
    {
        var result = _sut.Find(line);

        result.Should().ContainSingle(s => s.Value == expectedNum);
    }

    [Theory]
    [InlineData("...")]
    [InlineData("lololo")]
    public void Given_NoNumber_Then_Zero(string line)
    {
        var result = _sut.Find(line);

        result.Should().BeEmpty();
    }

    [Theory]
    [MemberData(nameof(MultipleNumbers))]
    public void Given_SeveralNumbers_Then_AreFound(string line, int[] expectedData)
    {
        var result = _sut.Find(line);

        result.Should().HaveCount(expectedData.Length);
        result.Select(r => r.Value).Should().ContainInOrder(expectedData);
    }

    public static TheoryData<string, int[]> MultipleNumbers
    {
        get
        {
            var data = new TheoryData<string, int[]>();

            data.Add("101", [101]);
            data.Add("...133...11", [133, 11]);
            data.Add("..3...8...", [3, 8]);
            data.Add("1003...ajsdja.81", [1003, 81]);
            data.Add("1.2..3...4....", [1, 2, 3, 4]);
            data.Add("5", [5]);
            data.Add("llll-.18..a", [18]);

            return data;
        }
    }
}
