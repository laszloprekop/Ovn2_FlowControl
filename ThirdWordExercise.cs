using System;

namespace Ovn2_FlowControl;

public class ThirdWordExercise : IExercise
{
    public string Title => "What's the Third Word?";

    public void Run()
    {
        Console.Write("Skriv en mening med minst 3 ord: ");
        string? mening = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(mening))
        {
            Console.WriteLine("Du måste skriva en mening.");
            return;
        }

        string[] ord = mening.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (ord.Length < 3)
        {
            Console.WriteLine("Mening måste innehålla minst 3 ord.");
            return;
        }

        Console.WriteLine($"Det tredje ordet är: {ord[2]}");
    }
}