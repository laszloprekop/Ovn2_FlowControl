namespace Ovn2_FlowControl.Contracts;

public interface IConsoleAdapter
{
    void WriteLine(string text);
    void WriteResult(string text);
    void Write(string text);
    string? ReadLine(string prompt);
    string Select(string prompt, string[] choices, int activeIndex = -1);
}