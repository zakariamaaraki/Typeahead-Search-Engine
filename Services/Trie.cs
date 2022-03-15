namespace App.Service;

using System.Text;
using App.Model;

/// <summary>
/// Trie Datastructure
/// </summary>
public class Trie : ITrie
{
    private readonly ILogger<Trie> _logger;

    private readonly Node _root;

    public Trie(ILogger<Trie> logger)
    {
        _logger = logger;
        _root = new Node();
    }

    /// <summary>
    /// Add a string to the trie data structure
    /// </summary>
    /// <param name="str">a string</param>
    /// <returns></returns>
    public void Add(string str)
    {
        if (str.Length == 0)
        {
            return;
        }

        _logger.LogInformation("Add new value {}", str);

        AddRec(_root, str, 0);
    }

    /// <summary>
    /// Look for a specific string
    /// </summary>
    /// <param name="str"></param>
    /// <param name="limit"></param>
    /// <returns></returns>
    public Response Find(string str, int limit)
    {
        Response response = new Response(limit);

        if (str.Length == 0)
        {
            return response;
        }

        FindRec(_root, response, str, 0);

        _logger.LogInformation(this.ToString());

        return response;
    }

    /// <summary>
    /// Serialize a Trie data structure
    /// </summary>
    /// <param name="root">Root node of the Trie datastructure</param>
    /// <returns></returns>
    public static string Serialize(Node root)
    {
        StringBuilder builder = new StringBuilder();
        Queue<Node> queue = new Queue<Node>();

        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            Node node = queue.Dequeue();
            Node[] children = node.Children;

            for (int i = 0; i < children.Length; i++)
            {
                if (children[i] == null)
                {
                    builder.Append("0:");
                }
                else
                {
                    if (children[i].EndWord)
                    {
                        builder.Append("2," + children[i].Frequency + ":");
                    }
                    else
                    {
                        builder.Append("1," + children[i].Frequency + ":");
                    }

                    queue.Enqueue(children[i]);
                }
            }
        }

        return builder.ToString();
    }

    /// <summary>
    /// Deserialize a given Trie data structure
    /// </summary>
    /// <param name="str">the string representation of a Trie data structure</param>
    /// <returns></returns>
    public static Node Deserialize(string str)
    {
        if (str == "")
        {
            return new Node();
        }

        string[] words = str.Split(":");
        Queue<Node> queue = new Queue<Node>();
        Node root = new Node();
        queue.Enqueue(root);
        int index = 0;

        while (queue.Count > 0)
        {
            Node node = queue.Dequeue();
            for (int i = index; i < index + 128; i++)
            {
                if (!words[i].Equals("0"))
                {
                    // 2,x => endWord 
                    string[] strs = words[i].Split(",");
                    node.Children[i] = new Node();
                    node.Children[i].Frequency = Convert.ToInt64(strs[1]);

                    if (strs[0].Equals("2"))
                    {
                        node.Children[i].EndWord = true;
                    }

                    queue.Enqueue(node.Children[i]);
                }
            }
        }
        
        return root;
    }

    private void FindRec(Node node, Response response, string str, int index)
    {
        int nodeIndex = (int)str[index];

        if (node.Children[nodeIndex] != null)
        {
            node = node.Children[nodeIndex];

            if (str.Length == index + 1)
            {
                // compute all suggestions from this node using dfs traversal algorithm
                ComputeSuggestions(node, response, str);
            }
            else
            {
                FindRec(node, response, str, index + 1);
            }
        }

    }
    
    private void ComputeSuggestions(Node root, Response response, string str)
    {
        if (root.EndWord)
        {
            response.Add(root, str, root.Frequency);
        }

        int index = 0;

        foreach (Node node in root.Children)
        {
            if (node != null)
            {
                ComputeSuggestions(node, response, str + (char)index);
            }

            index++;
        }
    }

    private void AddRec(Node node, string str, int index)
    {
        int nodeIndex = (int)str[index];

        if (node.Children[nodeIndex] == null)
        {
            node.Children[nodeIndex] = new Node();
        }

        node = node.Children[nodeIndex];

        if (str.Length == index + 1)
        {
            node.EndWord = true;
        }
        else
        {
            AddRec(node, str, index + 1);
        }
    }

}