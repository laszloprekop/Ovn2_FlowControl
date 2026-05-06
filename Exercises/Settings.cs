using System.Collections.Generic;
using System.Globalization;
using Ovn2_FlowControl.Contracts;
using Ovn2_FlowControl.Localization;
using Spectre.Console;

namespace Ovn2_FlowControl.Exercises;

public class Settings : ExerciseBase
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
    
    public Settings()
        : base("settings_title", "settings_desc"){}

    public override void Run(IConsoleAdapter console)
    {
        var prompt = new SelectionPrompt<string>()
            .Title(Loc.Get("settings_prompt"))
            .AddChoices(Languages.Keys);
        
        var selected = AnsiConsole.Prompt(prompt);
        var tag = Languages[selected];
        
        Loc.SetCulture(CultureInfo.GetCultureInfo(tag));
        SettingsStore.Save(tag);
        console.WriteLine(Loc.Get("settings_saved"));
    }
}