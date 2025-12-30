using System.Windows;

namespace Files.Helpers
{
    public class ChangePageHelper
    {
        public (bool success, string message) Url (string PageUrl)
        {
            try {

                if (string.IsNullOrEmpty(PageUrl))
                {
                    return (false, "PageUrl is null or empty.");
                }

                var mainWindow = Application.Current.MainWindow as MainWindow;

                if (mainWindow?.MainPage != null)
                {
                    mainWindow.MainPage.Navigate( new Uri(PageUrl, UriKind.Relative));
                }

                return (true, "Navigation successful.");

            } catch (Exception ex) { 

                return (false, ex.Message);

            }
            
        }
    }
}
