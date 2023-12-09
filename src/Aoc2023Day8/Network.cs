

namespace Aoc2023Day8;

public class Network
{
    public Dictionary<string, Node> Nodes { get; } = new();

    public Network Add(Node node)
    {
        Nodes[node.Label] = node;

        return this;
    }

    public Node? Get(string label)
    {
        if (Nodes.TryGetValue(label, out var node))
        {
            return node;
        }

        return null;
    }

    public IEnumerable<Node> StartingNodes()
    {
        return Nodes.Values.Where(t => t.Label.EndsWith('A'));
    }

    public bool AreAllEnding(IEnumerable<Node> nodes)
    {
        return nodes.All(t => t.Label.EndsWith('Z'));
    }
}
