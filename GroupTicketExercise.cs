using System;

namespace Ovn2_FlowControl;

public class GroupTicketExercise : IExercise
{
    public string Title => "Group Ticket Price calculator";

    public void Run()
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
                total += 80;
            else if (alder > 64)
                total += 90;
            else
                total += 120;
        }

        Console.WriteLine($"Antal personer: {antal}");
        Console.WriteLine($"Totalkostnad: {total} kr");
    }
}