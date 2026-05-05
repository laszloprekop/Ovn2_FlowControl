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
}