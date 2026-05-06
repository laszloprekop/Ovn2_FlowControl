using Ovn2_FlowControl.Contracts;
using Ovn2_FlowControl.Localization;

namespace Ovn2_FlowControl.Exercises;

public class SingleTicketExercise : ExerciseBase
{
    public SingleTicketExercise()
        : base("exercise_ticket_title", "exercise_ticket_desc")
    {
    }

    public override void Run(IConsoleAdapter console)
    {
        string? input = console.ReadLine(Loc.Get("exercise_ticket_prompt_age"));

        if (!int.TryParse(input, out int alder))
        {
            console.WriteLine(Loc.Get("exercise_ticket_err_age"));
            return;
        }

        if (alder < 20)
            console.WriteLine(Loc.Get("exercise_ticket_youth"));
        else if (alder > 64)
            console.WriteLine(Loc.Get("exercise_ticket_senior"));
        else
            console.WriteLine(Loc.Get("exercise_ticket_standard"));
    }
}