using System.Windows.Controls;

namespace Files.Resources.Styles.Layouts
{

    public partial class TitleBarControl : UserControl
    {
        public TitleBarControl()
        {
            InitializeComponent();
        }

        private void logo_keydown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }

        private void btn_mini_size_click(object sender, System.Windows.RoutedEventArgs e)
        {
            var window = System.Windows.Window.GetWindow(this);
            window.WindowState = System.Windows.WindowState.Minimized;
        }

        private void btn_restore_size_click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void btn_close_window_click(object sender, System.Windows.RoutedEventArgs e)
        {
            var window = System.Windows.Window.GetWindow(this);
            window.Close();
        }

    }
}
