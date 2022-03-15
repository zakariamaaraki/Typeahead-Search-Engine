namespace App.Model;

/// <summary>
///     Node will be used in Trie data structure
/// </summary>
public class Node
{
    private static readonly int s_capacity = 128;

    public Node[] Children { set; get; } = new Node[s_capacity];

    public bool EndWord { set; get; } = false;

    public long Frequency { set; get; } = 0;
}