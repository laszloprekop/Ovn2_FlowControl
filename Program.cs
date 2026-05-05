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


        static void PrisForSallskap()
        {
            Console.Write("Hur många personer är ni? ");
            string? antalInput = Console.ReadLine();

            if (!int.TryParse(antalInput, out int antal) || antal <= 0)
            {
                Console.WriteLine("Ogiltigt antal personer.");
                return;
            }

            int total = 0;

            for (int i = 1; i <= antal; i++)
            {
                Console.Write($"Ange ålder för person {i}: ");
                string? alderInput = Console.ReadLine();

                if (!int.TryParse(alderInput, out int alder) || alder < 0)
                {
                    Console.WriteLine("Ogiltig ålder.");
                    return;
                }

                if (alder < 5 || alder > 100)
                {
                    Console.WriteLine($"Person {i}: Gratis");
                }
                else if (alder < 20)
                {
                    total += 80;
                }
                else if (alder > 64)
                {
                    total += 90;
                }
                else
                {
                    total += 120;
                }
            }

            Console.WriteLine($"Antal personer: {antal}");
            Console.WriteLine($"Totalkostnad: {total} kr");
        }

        static void UpprepaTioGanger()
        {
            Console.Write("Skriv en text: ");
            string? text = Console.ReadLine();

            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"{i}. {text} ");
            }

            Console.WriteLine();
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