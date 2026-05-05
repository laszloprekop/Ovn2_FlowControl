using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Ovn2_FlowControl;

public class SpectreConsole(List<IExercise> exercises, IExercise currentExercise) : IConsoleAdapter
{
    private readonly List<string> _lines = new();
    private LiveDisplayContext? _context;

    public void SetContext(LiveDisplayContext context) => _context = context;

    public void Write(string text)
    {
        if (_lines.Count == 0) _lines.Add(string.Empty);
        _lines[^1] += text;
    }

    public void WriteLine(string text)
    {
        _lines.Add(text);
    }

    public string? ReadLine(string prompt)
    {
        WriteLine(prompt);
        var input = Console.ReadLine();
        if (_lines.Count > 0) _lines[^1] += input;
        _lines.Add(string.Empty);
        return input;
    }

    public IRenderable BuildRenderable()
    {
        var output = string.Join("\n", _lines.Select(Markup.Escape));

        var mainContent = new Markup(
            $"[bold]{Markup.Escape(currentExercise.Title)}[/]\n" +
            $"[italic]{Markup.Escape(currentExercise.Description)}[/]\n" +
            $"[grey]────────────────────────────────[/]\n\n" +
            output
        );

        var sb = new StringBuilder();

        for (int i = 0; i < exercises.Count; i++)
            sb.AppendLine($"[white][[{i + 1}]][/] {Markup.Escape(exercises[i].Title)}[/]");

        return new Columns(
            new Panel(new Markup(sb.ToString()))
                .RoundedBorder()
                .Header("[bold]Main Menu[/]"),
            new Panel(mainContent)
                .RoundedBorder()
                .Header("[bold]{Markup.Escape(currentExercise.Title)}[/]")
        );
    }
}