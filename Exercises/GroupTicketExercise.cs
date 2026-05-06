using Ovn2_FlowControl.Contracts;
using Ovn2_FlowControl.Localization;

namespace Ovn2_FlowControl.Exercises;

public class GroupTicketExercise : ExerciseBase
{
    public GroupTicketExercise() : base("exercise_group_title", "exercise_group_desc") { }

    public override void Run(IConsoleAdapter console)
    {
        string? antalInput = console.ReadLine(Loc.Get("exercise_group_prompt_count"));

        if (!int.TryParse(antalInput, out int antal) || antal <= 0)
        {
            console.WriteLine(Loc.Get("exercise_group_err_count"));
            return;
        }

        int total = 0;

        for (int i = 1; i <= antal; i++)
        {
            string? alderInput = console.ReadLine(string.Format(Loc.Get("exercise_group_prompt_age"), i));

            if (!int.TryParse(alderInput, out int alder) || alder < 0)
            {
                console.WriteLine(Loc.Get("exercise_group_err_age"));
                return;
            }

            var person = new Person(alder);
            var price = person.GetTicketPrice();

            if (price == 0)
                console.WriteLine(string.Format(Loc.Get("exercise_group_free"), i));
            else
                total += price;
        }

        console.WriteResult(string.Format(Loc.Get("exercise_group_result_count"), antal));
        console.WriteResult(string.Format(Loc.Get("exercise_group_result_total"), total));
    }
}