using AdventOfCode2023.Helpers;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace AdventOfCode2023.Components.Pages;

public abstract class DayBase<TDay, TParse> : DayBase<TDay, TParse, long, long>;
public abstract class DayBase<TDay, TParse, TPart1, TPart2> : ComponentBase
{
    public string InputData { get; set; } = string.Empty;
    public TPart1 Result1 { get; protected set; } = default;
    public TPart2 Result2 { get; protected set; } = default;

    protected TimeSpan ParseFirst { get; set; }
    protected TimeSpan ParseAverage { get; set; }
    protected TimeSpan Part1First { get; set; }
    protected TimeSpan Part1Average { get; set; }
    protected TimeSpan Part2First { get; set; }
    protected TimeSpan Part2Average { get; set; }

    protected override async Task OnInitializedAsync()
    {
        InputData = await File.ReadAllTextAsync($"{Directory.GetCurrentDirectory()}{@$"\wwwroot\input\{typeof(TDay).Name.ToLower()}.txt"}");
    }

    public void HandleInputChange(ChangeEventArgs args)
    {
        InputData = args.Value?.ToString() ?? string.Empty;
    }

    protected abstract TParse ParseInput();

    public void RunPart1()
    {
        var input = ParseInput();
        Result1 = GetResult1(input);
    }

    protected abstract TPart1 GetResult1(TParse input);

    public void RunPart2()
    {
        var input = ParseInput();
        Result2 = GetResult2(input);
    }
    protected abstract TPart2 GetResult2(TParse input);

    public void RunBenchmark()
    {
        var timestamp = Stopwatch.GetTimestamp();
        var input = ParseInput();
        ParseFirst = Stopwatch.GetElapsedTime(timestamp);

        var spans = new List<TimeSpan>();
        for (var i = 0; i < 10_000; i++)
        {
            timestamp = Stopwatch.GetTimestamp();
            ParseInput();
            spans.Add(Stopwatch.GetElapsedTime(timestamp));
        }
        ParseAverage = spans.AverageTime();

        timestamp = Stopwatch.GetTimestamp();
        GetResult1(input);
        Part1First = Stopwatch.GetElapsedTime(timestamp);

        spans.Clear();
        for (var i = 0; i < 10_000; i++)
        {
            timestamp = Stopwatch.GetTimestamp();
            GetResult1(input);
            spans.Add(Stopwatch.GetElapsedTime(timestamp));
        }
        Part1Average = spans.AverageTime();

        input = ParseInput();
        timestamp = Stopwatch.GetTimestamp();
        GetResult2(input);
        Part2First = Stopwatch.GetElapsedTime(timestamp);

        spans.Clear();
        for (var i = 0; i < 10_000; i++)
        {
            timestamp = Stopwatch.GetTimestamp();
            GetResult2(input);
            spans.Add(Stopwatch.GetElapsedTime(timestamp));
        }
        Part2Average = spans.AverageTime();
    }
}
