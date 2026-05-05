using System;
using System.Collections.Generic;

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
                    var excercise = exercises[choice - 1];
                    _layout.RenderExercise(excercise);
                    excercise.Run();
                    
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine($"Felaktig val. välj 0-{exercises.Count}.");
                    break;
            }
        }

        Console.WriteLine();
    }
}