using System;
using System.Collections.Generic;
using Spectre.Console;
using Ovn2_FlowControl.Contracts;
using Ovn2_FlowControl.Localization;

namespace Ovn2_FlowControl.UI;

public class Menu(List<IExercise> exercises)
{
    private readonly ConsoleLayout _layout = new ConsoleLayout(exercises);

    public void Run()
    {
        var running = true;

        while (running)
        {
            _layout.RenderMenu();
            Console.Write("> ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
                choice = -1;

            switch (choice)
            {
                case 0:
                    running = false;
                    Console.WriteLine(Loc.Get("menu_exit_message"));
                    break;
                case >= 1 when choice <= exercises.Count:
                {
                    var exercise = exercises[choice - 1];
                    exercise.Run(new SpectreConsole(exercises, exercise));
                    AnsiConsole.Markup($"\n[grey]{Markup.Escape(Loc.Get("menu_press_key"))}[/]");
                    Console.ReadKey(true);
                    break;
                }
                default:
                    Console.WriteLine(string.Format(Loc.Get("menu_invalid"), exercises.Count));
                    break;
            }
        }

        Console.WriteLine();
    }
}