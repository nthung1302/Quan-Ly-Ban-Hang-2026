using Files.Helpers;
using System.Windows;
using System.Windows.Controls;

namespace Files.Views.Pages
{
    /// <summary>
    /// Interaction logic for FirstPage.xaml
    /// </summary>
    public partial class FirstPage : Page
    {
        public FirstPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var result = new ChangePageHelper().Url("/Views/Pages/LoginPage.xaml");

            if (!result.success)
            {
                MessageBox.Show(result.message);
            }
        }

        private void BtnRegister_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var result = new ChangePageHelper().Url("/Views/Pages/CreateAccountPage.xaml");

            if (!result.success)
            {
                MessageBox.Show(result.message);
            }

        }
    }
}
