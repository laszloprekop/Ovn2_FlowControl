using System;
using Ovn2_FlowControl.Contracts;

namespace Ovn2_FlowControl.UI;

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