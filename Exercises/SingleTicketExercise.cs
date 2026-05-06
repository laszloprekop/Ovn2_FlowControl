using Ovn2_FlowControl.Contracts;

namespace Ovn2_FlowControl.Exercises;

public class SingleTicketExercise : ExerciseBase
{
    public SingleTicketExercise() : base("Single Ticket Price", "Calculates price for a single person") { }
    public override void Run(IConsoleAdapter console)
    {
        string? input = console.ReadLine("Ange ålder:\u00A0");

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