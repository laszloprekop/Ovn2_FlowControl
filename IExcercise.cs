namespace FlowControl;

public interface IExcercise
{
    string Title { get; } // menu reads this without the concrete type
    void Run();
}