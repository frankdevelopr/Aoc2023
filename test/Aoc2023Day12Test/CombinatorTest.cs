using Aoc2023Day12;
using FluentAssertions;

namespace Aoc2023Day12Test;

public class CombinatorTest
{
    [Theory]
    [InlineData("ABC", 2, 3)]   // AB, AC, BC
    [InlineData("ABC", 3, 1)]
    [InlineData("ABCD", 2, 6)]
    public void Given_Combinations(string input, int groupSize, long expectedValue)
    {
        var sut = new Combinator<char>(input.ToArray(), groupSize);

        sut.Combinations().Should().Be(expectedValue);
    }

    [Theory]
    [InlineData("ABC", 2, "AB,AC,BC")]
    [InlineData("ABC", 3, "ABC")]
    [InlineData("ABCD", 2, "AB,AC,AD,BC,BD,CD")]
    [InlineData("ABCD", 1, "A,B,C,D")]
    [InlineData("ABCDE", 2, "AB,AC,AD,AE,BC,BD,BE,CD,CE,DE")]
    [InlineData("ABCDE", 3, "ABC,ABD,ABE,ACD,ACE,ADE,BCD,BCE,BDE,CDE")]
    [InlineData("ABCDE", 4, "ABCD,ABCE,ABDE,ACDE,BCDE")]

    public void Given_Expected(string input, int group, string output)
    {
        var sut = new Combinator<char>(input.ToArray(), group);

        var result = sut.Combine();

        var combs = string.Join(',', result.Select(t => new string(t.ToArray())));

        combs.Should().Be(output);
    }
}
