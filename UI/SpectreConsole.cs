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
    private readonly HashSet<int> _resultLineIndices = new();
    private string[]? _selectChoices;
    private int _selectIndex;
    private int _selectActiveIndex = -1;

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

    public void WriteResult(string text)
    {
        _lines[^1] += text;
        _resultLineIndices.Add(_lines.Count - 1);
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

    public string Select(string prompt, string[] choices, int activeIndex = -1)
    {
        _lines[^1] += prompt;
        _selectChoices = choices;
        _selectIndex = activeIndex >= 0 ? activeIndex : 0;
        _selectActiveIndex = activeIndex;

        while (true)
        {
            Refresh();
            var key = Console.ReadKey(intercept: true);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    _selectIndex = (_selectIndex - 1 + choices.Length) % choices.Length;
                    break;
                case ConsoleKey.DownArrow:
                    _selectIndex = (_selectIndex + 1) % choices.Length;
                    break;
                case ConsoleKey.Enter:
                    var selected = choices[_selectIndex];
                    _lines[^1] += selected;
                    _lines.Add(string.Empty);
                    _selectChoices = null;
                    _selectActiveIndex = -1;
                    Refresh();
                    return selected;
            }
        }
    }

    private IRenderable BuildRenderable()
    {
        var output = string.Join("\n", _lines.Select((line, idx) =>
            _resultLineIndices.Contains(idx)
                ? $"[bold yellow]{Markup.Escape(line)}[/]"
                : Markup.Escape(line)));

        if (_selectChoices != null)
        {
            var sb2 = new StringBuilder();
            for (int i = 0; i < _selectChoices.Length; i++)
            {
                bool isCursor = i == _selectIndex;
                bool isActive = i == _selectActiveIndex;
                var marker = isCursor ? ">" : " ";
                var escaped = Markup.Escape(_selectChoices[i]);
                string line = (isCursor, isActive) switch
                {
                    (true, true)  => $"[bold yellow]{marker} {escaped}[/]",
                    (true, false) => $"[bold skyblue2]{marker} {escaped}[/]",
                    (false, true) => $"[yellow]  {escaped}[/]",
                    _             => $"  {escaped}"
                };
                sb2.AppendLine(line);
            }
            output += "\n" + sb2;
        }

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
