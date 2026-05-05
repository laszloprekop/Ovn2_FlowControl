using System;
using System.Collections.Generic;

namespace Ovn2_FlowControl;

public class Menu(List<IExercise> exercises)
{
    public void Run()
    {
        var running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Välkommen till huvudmenyn.");

            for (int i = 0; i < exercises.Count; i++)
                Console.WriteLine($"[{i + 1}] →  {exercises[i].Title}");

            Console.WriteLine();
            Console.WriteLine($"Välj övning eller [0] →  Avsluta");
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

                    IViewFragment header = new Header(excercise.Title, excercise.Description);
                    header.Render();

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