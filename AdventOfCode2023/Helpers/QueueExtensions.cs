namespace AdventOfCode2023.Helpers;

public static class QueueExtensions
{
    public static void EnqueueRange<T>(this Queue<T> queue, IEnumerable<T> range)
    {
        foreach (var item in range)
        {
            queue.Enqueue(item);
        }
    }
}
