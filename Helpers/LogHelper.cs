using System.IO;
using System.Windows;

namespace Files.Helpers
{
    internal class LogHelper
    {
        private static readonly object _lock = new object();

        public static void add (string message)
        {
            string _log_message = $"{DateTime.Now:HH:mm:ss}: {message}";

            string _folder_path = Properties.FilePath.Default._temp_path;

            try
            {
                string logFolder = Path.Combine(Directory.GetCurrentDirectory(), string.IsNullOrWhiteSpace(_folder_path) ? "Tems" : _folder_path);

                if (!Directory.Exists(logFolder))
                    Directory.CreateDirectory(logFolder);

                string fileName = $"log-{DateTime.Now:yyyy-MM-dd}.txt";
                string filePath = Path.Combine(logFolder, fileName);

                lock (_lock)
                {
                    File.AppendAllText(filePath, _log_message + Environment.NewLine);
                }
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message); 
            }
        }
    }
}
