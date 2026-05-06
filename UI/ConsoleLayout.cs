using System.Collections.Generic;
using System.Text;
using Spectre.Console;
using Ovn2_FlowControl.Contracts;
using Ovn2_FlowControl.Localization;

namespace Ovn2_FlowControl.UI;

public class ConsoleLayout(List<IExercise> exercises)
{
    public void RenderMenu()
    {
        AnsiConsole.Clear();

        AnsiConsole.Write(
            new Panel(BuildMenuMarkup())
                .RoundedBorder()
                .BorderColor(Color.SkyBlue2)
                .Header($"[bold]{Markup.Escape(Loc.Get("menu_title"))}[/]")
        );
        AnsiConsole.Write(
                new Markup($"[white][[0]][/] {Markup.Escape(Loc.Get("menu_exit"))} · [white][[1-{exercises.Count}]][/] {Markup.Escape(Loc.Get("menu_choose"))}\n"))
            ;
    }

    private Markup BuildMenuMarkup()
    {
        var sb = new StringBuilder("\n");
        for (int i = 0; i < exercises.Count; i++)
        {
            sb.AppendLine($"[white][[{i + 1}]][/] {Markup.Escape(exercises[i].Title)}");
        }

        return new Markup(sb.ToString());
    }

    public void RenderExercise(IExercise exercise)
    {
        AnsiConsole.Clear();
        var mainContent = new Markup(
            $"[italic]{Markup.Escape(exercise.Description)}[/]\n" +
            $"[grey]──────────────────────────────────────────────[/]\n");

        var table = new Table().NoBorder().HideHeaders().Expand();
        table.AddColumn(new TableColumn(string.Empty).Width(38));
        table.AddColumn(new TableColumn(string.Empty));
        table.AddRow(
            new Panel(BuildMenuMarkup())
                .RoundedBorder()
                .Header($"[bold]{Markup.Escape(Loc.Get("menu_title"))}[/]"),
            new Panel(mainContent)
                .RoundedBorder()
                .Header($"[bold]{Markup.Escape(exercise.Title)}[/]")
        );
        AnsiConsole.Write(table);

        AnsiConsole.Write(
                new Markup("ℹ️ [blue]Press any key to continue...[/]"))
            ;
    }
}