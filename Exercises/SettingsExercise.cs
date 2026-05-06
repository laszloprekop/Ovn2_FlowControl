using System.Collections.Generic;
using Ovn2_FlowControl.Contracts;
using Ovn2_FlowControl.Localization;
using Spectre.Console;

namespace Ovn2_FlowControl.Exercises;

public class SettingsExercise : ExerciseBase
{
    private static readonly Dictionary<string, string> Languages = new()
    {
        {
            "English", "en"
        },
        {
            "Svenska", "sv"
        },
        {
            "Ελληνικά", "el"
        },
        {
            "Magyar", "hu"
        }
    };
    
    public SettingsExercise()
        : base("exercise_settings_title", "exercise_settings_desc"){}

    public override void Run(IConsoleAdapter console)
    {
        var prompt = new SelectionPrompt<string>()
            .Title(Loc.Get("exercise_settings_prompt_lang"))
            .AddChoices(Languages.Keys);
        
        var selected = AnsiConsole.Prompt(prompt);
        var tag = Languages[selected];
    }
}