
namespace Aoc2023Day8;

public class PathFinder
{
    private readonly Navigator _navigator;
    private readonly Network _network;

    public int Steps { get; }

    public PathFinder(Navigator navigator, Network network)
    {
        _navigator = navigator;
        _network = network;

        Steps = Find("AAA", "ZZZ");
    }

    private int Find(string nodeStart, string nodeEnd)
    {
        var current = _network.Get(nodeStart);
        var steps = 0;

        while (current?.Label != nodeEnd)
        {
            var direction = _navigator.Next();
            var next = "";

            if (direction == Direction.Left)
            {
                next = current?.Left;
            }
            else
            {
                next = current?.Right;
            }

            current = _network.Get(next);
            steps++;
        }

        return steps;
    }
}
