namespace Aoc2023Day8;

public class NodeEx
{
    public string Label { get; }
    public NodeEx? Left { get; set; }
    public NodeEx? Right { get; set; }

    public NodeEx(string label)
    {
        Label = label;
    }

    public NodeEx(string label, NodeEx left, NodeEx right)
    {
        Label = label;
        Left = left;
        Right = right;
    }
}
