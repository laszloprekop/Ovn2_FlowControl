using Ovn2_FlowControl.Contracts;
using Ovn2_FlowControl.Localization;

namespace Ovn2_FlowControl.Exercises;

public abstract class ExerciseBase : IExercise
{
    private readonly string _titleKey;
    private readonly string _descriptionKey;

    protected ExerciseBase(string titleKey, string descriptionKey)
    {
        _titleKey = titleKey;
        _descriptionKey = descriptionKey;
    }

    public string Title => Loc.Get(_titleKey);
    public string Description => Loc.Get(_descriptionKey);
    
    public abstract void Run(IConsoleAdapter console);
    public override string ToString() => $"{Title} - {Description}";
}