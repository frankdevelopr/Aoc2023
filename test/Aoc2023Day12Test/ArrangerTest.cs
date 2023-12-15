using Aoc2023Day12;
using FluentAssertions;
using System.Text;

namespace Aoc2023Day12Test;

public class ArrangerTest
{
    [Theory]
    [MemberData(nameof(SpringTestData))]
    public void Given_Then_Ok(string springs, int[] groups, int expectedArrangements)
    {
        var sut = new Arranger();

        var evaluate = sut.Evaluate(springs, groups.ToList());

        evaluate.Should().Be(expectedArrangements);
    }

    public static TheoryData<string, int[], int> SpringTestData
    {
        get
        {
            var data = new TheoryData<string, int[], int>();

            data.Add("???.###", [1,1,3], 1);
            data.Add(".??..??...?##.", [1, 1, 3], 4);
            data.Add("?#?#?#?#?#?#?#?", [1,3,1,6], 1);
            data.Add("????.#...#...", [4,1,1], 1);
            data.Add("????.######..#####.", [1,6,5], 4);
            data.Add("?###????????", [3,2,1], 10);

            data.Add("???.###????.###????.###????.###????.###", [1,1,3,1,1,3,1,1,3,1,1,3,1,1,3], 1);
            data.Add(".??..??...?##.?.??..??...?##.?.??..??...?##.?.??..??...?##.?.??..??...?##.", [1,1,3,1,1,3,1,1,3,1,1,3,1,1,3], 16384);

            return data;
        }
    }

}

