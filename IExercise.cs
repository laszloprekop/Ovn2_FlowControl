namespace Ovn2_FlowControl;

public interface IExercise
{
    string Title { get; } // menu reads this without the concrete type
    string Description { get; }
    void Run(IConsoleAdapter console);
}