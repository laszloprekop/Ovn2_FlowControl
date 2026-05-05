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
            Console.WriteLine("Välkommen till huvudmenyn.");
            Console.WriteLine("0 →  Avsluta");

            for (int i = 0; i < exercises.Count; i++)
                Console.WriteLine($"{i + 1} → {exercises[i].Title}");

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
                    exercises[choice - 1].Run();
                    break;
                default:
                    Console.WriteLine("Felaktig val. välj 0-{exercises.Count}.");
                    break;
            }
        }

        Console.WriteLine("");
    }
}