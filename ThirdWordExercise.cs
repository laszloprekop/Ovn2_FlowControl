using System;

namespace Ovn2_FlowControl;

public class ThirdWordExercise : ExerciseBase
{
    public ThirdWordExercise() : base("What's the Third Word?", "Finds the third word in a sentence") { }

    public override void Run(IConsoleAdapter console)
    {
        string? mening = console.ReadLine("Skriv en mening med minst 3 ord: ");

        if (string.IsNullOrWhiteSpace(mening))
        {
            console.WriteLine("Du måste skriva en mening.");
            return;
        }

        string[] ord = mening.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (ord.Length < 3)
        {
            console.WriteLine("Mening måste innehålla minst 3 ord.");
            return;
        }

        console.WriteLine($"Det tredje ordet är: {ord[2]}");
    }
}