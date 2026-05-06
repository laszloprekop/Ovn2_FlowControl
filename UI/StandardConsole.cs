using System;
using Ovn2_FlowControl.Contracts;

namespace Ovn2_FlowControl.UI;

public class StandardConsole : IConsoleAdapter

{
    public void WriteLine(string text) => Console.WriteLine(text);

    public void WriteResult(string text)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    public void Write(string text) => Console.Write(text);

    public string? ReadLine(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    public string Select(string prompt, string[] choices, int activeIndex = -1)
    {
        Console.WriteLine(prompt);
        for (int i = 0; i < choices.Length; i++)
            Console.WriteLine($"  [{i + 1}] {choices[i]}");
        while (true)
        {
            Console.Write("> ");
            if (int.TryParse(Console.ReadLine(), out int num) && num >= 1 && num <= choices.Length)
                return choices[num - 1];
            Console.WriteLine("Invalid choice.");
        }
    }
}