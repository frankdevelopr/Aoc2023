﻿



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
        var currents = _network.StartingNodes();
        var steps = 0L;

        while (!_network.AreAllEnding(currents))
        {
            var direction = _navigator.Next();
            currents = MoveNodes(currents, direction);
            steps++;

            
            if (steps % 1000000 == 0)
            {
                Console.WriteLine($"Steps taken so far {steps}");
            }
        }

        return steps;
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

    private IEnumerable<Node> MoveNodes(IEnumerable<Node> currents, Direction direction)
    {
        var next = new List<Node>();

        foreach (var current in currents)
        {
            next.Add(MoveNext(current, direction));
        }

        return next;
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