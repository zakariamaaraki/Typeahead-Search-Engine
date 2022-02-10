namespace App.Model;

using System.Collections.Generic;

public class Response
{

    private int capacity;

    public long hits;

    public Response(int capacity)
    {
        this.capacity = capacity;
    }

    public PriorityQueue<Result, long> PriorityQueue { set; get; } = new PriorityQueue<Result, long>();

    public void Add(Node node, string suggestion, long frequency)
    {
        PriorityQueue.Enqueue(new Result(suggestion, node), frequency);

        this.hits++;

        if (PriorityQueue.Count > capacity)
        {
            PriorityQueue.Dequeue();
        }
    }

}