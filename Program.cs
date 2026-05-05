using System;
using System.Collections.Generic;

namespace Ovn2_FlowControl
{
    internal static class Program
    {
        private static void Main()
        {
            var exercises = new List<IExercise>
            {
                new SingleTicketExercise(),
                new GroupTicketExercise(),
                new RepeatTextExercise(),
                new ThirdWordExercise()
            };

            bool running = true;

            while (running)
            {
                Console.WriteLine("Välkommen till huvudmenyn.");
                Console.WriteLine("Skriv en siffra för att välja funktion. Skriv 0 för att avsluta.");
                for (int i = 0; i < exercises.Count; i++)
                    Console.WriteLine($"{i + 1} →  {exercises[i].Title}");

                Console.Write("> ");

                string? input = Console.ReadLine();

                if (input == "0")
                {
                    running = false;
                    Console.WriteLine("Programmet avslutas.");
                }
                else if (int.TryParse(input, out int choice) && choice >= 0 && choice < exercises.Count)
                {
                    exercises[choice - 1].Run();
                }
                else
                {
                    Console.WriteLine("Felaktig input.");
                }

                Console.WriteLine();
            }
        }

        static void DetTredjeOrdet()
        {
            Console.Write("Skriv en mening med minst 3 ord: ");
            string? mening = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(mening))
            {
                Console.WriteLine("Du måste skriva en mening.");
                return;
            }

            string[] ord = mening.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (ord.Length < 3)
            {
                Console.WriteLine("Mening måste innehålla minst 3 ord.");
                return;
            }

            Console.WriteLine($"Det tredje ordet är: {ord[2]}");
        }
    }
}