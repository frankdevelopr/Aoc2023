using Aoc2023Day4;
using FluentAssertions;

namespace Aoc2023Day4Test;

public class CardTests
{
    private readonly Card _sut;

    public CardTests()
    {
        _sut = new Card(1, [1, 2, 3, 4, 5]);
    }

    [Theory]
    [MemberData(nameof(MultipleWins))]
    public void Given_WinningNumbers_Then_ReturnsDoubleValueForEachFind(int[] numbers, int expectedScore)
    {
        var result = _sut.Score(numbers);

        result.Should().Be(expectedScore);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(4)]
    public void Given_SingleWinningNumber_Then_ReturnsOne(int number)
    {
        var result = _sut.Score([number]);

        result.Should().Be(1);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(33)]
    public void Given_NoWinningNumbers_Then_ReturnsZero(int number)
    {
        var result = _sut.Score([number]);

        result.Should().Be(0);
    }

    public static TheoryData<int[], int> MultipleWins
    {
        get
        {
            var data = new TheoryData<int[], int>();

            data.Add([1], 1);
            data.Add([1, 5], 2);
            data.Add([1, 3, 5], 4);
            data.Add([1, 3, 5, 9, 0], 4);
            data.Add([1, 2, 3, 4, 0, 19], 8);
            data.Add([5, 1, 2, 3, 4, 0, 19], 16);

            return data;
        }
    }

}