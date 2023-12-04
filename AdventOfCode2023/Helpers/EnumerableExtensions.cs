namespace AdventOfCode2023.Helpers;

public static class EnumerableExtensions
{
    public static IEnumerable<T> FirstAndLast<T> (this IEnumerable<T> source)
    {
        yield return source.First();
        yield return source.Last();
    }

    public static TimeSpan AverageTime(this IEnumerable<TimeSpan> source)
    {
        var doubleAverage = source.Average(span => span.Ticks);
        var longAverage = Convert.ToInt64(doubleAverage);
        return new TimeSpan(longAverage);
    }
}
