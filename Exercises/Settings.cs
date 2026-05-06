using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Ovn2_FlowControl.Contracts;
using Ovn2_FlowControl.Localization;

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
        var names = Languages.Keys.ToArray();
        var currentTag = Loc.CurrentCulture.TwoLetterISOLanguageName;
        var activeIndex = Array.FindIndex(names, n => Languages[n] == currentTag);
        var selected = console.Select(Loc.Get("settings_prompt"), names, activeIndex);
        var tag = Languages[selected];

        Loc.SetCulture(CultureInfo.GetCultureInfo(tag));
        SettingsStore.Save(tag);
        console.WriteLine(Loc.Get("settings_saved"));
    }
}