using System.Net.Http;

namespace Files.Helpers
{
    public static class NetworkHelper
    {
        public static async Task<string> GetPublicIPAsync()
        {
            using HttpClient client = new HttpClient();
            return await client.GetStringAsync("https://api.ipify.org");
        }
    }
}
