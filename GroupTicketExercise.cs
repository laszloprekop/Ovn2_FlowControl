using System;

namespace Ovn2_FlowControl;

public class GroupTicketExercise : IExercise
{
    public string Title => "Group Ticket Price calculator";
    public string Description => "Calculates price for a group with different ages";

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

            var person = new Person(alder);
            var price = person.GetTicketPrice();

            if (price == 0)
            {
                Console.WriteLine($"Person {i}: Gratis");
            }
            else
            {
                total += price;
            }
        }

        Console.WriteLine($"Antal personer: {antal}");
        Console.WriteLine($"Totalkostnad: {total} kr");
    }
}