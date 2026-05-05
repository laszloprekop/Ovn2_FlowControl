using System;

namespace Ovn2_FlowControl;

public class RepeatTextExercise : IExercise
{
    public string Title => "Text Repeater";
    public string Description => "Repeats the provided text 10 times";

    public void Run(IConsoleAdapter console)
    {
        console.Write("Skriv en text: ");
        string? text = Console.ReadLine();

        for (int i = 1; i <= 10; i++)
        {
            console.Write($"{i}. {text} ");
        }

        Console.WriteLine();

    }
}