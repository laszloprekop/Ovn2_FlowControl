using System.Collections.Generic;
using System.Globalization;
using System.Resources;

namespace Ovn2_FlowControl.Localization;

public static class Loc
{
    private static readonly ResourceManager Rm = new("Ovn2_FlowControl.Resources.Strings", typeof(Loc).Assembly);

    private static readonly Dictionary<string, CultureInfo> Supported = new()
    {
        { "en", new CultureInfo("en") },
        { "sv", new CultureInfo("sv") },
        { "el", new CultureInfo("el") },
        { "hu", new CultureInfo("hu") }
    };

    private static CultureInfo _culture = DetectCulture();

    public static string Get(string key) => Rm.GetString(key, _culture) ?? key;

    public static void SetCulture(CultureInfo culture) => _culture = culture;

    public static CultureInfo CurrentCulture => _culture;

    // Maps system UI locale → nearest supported; falls back to English
    private static CultureInfo DetectCulture()
    {
        var tag = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
        return Supported.TryGetValue(tag, out var match) ? match : Supported["en"];
    }
}