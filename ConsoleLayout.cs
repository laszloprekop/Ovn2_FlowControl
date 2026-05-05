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
                .Header("[bold]Main Menu[/bold]")
        );
        AnsiConsole.Write(
            new Panel(new Markup($"[grey][0] Avsluta  [[1-{exercises.Count}]] Välj övning"))
                .RoundedBorder()
        );
    }

    private Markup BuildMenuMarkup()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < exercises.Count; i++)
        {
            sb.AppendLine($"[[{i + 1}]] {Markup.Escape(exercises[i].Title)}");
        }

        return new Markup(sb.ToString());
    }

    public void RenderExercise(IExercise exercise)
    {
        AnsiConsole.Clear();
        var mainContent = new Markup(
                              $"[bold]{Markup.Escape(exercise.Title)}[/]\n") +
                          $"[italic]{Markup.Escape(exercise.Description)}[/]\n\n" +
                          $"[grey]────────────────────────────────[/]";

        AnsiConsole.Write(new Columns(
            new Panel(BuildMenuMarkup())
                .RoundedBorder()
                .Header("[bold]Main Menu[/bold]"),
            new Panel(mainContent)
                .RoundedBorder()
                .Header($"[bold]{Markup.Escape(exercise.Title)}[/bold]")));
        AnsiConsole.Write(new Panel(
            new Markup("ℹ️ [grey]  Press any key to continue...[/]")));
    }
}