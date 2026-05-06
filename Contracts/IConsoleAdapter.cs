namespace Ovn2_FlowControl.Contracts;

public interface IConsoleAdapter
{
    void WriteLine(string text);
    void Write(string text);
    string? ReadLine(string prompt);
}