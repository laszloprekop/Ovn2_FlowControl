using System;
using System.Collections.Generic;
using Spectre.Console;

namespace Ovn2_FlowControl;

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
                    Console.WriteLine("Programmet avslutas.");
                    break;
                case >= 1 when choice <= exercises.Count:
                {
                    var exercise = exercises[choice - 1];
                    exercise.Run(new SpectreConsole(exercises, exercise));
                    AnsiConsole.Markup("\n[grey]Press any key to return to menu...[/]");
                    Console.ReadKey(true);
                    break;
                }
                default:
                    Console.WriteLine($"Felaktig val. välj 0-{exercises.Count}.");
                    break;
            }
        }

        Console.WriteLine();
    }
}