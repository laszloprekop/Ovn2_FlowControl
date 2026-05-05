using System;

namespace Ovn2_FlowControl;

public class SingleTicketExercise : IExercise
{
    public string Title => "Single Ticket Price calculator";
    public string Description => "Calculates price based on age";

    public void Run()
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
}