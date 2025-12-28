using Files.Properties;
using System.Windows;

namespace Quan_Ly_Ban_Hang_2026
{

    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Systems.Default.Application_Path = AppDomain.CurrentDomain.BaseDirectory;
            Systems.Default.Save();

        }

    }

}
