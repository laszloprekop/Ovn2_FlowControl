namespace Ovn2_FlowControl;

public class RepeatTextExercise : ExerciseBase
{
    public RepeatTextExercise() : base("Text Repeater", "Repeats the provided text 10 times") { }
    
    public override void Run(IConsoleAdapter console)
    {
        string? text = console.ReadLine("Skriv en text: ");

        for (int i = 1; i <= 10; i++)
        {
            console.Write($"{i}. {text} ");
        }

        console.WriteLine("");

    }
}