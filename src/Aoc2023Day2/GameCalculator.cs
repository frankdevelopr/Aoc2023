using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2023Day2;

public class GameCalculator
{
    private readonly IEnumerable<Game> _games;

    public GameCalculator(IEnumerable<Game> games)
	{
		_games = games;
	}

    public int PossibleGamesSumId(CubeSet set)
    {
        var possible = _games.Where(g => g.AcceptedCubeSet.FitsIn(set));

        return possible.Sum(t => t.Id);
    }

    public int MinimumPowerSum()
    {
        var power = 0;

        foreach (var game in _games) 
        {
            var cube = game.AcceptedCubeSet;
            power += cube.Red * cube.Green * cube.Blue;
        }

        return power;
    }

}
