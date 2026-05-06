using System.Linq;
using Ovn2_FlowControl.Contracts;
using Ovn2_FlowControl.Localization;

namespace Ovn2_FlowControl.Exercises;

public class RepeatTextExercise : ExerciseBase
{
    public RepeatTextExercise() : base("exercise_repeat_title", "exercise_repeat_desc") { }

    public override void Run(IConsoleAdapter console)
    {
        string? text = console.ReadLine(Loc.Get("exercise_repeat_prompt"));

        console.WriteResult(string.Join(", ", Enumerable.Range(1, 10).Select(i => $"{i}. {text}")));
    }
}