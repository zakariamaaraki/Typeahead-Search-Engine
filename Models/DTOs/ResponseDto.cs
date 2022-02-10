namespace App.Model;

public class ResponseDto
{

    public long hits { get; set; }

    public LinkedList<string> suggestions { get; set; } = new LinkedList<string>();

    public ResponseDto(Response response)
    {
        hits = response.hits;

        PriorityQueue<Result, long> PriorityQueue = response.PriorityQueue;

        while (PriorityQueue.Count > 0)
        {
            Result result = PriorityQueue.Dequeue();

            // update frequency
            result.node.Frequency++;

            suggestions.AddFirst(result.str);
        }
    }

}