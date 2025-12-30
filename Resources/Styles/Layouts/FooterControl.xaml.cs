using Files.Helpers;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Files.Resources.Styles.Layouts
{
    public partial class FooterControl : UserControl
    {
        private DispatcherTimer? _pingTimer;

        public FooterControl()
        {
            InitializeComponent();

            LoadStaticInfo();
            LoadTime();
            StartPing();
        }

        private void LoadStaticInfo()
        {
            string _key_active = Properties.Settings.Default.key_active;
            string _public_ip = Properties.Settings.Default.public_ip;

            tb_key.Text = "Key: " + (string.IsNullOrWhiteSpace(_key_active) ? "..." : _key_active);
            tb_public_ip.Text = "IP: " + (string.IsNullOrWhiteSpace(_public_ip) ? "..." : _public_ip);
        }

        private void StartPing()
        {
            _pingTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };

            _pingTimer.Tick += async (s, e) =>
            {
                long ping = await PingServerAsync("148.113.195.241");

                tb_ping.Text = ping >= 0
                    ? $"{ping} ms"
                    : "Offline";
            };

            _pingTimer.Start();
        }

        private void LoadTime()
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };

            timer.Tick += (s, e) =>
            {
                tb_timer.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            };

            timer.Start();
        }

        public static async Task<long> PingServerAsync(string ip)
        {
            try
            {
                using var ping = new Ping();
                var reply = await ping.SendPingAsync(ip, 1000);
                return reply.Status == IPStatus.Success ? reply.RoundtripTime : -1;
            }
            catch
            {
                return -1;
            }
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!DataBaseHelper.Initialize())
            {
                tb_data.Text = "Not connected...";
                var result = new ChangePageHelper().Url("/Views/Pages/DataBaseConfigPage.xaml");
                if (!result.success)
                {
                    LogHelper.add(result.message);
                }
            }    
            else
                tb_data.Text = "Connect success...";
        }
    }
}
