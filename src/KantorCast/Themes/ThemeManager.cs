using System.Windows.Media;
using Application = System.Windows.Application;
using Color = System.Windows.Media.Color;

namespace IkaruCast.Themes;

public enum AppTheme { System, Light, Dark }

public static class ThemeManager
{
    public static AppTheme Current { get; private set; } = AppTheme.System;

    public static void Apply(AppTheme theme)
    {
        Current = theme;
        bool dark = theme == AppTheme.Dark;
        if (theme == AppTheme.System)
        {
            try
            {
                var v = Microsoft.Win32.Registry.GetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize",
                    "AppsUseLightTheme", 1);
                dark = v is int i && i == 0;
            }
            catch { dark = false; }
        }

        var app = Application.Current;
        if (app?.Resources is null) return;

        void Set(string key, Color c) => app.Resources[key] = new SolidColorBrush(c);

        if (dark)
        {
            Set("Bg", Color.FromRgb(0x0D, 0x0F, 0x14));
            Set("Surface", Color.FromRgb(0x16, 0x19, 0x22));
            Set("Surface2", Color.FromRgb(0x1E, 0x22, 0x2E));
            Set("Border", Color.FromRgb(0x32, 0x38, 0x48));
            Set("Text", Color.FromRgb(0xF0, 0xF2, 0xF8));
            Set("Muted", Color.FromRgb(0xA8, 0xB0, 0xC4));
            Set("Accent", Color.FromRgb(0x6B, 0x9A, 0xFF));
            Set("AccentSoft", Color.FromRgb(0x1A, 0x28, 0x48));
            Set("Sidebar", Color.FromRgb(0x3A, 0x68, 0xD4));
            Set("Danger", Color.FromRgb(0xF0, 0x6A, 0x7A));
            Set("Ok", Color.FromRgb(0x45, 0xD0, 0x95));
            Set("SenderAccent", Color.FromRgb(0x6B, 0x9A, 0xFF));
            Set("ReceiverAccent", Color.FromRgb(0x8B, 0x70, 0xFF));
            Set("PreviewBg", Color.FromRgb(0x12, 0x14, 0x1C));
            Set("PreviewText", Color.FromRgb(0xC8, 0xD0, 0xE0));
            Set("PreviewMuted", Color.FromRgb(0x90, 0x98, 0xB0));
            Set("ConsentOverlay", Color.FromArgb(0xCC, 0x0D, 0x0F, 0x14));
        }
        else
        {
            Set("Bg", Color.FromRgb(0xF0, 0xF4, 0xFA));
            Set("Surface", Color.FromRgb(0xFF, 0xFF, 0xFF));
            Set("Surface2", Color.FromRgb(0xF5, 0xF7, 0xFB));
            Set("Border", Color.FromRgb(0xE0, 0xE6, 0xF0));
            Set("Text", Color.FromRgb(0x1A, 0x1F, 0x2E));
            Set("Muted", Color.FromRgb(0x6A, 0x74, 0x8A));
            Set("Accent", Color.FromRgb(0x3D, 0x6F, 0xDB));
            Set("AccentSoft", Color.FromRgb(0xE8, 0xF0, 0xFE));
            Set("Sidebar", Color.FromRgb(0x3D, 0x6F, 0xDB));
            Set("Danger", Color.FromRgb(0xE0, 0x5A, 0x6A));
            Set("Ok", Color.FromRgb(0x3D, 0xBF, 0x8A));
            Set("SenderAccent", Color.FromRgb(0x3D, 0x6F, 0xDB));
            Set("ReceiverAccent", Color.FromRgb(0x5B, 0x6B, 0xEF));
            Set("PreviewBg", Color.FromRgb(0x1A, 0x15, 0x28));
            Set("PreviewText", Color.FromRgb(0xD0, 0xC8, 0xE8));
            Set("PreviewMuted", Color.FromRgb(0x9A, 0x90, 0xB0));
            Set("ConsentOverlay", Color.FromArgb(0x99, 0xF3, 0xF0, 0xFA));
        }

        try
        {
            string dir = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "IkaruCastDesk");
            System.IO.Directory.CreateDirectory(dir);
            System.IO.File.WriteAllText(System.IO.Path.Combine(dir, "theme.txt"), theme.ToString());
        }
        catch { }
    }

    public static void LoadSaved()
    {
        try
        {
            string path = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "IkaruCastDesk", "theme.txt");
            if (System.IO.File.Exists(path) &&
                Enum.TryParse<AppTheme>(System.IO.File.ReadAllText(path).Trim(), out var t))
            {
                Apply(t);
                return;
            }
        }
        catch { }
        Apply(AppTheme.System);
    }
}
