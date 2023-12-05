using Aoc2023Day4;
using FluentAssertions;

namespace Aoc2023Day4Test;

public class CardTests
{
    [Theory]
    [MemberData(nameof(MultipleWins))]
    public void Given_WinningNumbers_Then_ReturnsDoubleValueForEachFind(int[] numbers, int expectedScore, int expectedMatchings)
    {
        var sut = new Card(1, [1, 2, 3, 4, 5], numbers);

        sut.Score.Should().Be(expectedScore);
        sut.MatchingNumbers.Should().Be(expectedMatchings);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(4)]
    public void Given_SingleWinningNumber_Then_ReturnsOne(int number)
    {
        var sut = new Card(1, [1, 2, 3, 4, 5], [number]);

        var result = sut.Score;

        result.Should().Be(1);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(33)]
    public void Given_NoWinningNumbers_Then_ReturnsZero(int number)
    {
        var sut = new Card(1, [1, 2, 3, 4, 5], [number]);

        var result = sut.Score;

        result.Should().Be(0);
    }

    public static TheoryData<int[], int, int> MultipleWins
    {
        get
        {
            var data = new TheoryData<int[], int, int>
            {
                { [1], 1, 1},
                { [1, 5], 2, 2 },
                { [1, 3, 5], 4, 3 },
                { [1, 3, 5, 9, 0], 4, 3 },
                { [1, 2, 3, 4, 0, 19], 8, 4 },
                { [5, 1, 2, 3, 4, 0, 19], 16, 5 }
            };

            return data;
        }
    }
}