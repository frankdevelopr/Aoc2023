
namespace Aoc2023Day8;

public class Network
{
    private readonly Dictionary<string, Node> _nodes = new();

    public Network Add(Node node)
    {
        _nodes[node.Label] = node;

        return this;
    }

    public Node? Get(string label)
    {
        if (_nodes.TryGetValue(label, out var node))
        {
            return node;
        }

        return null;
    }
}
