

using System.Collections.Generic;

namespace Aoc2023Day3;

public class GearFinder
{
    private readonly NumberFinder _numberFinder;
    private readonly Symbol _symbol;

    public GearFinder()
    {
        _numberFinder = new NumberFinder();
        _symbol = new Symbol();
    }

    public IEnumerable<Gear> Find(string[] data)
    {
        var allGears = new List<Gear>();

        for (var i = 0; i < data.Length; ++i)
        {
            var line = data[i];
            var prev = i > 0 ? data[i-1] : string.Empty;
            var next = i < data.Length - 1 ? data[i+1] : string.Empty;
            

            allGears.AddRange(Find(line, prev, next));
        }
        
        return allGears;
    }

    public IEnumerable<Gear> Find(string line, string prev, string next)
    {
        var pos = 0;
        var gears = new List<Gear>();

        var currentNumbers = _numberFinder.Find(line);
        var prevNumbers = _numberFinder.Find(prev);
        var nextNumbers = _numberFinder.Find(next);

        for (var i = 0; i < line.Length; ++i)
        {
            if (_symbol.IsGear(line[i]))
            {
                var gear = new Gear(pos);
                gear.LookForAdjacents(currentNumbers, prevNumbers, nextNumbers);

                gears.Add(gear);
            }

            pos++;
        }

        return gears;
    }

    
}
