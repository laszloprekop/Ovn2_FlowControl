using System;

namespace Ovn2_FlowControl;

public class SingleTicketExercise : IExercise
{
    public string Title => "Single Ticket Price calculator";
    public string Description => "Calculates price based on age";

    public void Run(IConsoleAdapter console)
    {
        console.Write("Ange ålder: ");
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out int alder)) // Jämför med int.Parse(input) --> "hej" --> Exception
        {
            console.WriteLine("Ogiltig ålder.");
            return;
        }

        if (alder < 20)
        {
            console.WriteLine("Ungdomspris: 80kr");
        }
        else if (alder > 64)
        {
            console.WriteLine("Pensionärspris: 90kr");
        }
        else
        {
            console.WriteLine("Standardpris: 120kr");
        }
    }
}