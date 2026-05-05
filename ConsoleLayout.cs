using System.Collections.Generic;
using System.Text;
using Spectre.Console;

namespace Ovn2_FlowControl;

public class ConsoleLayout(List<IExercise> exercises)
{
    public void RenderMenu()
    {
        AnsiConsole.Clear();

        AnsiConsole.Write(
            new Panel(BuildMenuMarkup())
                .RoundedBorder()
                .BorderColor(Color.SkyBlue2)
                .Header("[bold]Main Menu[/]")
        );
        AnsiConsole.Write(
                new Markup($"[white][[0]][/] Avsluta · [white][[1-{exercises.Count}]][/] Välj övning\n"))
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

        AnsiConsole.Write(new Columns(
                new Panel(BuildMenuMarkup())
                    .RoundedBorder()
                    .Header("[bold]Main Menu[/]"),
                new Panel(mainContent)
                    .RoundedBorder()
                    .Header($"[bold]{Markup.Escape(exercise.Title)}[/]\n")
            )
        );

        AnsiConsole.Write(
                new Markup("ℹ️ [blue]Press any key to continue...[/]"))
            ;
    }
}