using System;
using Ovn2_FlowControl.Contracts;

namespace Ovn2_FlowControl.Exercises;

public class GroupTicketExercise : ExerciseBase
{
    public GroupTicketExercise() : base("Group Ticket Price", "Calculates price for a group with different ages") { }

    public override void Run(IConsoleAdapter console)
    {
        string? antalInput = console.ReadLine("Hur många personer är ni? ");

        if (!int.TryParse(antalInput, out int antal) || antal <= 0)
        {
            console.WriteLine("Ogiltigt antal personer.");
            return;
        }

        int total = 0;

        for (int i = 1; i <= antal; i++)
        {
            string? alderInput = console.ReadLine($"Ange ålder för person {i}: ");

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