using System.Windows;
using IkaruCast.Themes;

namespace IkaruCast;

public partial class ModeSelectWindow : Window
{
    public ModeSelectWindow()
    {
        InitializeComponent();
    }

    private void Sender_Click(object sender, RoutedEventArgs e)
    {
        var w = new SenderWindow();
        w.Closed += (_, _) =>
        {
            if (System.Windows.Application.Current.Windows.Count == 0)
                System.Windows.Application.Current.Shutdown();
        };
        System.Windows.Application.Current.MainWindow = w;
        w.Show();
        Close();
    }

    private void Receiver_Click(object sender, RoutedEventArgs e)
    {
        var w = new ReceiverWindow();
        w.Closed += (_, _) =>
        {
            if (System.Windows.Application.Current.Windows.Count == 0)
                System.Windows.Application.Current.Shutdown();
        };
        System.Windows.Application.Current.MainWindow = w;
        w.Show();
        Close();
    }

    private async void CheckUpdate_Click(object sender, RoutedEventArgs e) => await AppUpdate.CheckAsync(this);
    private void ThemeLight_Click(object sender, RoutedEventArgs e) => ThemeManager.Apply(AppTheme.Light);
    private void ThemeDark_Click(object sender, RoutedEventArgs e) => ThemeManager.Apply(AppTheme.Dark);
    private void ThemeSystem_Click(object sender, RoutedEventArgs e) => ThemeManager.Apply(AppTheme.System);
}
