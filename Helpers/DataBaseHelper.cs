using Microsoft.Data.SqlClient;

namespace Files.Helpers
{
    public class DataBaseHelper
    {
        private static string? _connectionString;

        public static bool Initialize()
        {
            try
            {
                string data_user = Properties.Data.Default.data_user;
                string data_password = Properties.Data.Default.data_password;
                string data_server = Properties.Data.Default.data_server;
                string data_name = Properties.Data.Default.data_name;
                string data_port = Properties.Data.Default.data_port;

                _connectionString = $"Server={data_server},{data_port};Database={data_name};User Id={data_user};Password={data_password};Connect Timeout=30;TrustServerCertificate=True;";

                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }


        public static SqlConnection GetConnection()
        {
            if (string.IsNullOrEmpty(_connectionString))
                throw new InvalidOperationException(
                    "Chưa khởi tạo kết nối. Gọi dbConnect.Initialize() trước."
                );

            return new SqlConnection(_connectionString);
        }
    }
}
