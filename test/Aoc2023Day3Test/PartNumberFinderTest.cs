using Aoc2023Day3;
using FluentAssertions;

namespace Aoc2023Day3Test;

public class PartNumberFinderTest
{
    private readonly PartNumberFinder _sut;

    public PartNumberFinderTest()
    {
        _sut = new PartNumberFinder();
    }

    // prev line including prev char and post char if exists 
    // post line including prev char and post char if exists

    [Theory]
    [InlineData("$111", 111)]
    [InlineData("...$111", 111)]
    [InlineData("2$", 2)]
    [InlineData("2$...", 2)]
    [InlineData("...3*...", 3)]
    public void Given_ValidPartNumber_Then_ItsFound(string partNumber, int expectedValue)
    {
        var result = _sut.Find(partNumber);

        result.Should().ContainSingle();
        result.Single().Value.Should().Be(expectedValue);
    }

    [Theory]
    [MemberData(nameof(MultipleNumbers))]
    public void Given_ValidPartNumbers_Then_AreFound(string partNumber, int[] expectedValues)
    {
        var result = _sut.Find(partNumber);

        result.Should().HaveCount(expectedValues.Length);
        result.Select(r => r.Value).Should().ContainInOrder(expectedValues);
    }

    [Theory]
    [MemberData(nameof(MultipleNumbers))]
    public void Given_ValidPartNumbersEx_Then_AreFound(string partNumber, int[] expectedValues)
    {
        var result = _sut.Find([partNumber]);

        result.Should().HaveCount(expectedValues.Length);
        result.Select(r => r.Value).Should().ContainInOrder(expectedValues);
    }

    [Theory]
    [MemberData(nameof(MultipleLines))]
    public void Given_ValidPartNumbersMultilines_Then_AreFound(string[] lines, int[] expectedValues)
    {
        var result = _sut.Find(lines);

        result.Should().HaveCount(expectedValues.Length);
        result.Select(r => r.Value).Should().ContainInOrder(expectedValues);
    }

    public static TheoryData<string, int[]> MultipleNumbers
    {
        get
        {
            var data = new TheoryData<string, int[]>();

            data.Add("...$111", [111]);
            data.Add("2$", [2]);
            data.Add("2$....", [2]);
            data.Add("...3*...", [3]);
            data.Add("2$1", [2, 1]);
            data.Add("12$13", [12, 13]);
            data.Add("12$13", [12, 13]);
            data.Add("$12.$13", [12, 13]);
            data.Add("1$2$3", [1, 2, 3]);
            data.Add("..1$..2$3..4*", [1, 2, 3, 4]);

            data.Add("101", []);
            data.Add("...133...11", []);
            data.Add("..3...8...", []);
            data.Add("1003...ajsdja.81", []);
            data.Add("1.2..3...4....", []);
            data.Add("5", []);
            data.Add("llll-.18..a", []);

            return data;
        }
    }

    public static TheoryData<string[], int[]> MultipleLines
    {
        get
        {
            var data = new TheoryData<string[], int[]>();

            data.Add(["$...$", ".1.2."], [1, 2]);
            data.Add([".2.3.", "$...$"], [2, 3]);
            data.Add(["4..5", ".$$."], [4, 5]);
            data.Add(["77$88"], [77, 88]);
            data.Add([".2.3.", "..$.."], [2, 3]);

            data.Add([".2.3.", "..3..", "7", "...", "$$$"], []);


            /*data.Add([ ,"...$111"], [111]);
            data.Add("2$", [2]);
            data.Add("2$....", [2]);
            data.Add("...3*...", [3]);
            data.Add("2$1", [2, 1]);
            data.Add("12$13", [12, 13]);
            data.Add("12$13", [12, 13]);
            data.Add("$12.$13", [12, 13]);
            data.Add("1$2$3", [1, 2, 3]);
            data.Add("..1$..2$3..4*", [1, 2, 3, 4]);

            data.Add("101", []);
            data.Add("...133...11", []);
            data.Add("..3...8...", []);
            data.Add("1003...ajsdja.81", []);
            data.Add("1.2..3...4....", []);
            data.Add("5", []);
            data.Add("llll-.18..a", []);*/

            return data;
        }
    }
}
