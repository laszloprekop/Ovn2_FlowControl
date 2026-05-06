using System.Collections.Generic;
using Ovn2_FlowControl.Contracts;
using Ovn2_FlowControl.Exercises;
using Ovn2_FlowControl.UI;

namespace Ovn2_FlowControl
{
    internal static class Program
    {
        private static void Main()
        {
            var exercises = new List<IExercise>
            {
                new SingleTicketExercise(),
                new GroupTicketExercise(),
                new RepeatTextExercise(),
                new ThirdWordExercise()
            };
            new Menu(exercises).Run();
        }
    }
}