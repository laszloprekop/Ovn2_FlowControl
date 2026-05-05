using System;
using System.Collections.Generic;
using Ovn2_FlowControl;

namespace FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var exercises = new List<IExcercise>
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
                Console.WriteLine("Skriv en siffra för att välja funktion.");
                for (int i = 1; i <= exercises.Count; i++)
                    Console.WriteLine($"{i} = {exercises[i].Title}");

                Console.Write("> ");

                string? input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        running = false;
                        Console.WriteLine("Programmet avslutas.");
                        break;

                    case "1":
                        UngdomEllerPensionar();
                        break;

                    case "2":
                        PrisForSallskap();
                        break;

                    case "3":
                        UpprepaTioGanger();
                        break;

                    case "4":
                        DetTredjeOrdet();
                        break;

                    default:
                        Console.WriteLine("Felaktig input, välj 0-4.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void UngdomEllerPensionar()
        {
            Console.Write("Ange ålder: ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int alder)) // Jämför med int.Parse(input) --> "hej" --> Exception
            {
                Console.WriteLine("Ogiltig ålder.");
                return;
            }

            if (alder < 20)
            {
                Console.WriteLine("Ungdomspris: 80kr");
            }
            else if (alder > 64)
            {
                Console.WriteLine("Pensionärspris: 90kr");
            }
            else
            {
                Console.WriteLine("Standardpris: 120kr");
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