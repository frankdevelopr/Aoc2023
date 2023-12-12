using System.Collections.Concurrent;

namespace Aoc2023Day8;

public class PathFinder
{
    private readonly Navigator _navigator;
    private readonly Network _network;

    public PathFinder(Navigator navigator, Network network)
    {
        _navigator = navigator;
        _network = network;
    }

    public int Find()
    {
        return Find("AAA", "ZZZ");
    }

    public long FindMultiple()
    {
        var currents = _network.StartingNodes().ToArray();
        var steps = 0L;

        while (!_network.AreAllEnding(currents))
        {
            var direction = _navigator.Next();
            currents = MoveNodes(currents, direction);
            steps++;

            
            if (steps % 10_000_000 == 0)
            {
                Console.WriteLine($"Steps taken so far {steps}");
            }
        }

        return steps;
    }

    public long FindMultipleLcm()
    {
        var currents = _network.StartingNodes().ToList();
        var steps = 0L;
        var allSteps = new List<long>();

        for (var i = 0; i < currents.Count; ++i)
        {
            _navigator.Reset();
            steps = 0L;

            while (!_network.AreAllEnding([currents[i]]))
            {
                var direction = _navigator.Next();
                currents[i] = MoveNext(currents[i], direction);
                steps++;
            }

            allSteps.Add(steps);
        }

        var lcm = allSteps[0];

        for (var i = 1; i < allSteps.Count; ++i)
        {
            lcm = DetermineLCM(lcm, allSteps[i]);
        }

        return lcm;
    }

    public static long DetermineLCM(long a, long b)
    {
        long num1, num2;
        if (a > b)
        {
            num1 = a; num2 = b;
        }
        else
        {
            num1 = b; num2 = a;
        }

        for (int i = 1; i < num2; i++)
        {
            long mult = num1 * i;
            if (mult % num2 == 0)
            {
                return mult;
            }
        }

        return num1 * num2;
    }

    private int Find(string nodeStart, string nodeEnd)
    {
        var current = _network.Get(nodeStart);
        var steps = 0;

        while (current?.Label != nodeEnd)
        {
            var direction = _navigator.Next();
            current = MoveNext(current, direction);

            steps++;
        }

        return steps;
    }

    private Node[] MoveNodes(Node[] currents, Direction direction)
    {
        //var next = new List<Node>();

        for (var i = 0; i < currents.Length; ++i)
        {
            currents[i] = MoveNext(currents[i], direction);
            //next.Add(MoveNext(current, direction));
        }

        return currents;
    }
    
    // TODO: Much slower
    private IEnumerable<Node> MoveNodesEx(IEnumerable<Node> currents, Direction direction)
    {
        var next = new ConcurrentBag<Node>();

        Parallel.ForEach(currents, current =>
        {
             next.Add(MoveNext(current, direction));
        });

        return next;
    }

    private Node? MoveNext(Node? current, Direction direction)
    {
        var next = "";

        if (direction == Direction.Left)
        {
            next = current?.Left;
        }
        else
        {
            next = current?.Right;
        }

        var nextNode = _network.Get(next);

        return nextNode;
    }
}
