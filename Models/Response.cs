namespace App.Model;

/// <summary>
///     Response is a Heap that keep the K most relevant elements
/// </summary>
public class Response
{
    public Response(int capacity)
    {
        Capacity = capacity;
    }

    public int Capacity { get; }

    public long Hits { get; set; }

    public PriorityQueue<Result, long> PriorityQueue { get; } = new();

    /// <summary>
    ///     Add a suggestion to the heap.
    ///     If the size of the heap exceed the capacity, the suggestion with least frequency will be removed
    /// </summary>
    /// <param name="node">Node in the Trie</param>
    /// <param name="suggestion">A relevant suggestion</param>
    /// <param name="frequency">Frequency of the suggestion</param>
    /// <returns></returns>
    public void Add(Node node, string suggestion, long frequency)
    {
        PriorityQueue.Enqueue(new Result(suggestion, node), frequency);

        Hits++;

        if (PriorityQueue.Count > Capacity) PriorityQueue.Dequeue();
    }
}