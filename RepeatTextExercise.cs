namespace Ovn2_FlowControl;

public class RepeatTextExercise : IExercise
{
    public string Title => "Text Repeater";
    public string Description => "Repeats the provided text 10 times";

    public void Run(IConsoleAdapter console)
    {
        string? text = console.ReadLine("Skriv en text: ");

        for (int i = 1; i <= 10; i++)
        {
            console.Write($"{i}. {text} ");
        }

        console.WriteLine("");

    }
}