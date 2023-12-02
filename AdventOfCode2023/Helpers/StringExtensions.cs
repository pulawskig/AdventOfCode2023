namespace AdventOfCode2023.Helpers;

public static class StringExtensions
{
    public static IEnumerable<string> GetLines(this string str, bool removeEmptyLines = true)
    {
        return str.Split(new[] { "\r\n", "\r", "\n" },
            removeEmptyLines ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
    }

    public static IEnumerable<TResult> ParseLines<TResult>(this string str, Func<string, TResult> lineParser)
    {
        return str.GetLines().Select(lineParser);
    }
}
