using System.Collections.Generic;
using System.Globalization;
using Ovn2_FlowControl.Contracts;
using Ovn2_FlowControl.Exercises;
using Ovn2_FlowControl.Localization;
using Ovn2_FlowControl.UI;

namespace Ovn2_FlowControl
{
    internal static class Program
    {
        private static void Main()
        {
            var savedTag = SettingsStore.Load();
            if (savedTag != null)
                Loc.SetCulture(CultureInfo.GetCultureInfo(savedTag));

            var exercises = new List<IExercise>
            {
                new SingleTicketExercise(),
                new GroupTicketExercise(),
                new RepeatTextExercise(),
                new ThirdWordExercise(),
                new Settings()
            };
            new Menu(exercises).Run();
        }
    }
}