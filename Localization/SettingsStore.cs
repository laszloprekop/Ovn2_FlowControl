using System;
using System.IO;
using System.Text.Json;

namespace Ovn2_FlowControl.Localization;

public class SettingsStore
{
    private static readonly string SettingsFilePath = Path.Combine(AppContext.BaseDirectory, "settings.json");

    public static string? Load()
    {
        if (!File.Exists(SettingsFilePath)) return null;
        var json = File.ReadAllText(SettingsFilePath);
        var doc = JsonDocument.Parse(json);
        return doc.RootElement.TryGetProperty("language", out var lang)
            ? lang.GetString()
            : null;
    }

    public static void Save(string languageTag)
    {
        var json = JsonSerializer.Serialize(new { language = languageTag });
        File.WriteAllText(SettingsFilePath, json);
    }
}