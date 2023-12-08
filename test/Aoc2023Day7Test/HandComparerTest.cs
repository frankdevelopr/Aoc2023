using Aoc2023Day7;
using FluentAssertions;

namespace Aoc2023Day7Test;

public class HandComparerTest
{
    private readonly HandComparer _sut;

    public HandComparerTest()
    {
        _sut = new HandComparer(new HandWithJokerClassifier());
    }

    [Fact]
    public void Given_Ties_Then_JsAreWeaker()
    {
        var hand = new Hand("JKKK2", 0);
        var other = new Hand("QQQQ2", 0);

        _sut.Compare(hand, other).Should().BeNegative();
    }
}
