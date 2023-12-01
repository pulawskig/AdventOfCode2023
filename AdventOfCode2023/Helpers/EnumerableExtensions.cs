namespace AdventOfCode2023.Helpers;

public static class EnumerableExtensions
{
    public static IEnumerable<T> FirstAndLast<T> (this IEnumerable<T> source)
    {
        yield return source.First();
        yield return source.Last();
    }
}
