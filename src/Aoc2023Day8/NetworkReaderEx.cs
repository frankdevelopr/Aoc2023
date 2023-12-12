namespace Aoc2023Day8;

public class NetworkReaderEx
{
    public Navigator Navigator { get;}
    public NetworkEx Network { get; }

    public NetworkReaderEx(string[] lines)
    {
        Navigator = new Navigator(lines[0].Trim());
        Network = BuildNetwork(lines);
    }

    private NetworkEx BuildNetwork(string[] lines)
    {
        var network = new NetworkEx();

        for (var i = 2; i < lines.Length; i++)
        {
            var parts = lines[i].Split('=');

            var label = parts[0].Trim();
            ParseDirections(parts[1], out var left, out var right);

            var baseNode = network.GetOrCreate(label);
            var rightNode = network.GetOrCreate(right);
            var leftNode = network.GetOrCreate(left);

            baseNode.Right = rightNode;
            baseNode.Left = leftNode;
        }

        return network;
    }

    private void ParseDirections(string directions, out string left, out string right)
    {
        var trim = directions.Trim();
        var parts = trim.Split(',');

        left = parts[0].TrimStart(' ', '(');
        right = parts[1].TrimStart(' ').TrimEnd(' ', ')');
    }
}
