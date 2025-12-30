using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
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
            string activeKey = Properties.Settings.Default.KeyActive;
            string publicIP = Properties.Settings.Default.PublicIP;

            TbKey.Text = "Your Key: " + (string.IsNullOrWhiteSpace(activeKey) ? "..." : activeKey);
            TbIpPublic.Text = "Your IP: " + (string.IsNullOrWhiteSpace(publicIP) ? "..." : publicIP);
        }

        // 🔥 Ping liên tục
        private void StartPing()
        {
            _pingTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };

            _pingTimer.Tick += async (s, e) =>
            {
                long ping = await PingServerAsync("148.113.195.241");

                TbPing.Text = ping >= 0
                    ? $"Ping: {ping} ms"
                    : "Ping: Offline";
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
                TbTimer.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
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
    }
}
