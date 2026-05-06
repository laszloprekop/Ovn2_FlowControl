namespace Ovn2_FlowControl;

public abstract class ExerciseBase : IExercise
{
    public string Title { get; }
    public string Description { get; }

    protected ExerciseBase(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public abstract void Run(IConsoleAdapter console);
    public override string ToString() => $"{Title} - {Description}";
}