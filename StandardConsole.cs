using System;

namespace Ovn2_FlowControl;

public class StandardConsole : IConsoleAdapter

{
    public void WriteLine(string text) => Console.WriteLine(text);
    public void Write(string text) => Console.Write(text);

    public string? ReadLine(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }
}