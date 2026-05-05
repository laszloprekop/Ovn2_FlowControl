using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Ovn2_FlowControl;

public class SpectreConsole(List<IExercise> exercises, IExercise currentExercise) : IConsoleAdapter
{
    private readonly List<string> _lines = new() { string.Empty };

    private void Refresh()
    {
        AnsiConsole.Clear();
        AnsiConsole.Write(BuildRenderable());
    }

    public void Write(string text)
    {
        _lines[^1] += text;
        Refresh();
    }

    public void WriteLine(string text)
    {
        _lines[^1] += text;
        _lines.Add(string.Empty);
        Refresh();
    }

    public string? ReadLine(string prompt)
    {
        _lines[^1] += prompt;
        Refresh();
        var input = Console.ReadLine() ?? string.Empty;
        _lines[^1] += input;
        _lines.Add(string.Empty);
        Refresh();
        return input;
    }

    private IRenderable BuildRenderable()
    {
        var output = string.Join("\n", _lines.Select(Markup.Escape));

        var mainContent = new Markup(
            $"[italic]{Markup.Escape(currentExercise.Description)}[/]\n" +
            $"[grey]────────────────────────────────[/]\n\n" +
            output
        );

        var sb = new StringBuilder();
        for (int i = 0; i < exercises.Count; i++)
            sb.AppendLine($"[white][[{i + 1}]][/] {Markup.Escape(exercises[i].Title)}");

        var table = new Table().NoBorder().HideHeaders().Expand();
        table.AddColumn(new TableColumn(string.Empty).Width(38));
        table.AddColumn(new TableColumn(string.Empty));
        table.AddRow(
            new Panel(new Markup(sb.ToString()))
                .RoundedBorder()
                .Header("[bold]Main Menu[/]"),
            new Panel(mainContent)
                .RoundedBorder()
                .Header($"[bold]{Markup.Escape(currentExercise.Title)}[/]")
        );
        return table;
    }
}
