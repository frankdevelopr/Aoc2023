
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
}
