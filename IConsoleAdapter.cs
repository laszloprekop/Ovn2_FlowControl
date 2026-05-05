namespace Ovn2_FlowControl;

public interface IConsoleAdapter
{
    void WriteLine(string text);
    void Write(string text);
    string? ReadLine();
}