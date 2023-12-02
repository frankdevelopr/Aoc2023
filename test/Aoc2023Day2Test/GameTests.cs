using Aoc2023Day2;
using FluentAssertions;

namespace Aoc2023Day2Test;

public class GameTests
{
    private readonly Game _sut;

    public GameTests()
	{
		_sut = new Game();
	}

	[Fact]
	public void Given_NewGame_Then_CubeSetAcceptedIsZeroed()
	{
		_sut.AcceptedCubeSet.Should().BeEquivalentTo(new CubeSet());
	}

	[Fact]
	public void Given_AddedCubeSet_Then_BecomesAccepted()
	{
		var cubeSet = new CubeSet(7, 8, 9);

		_sut.Add(cubeSet);

		_sut.AcceptedCubeSet.Should().BeEquivalentTo(cubeSet);
	}

	[Fact]
	public void Given_AddingSeveralCubeSets_Then_AcceptedIsTheMax()
	{
		var expectedCubeSet = new CubeSet(7, 8, 9);

		_sut.Add(new CubeSet(2, 3, 9));
		_sut.Add(new CubeSet(7, 0, 1));
		_sut.Add(new CubeSet(2, 8, 3));

		_sut.AcceptedCubeSet.Should().BeEquivalentTo(expectedCubeSet);
	}
}
