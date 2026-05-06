using System;
using Ovn2_FlowControl.Contracts;
using Ovn2_FlowControl.Localization;

namespace Ovn2_FlowControl.Exercises;

public class ThirdWordExercise : ExerciseBase
{
    public ThirdWordExercise() : base("exercise_word_title", "exercise_word_desc") { }

    public override void Run(IConsoleAdapter console)
    {
        console.WriteLine(Loc.Get("exercise_word_prompt"));
        string? mening = console.ReadLine("");

        if (string.IsNullOrWhiteSpace(mening))
        {
            console.WriteLine(Loc.Get("exercise_word_err_empty"));
            return;
        }

        string[] ord = mening.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (ord.Length < 3)
        {
            console.WriteLine(Loc.Get("exercise_word_err_short"));
            return;
        }

        console.WriteResult(string.Format(Loc.Get("exercise_word_result"), ord[2]));
    }
}