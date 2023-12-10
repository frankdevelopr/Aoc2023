
namespace Aoc2023Day8;

public class NetworkEx
{
    public Dictionary<string, NodeEx> Nodes { get; } = new();

    public IEnumerable<NodeEx> StartingNodes()
    {
        return Nodes.Values.Where(t => t.Label.EndsWith('A'));
    }

    public bool AreAllEnding(IEnumerable<NodeEx> nodes)
    {
        return nodes.All(t => t.Label.EndsWith('Z'));
    }

    public NodeEx GetOrCreate(string label)
    {
        if (Nodes.TryGetValue(label, out var node))
        {
            return node;
        }

        var newNode = new NodeEx(label);
        Nodes.Add(label, newNode);
        return newNode;
    }

    private NetworkEx Add(NodeEx node)
    {
        Nodes[node.Label] = node;

        return this;
    }
}

