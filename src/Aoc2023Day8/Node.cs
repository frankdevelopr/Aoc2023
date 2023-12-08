namespace Aoc2023Day8;

public class Node
{
    public string Label { get; }
    public string Left { get; }
    public string Right { get; }

    public Node(string label, string left, string right)
    {
        Label = label;
        Left = left;
        Right = right;
    }
}
