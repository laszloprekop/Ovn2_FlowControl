using System;

namespace Ovn2_FlowControl;

public class GroupTicketExercise : IExercise
{
    public string Title => "Group Ticket Price calculator";
    public string Description => "Calculates price for a group with different ages";

    public void Run(IConsoleAdapter console)
    {
        console.Write("Hur många personer är ni? ");
        string? antalInput = Console.ReadLine();

        if (!int.TryParse(antalInput, out int antal) || antal <= 0)
        {
            console.WriteLine("Ogiltigt antal personer.");
            return;
        }

        int total = 0;

        for (int i = 1; i <= antal; i++)
        {
            console.Write($"Ange ålder för person {i}: ");
            string? alderInput = Console.ReadLine();

            if (!int.TryParse(alderInput, out int alder) || alder < 0)
            {
                console.WriteLine("Ogiltig ålder.");
                return;
            }

            var person = new Person(alder);
            var price = person.GetTicketPrice();

            if (price == 0)
            {
                console.WriteLine($"Person {i}: Gratis");
            }
            else
            {
                total += price;
            }
        }

        console.WriteLine($"Antal personer: {antal}");
        console.WriteLine($"Totalkostnad: {total} kr");
    }
}