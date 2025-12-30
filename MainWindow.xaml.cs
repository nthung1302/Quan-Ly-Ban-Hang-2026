using Files.Helpers;
using Files.Properties;
using System;
using System.Net.NetworkInformation;
using System.Windows;

namespace Files
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // ===== WINDOW STYLE =====
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            var wa = SystemParameters.WorkArea;
            Left = wa.Left;
            Top = wa.Top;
            Width = wa.Width;
            Height = wa.Height;

            Loaded += MainWindow_Loaded;

        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if(Settings.Default.PublicIP == "")
                {
                    string publicIP = await NetworkHelper.GetPublicIPAsync();
                    Settings.Default.PublicIP = publicIP;
                    Settings.Default.Save();
                }
            }
            catch
            {
                Settings.Default.PublicIP = "UNKNOWN";
            }

            // ===== FIRST RUN =====
            bool isFirstRun = Systems.Default.IsFirstRun;

            if (isFirstRun)
            {
                Settings.Default.ApplicationPath = AppDomain.CurrentDomain.BaseDirectory;
                Settings.Default.Save();

                Systems.Default.IsFirstRun = false;
                Systems.Default.Save();

                MainPage.Navigate(new Views.Pages.FirstPage());
            }

            MainPage.Navigate(new Views.Pages.FirstPage());
        }

     
    }
}
