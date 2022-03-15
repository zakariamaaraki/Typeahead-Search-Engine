namespace App.Model;

public class ResponseDto
{
    /// <summary>
    ///     Convert a Response object to ResponseDto
    /// </summary>
    /// <param name="response">object to be transformed</param>
    public ResponseDto(Response response)
    {
        Hits = response.Hits;

        var priorityQueue = response.PriorityQueue;

        while (priorityQueue.Count > 0)
        {
            var result = priorityQueue.Dequeue();

            // update frequency
            result.Node.Frequency++;

            Suggestions.AddFirst(result.Str);
        }
    }

    public long Hits { get; set; }

    public LinkedList<string> Suggestions { get; } = new();
}