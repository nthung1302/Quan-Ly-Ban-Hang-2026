using Files.Helpers;
using Files.Properties;
using System.Windows;

namespace Files
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            var wa = SystemParameters.WorkArea;
            Left = wa.Left;
            Top = wa.Top;
            Width = wa.Width;
            Height = wa.Height;

            LogHelper.add("Application started.");

            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            (bool success, string message) result;

            try
            {
                if (string.IsNullOrEmpty(Settings.Default.public_ip))
                {
                    string _public_ip = await NetworkHelper.GetPublicIPAsync();
                    Settings.Default.public_ip = _public_ip;
                    Settings.Default.Save();
                }
            }
            catch
            {
                Settings.Default.public_ip = "UNKNOWN";
            }

            bool _is_first_run = Systems.Default.is_first_run;

            if (_is_first_run)
            {
                result = new ChangePageHelper().Url("/Views/Pages/FirstPage.xaml");
            }
            else
            {
                result = new ChangePageHelper().Url("/Views/Pages/LoginPage.xaml");
            }

            if (!result.success)
            {
                MessageBox.Show(result.message);
            }
        }
    }
}
