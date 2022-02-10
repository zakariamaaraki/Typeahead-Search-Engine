namespace App.Model;

public class Result
{
    public string str { get; set; }

    public Node node { get; set; }

    public Result(string str, Node node)
    {
        this.str = str;
        this.node = node;
    }

}