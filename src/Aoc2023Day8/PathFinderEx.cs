namespace Aoc2023Day8;

public class PathFinderEx
{
    private readonly Navigator _navigator;
    private readonly NetworkEx _network;

    public PathFinderEx(Navigator navigator, NetworkEx network)
    {
        _navigator = navigator;
        _network = network;
    }

    public long FindMultiple()
    {
        var currents = _network.StartingNodes().ToArray();
        var steps = 0L;

        while (!_network.AreAllEnding(currents))
        {
            var direction = _navigator.Next();
            MoveNodes(currents, direction);
            steps++;

            
            if (steps % 10_000_000 == 0)
            {
                Console.WriteLine($"Steps taken so far {steps}");
            }
        }

        return steps;
    }

    private void MoveNodes(NodeEx[] currents, Direction direction)
    {
        for (var i = 0; i < currents.Length; ++i)
        {
            currents[i] = MoveNext(currents[i], direction);
        }
    }

    private NodeEx? MoveNext(NodeEx? current, Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                return current.Left;
            case Direction.Right:
                return current.Right;
        }

        throw new NotImplementedException();
    }
}

