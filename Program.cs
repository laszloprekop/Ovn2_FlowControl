using System.Collections.Generic;

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