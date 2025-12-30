using System.Windows.Controls;

namespace Files.Resources.Styles.Layouts
{
    /// <summary>
    /// Interaction logic for TitleBarControl.xaml
    /// </summary>
    public partial class TitleBarControl : UserControl
    {
        public TitleBarControl()
        {
            InitializeComponent();
        }

        private void Minisize_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var window = System.Windows.Window.GetWindow(this);
            window.WindowState = System.Windows.WindowState.Minimized;
        }

        private void Restoresize_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var window = System.Windows.Window.GetWindow(this);
        }

        private void Maxsize_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var window = System.Windows.Window.GetWindow(this);
            window.WindowState = System.Windows.WindowState.Maximized;
        }

        private void CloseWindow_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var window = System.Windows.Window.GetWindow(this);
            window.Close();
        }
    }
}
