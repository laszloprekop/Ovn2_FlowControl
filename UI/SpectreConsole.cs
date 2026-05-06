using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spectre.Console;
using Spectre.Console.Rendering;
using Ovn2_FlowControl.Contracts;
using Ovn2_FlowControl.Localization;

namespace Ovn2_FlowControl.UI;

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
        AnsiConsole.Clear();
        AnsiConsole.Write(BuildRenderable());

        // Move cursor inside the right panel at the end of the prompt text.
        // Right panel rows: 0=top-border, 1..descRows=description, then divider, blank, then _lines.
        int rightContentWidth = Math.Max(1, Console.WindowWidth - 42); // 38 left-col + 4 borders/padding
        int descRows = (int)Math.Ceiling(currentExercise.Description.Length / (double)rightContentWidth);
        int promptLen = _lines[^1].Length;
        int row = descRows + _lines.Count + 2 + promptLen / rightContentWidth;
        int col = 40 + promptLen % rightContentWidth + 1;
        Console.SetCursorPosition(Math.Min(col, Console.WindowWidth - 1), Math.Min(row, Console.WindowHeight - 1));

        var input = Console.ReadLine() ?? string.Empty;
        _lines[^1] += input;
        _lines.Add(string.Empty);
        AnsiConsole.Clear();
        AnsiConsole.Write(BuildRenderable());
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
        sb.AppendLine();
        for (int i = 0; i < exercises.Count; i++)
            sb.AppendLine($"[white][[{i + 1}]][/] {Markup.Escape(exercises[i].Title)}");

        var table = new Table().NoBorder().HideHeaders().Expand();
        table.AddColumn(new TableColumn(string.Empty).Width(38));
        table.AddColumn(new TableColumn(string.Empty));
        table.AddRow(
            new Panel(new Markup(sb.ToString()))
                .RoundedBorder()
                .Header($"[bold]{Markup.Escape(Loc.Get("menu_title"))}[/]"),
            new Panel(mainContent)
                .RoundedBorder()
                .BorderColor(Color.SkyBlue2)
                .Header($"[bold]{Markup.Escape(currentExercise.Title)}[/]")
        );
        return table;
    }
}
