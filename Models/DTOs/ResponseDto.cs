namespace App.Model;

public class ResponseDto
{
    public long Hits { get; set; }

    public LinkedList<string> Suggestions { get; } = new LinkedList<string>();

    /// <summary>
    /// Convert a Response object to ResponseDto
    /// </summary>
    /// <param name="response">object to be transformed</param>
    public ResponseDto(Response response)
    {
        Hits = response.Hits;

        PriorityQueue<Result, long> priorityQueue = response.PriorityQueue;

        while (priorityQueue.Count > 0)
        {
            Result result = priorityQueue.Dequeue();

            // update frequency
            result.Node.Frequency++;

            Suggestions.AddFirst(result.Str);
        }
    }
}