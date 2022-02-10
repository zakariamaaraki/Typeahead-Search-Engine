namespace App.Model;

public class Node
{
    private static readonly int CAPACITY = 128;

    public Node[] Children { set; get; } = new Node[CAPACITY];

    public Boolean EndWord { set; get; } = false;

    public long Frequency { set; get; } = 0;

}