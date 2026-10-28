using System.Windows;
using IkaruCast.Themes;

namespace IkaruCast;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        ThemeManager.LoadSaved();
    }
}
