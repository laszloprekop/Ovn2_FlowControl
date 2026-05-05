using System;

namespace Ovn2_FlowControl;

class Header : IViewFragment
{
    private readonly IExercise _exercise;

    public Header(IExercise exercise) => _exercise = exercise;

    public void Render()
    {
        Console.WriteLine(_exercise.Title);
        Console.WriteLine(_exercise.Description);
        Console.WriteLine(new string('─', Math.Max(_exercise.Title.Length, _exercise.Description.Length)));
        Console.WriteLine();
    }
}