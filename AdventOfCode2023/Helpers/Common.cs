namespace AdventOfCode2023.Helpers;

public static class Common
{
    public static List<string> Transpose(this List<string> source)
    {
        var transpose = new List<string>();
        for (var i = 0; i < source[0].Length; i++)
        {
            transpose.Add(source
                .Select(line => line[i])
                .JoinString(string.Empty));
        }
        return transpose;
    }
}
