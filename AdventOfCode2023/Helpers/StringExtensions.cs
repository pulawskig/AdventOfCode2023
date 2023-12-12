using System.Text;

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

    public static string ReplaceCharacter(this string str, char c, int index)
    {
        var sb = new StringBuilder(str);
        sb[index] = c;
        return sb.ToString();
    }

    public static string ReplaceFirstOccurance(this string str, char c, char replace)
    {
        var index = str.IndexOf(c);
        return str.ReplaceCharacter(replace, index);
    }

    public static string ReplaceFirstCharacter(this string str, char c)
    {
        return string.Concat(str.Skip(1).Prepend(c));
    }
}
