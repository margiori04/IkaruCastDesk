using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IkaruCast;

public partial class FullscreenWindow : Window
{
    public FullscreenWindow()
    {
        InitializeComponent();
        Loaded += (_, _) =>
        {
            var screen = System.Windows.Forms.Screen.FromHandle(
                new System.Windows.Interop.WindowInteropHelper(this).Handle);
            var b = screen.Bounds;
            Left = b.Left; Top = b.Top; Width = b.Width; Height = b.Height;
        };
    }

    public void SetFrame(ImageSource? src)
    {
        VideoImage.Source = src;
    }

    private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if (e.Key == Key.Escape) { Close(); e.Handled = true; }
        if (e.Key == Key.D0 && (Keyboard.Modifiers & ModifierKeys.Control) != 0)
        {
            VideoScale.ScaleX = VideoScale.ScaleY = 1;
            VideoTranslate.X = VideoTranslate.Y = 0;
        }
    }

    private void Window_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e) => Close();

    private void Host_ManipulationDelta(object? sender, System.Windows.Input.ManipulationDeltaEventArgs e)
    {
        VideoScale.ScaleX = Math.Clamp(VideoScale.ScaleX * e.DeltaManipulation.Scale.X, 1, 5);
        VideoScale.ScaleY = Math.Clamp(VideoScale.ScaleY * e.DeltaManipulation.Scale.Y, 1, 5);
        if (VideoScale.ScaleX > 1.01)
        {
            VideoTranslate.X += e.DeltaManipulation.Translation.X;
            VideoTranslate.Y += e.DeltaManipulation.Translation.Y;
        }
        else { VideoTranslate.X = 0; VideoTranslate.Y = 0; }
        e.Handled = true;
    }

    private void Host_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
    {
        double f = e.Delta > 0 ? 1.1 : 1 / 1.1;
        VideoScale.ScaleX = Math.Clamp(VideoScale.ScaleX * f, 1, 5);
        VideoScale.ScaleY = Math.Clamp(VideoScale.ScaleY * f, 1, 5);
        if (VideoScale.ScaleX <= 1.01) { VideoTranslate.X = 0; VideoTranslate.Y = 0; }
        e.Handled = true;
    }
}
