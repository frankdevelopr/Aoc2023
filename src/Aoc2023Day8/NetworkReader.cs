namespace Aoc2023Day8;

public class NetworkReader
{
    public Navigator Navigator { get;}
    public Network Network { get; }

    public NetworkReader(string[] lines)
    {
        Navigator = new Navigator(lines[0].Trim());
        Network = BuildNetwork(lines);
    }

    private Network BuildNetwork(string[] lines)
    {
        var network = new Network();

        for (var i = 2; i < lines.Length; i++)
        {
            var parts = lines[i].Split('=');

            var label = parts[0].Trim();
            ParseDirections(parts[1], out var left, out var right);

            network.Add(new Node(label, left, right));
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
