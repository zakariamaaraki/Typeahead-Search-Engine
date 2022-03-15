namespace App.Model;

/// <summary>
///     Result
/// </summary>
public class Result
{
    public Result(string str, Node node)
    {
        Str = str;
        Node = node;
    }

    public string Str { get; }

    public Node Node { get; }
}