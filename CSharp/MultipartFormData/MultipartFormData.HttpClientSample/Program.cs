using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace MultipartFormData.HttpClientSample
{
    internal class Program
    {
        private static void Main(string[] args) {
            var url = "https://api.alpinebits.dev/endpoint";
            var username = "username";
            var password = "password";

            var content = new MultipartFormDataContent(Guid.NewGuid().ToString());
            //Note: it's a best practice to use double-quotes, even when the name doesn't contain spaces:
            content.Add(new StringContent("getVersion"), "\"action\"");
            content.Add(new StringContent("<xml></xml>"), "\"request\"");

            HttpResponseMessage result;
            using (var client = new HttpClient()) {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(string.Format("{0}:{1}", username, password))));
                result = client.PostAsync(url, content).Result;
            }

            if (result.StatusCode == HttpStatusCode.OK) {
                Console.WriteLine("Endpoint returned version: '{0}'", result.Content.ReadAsStringAsync().Result);
            } else {
                Console.WriteLine("Request failed.");
                Console.WriteLine("Status code: '{0}'", result.StatusCode);
                Console.WriteLine("Error message: '{0}'", result.Content.ReadAsStringAsync().Result);
            }
            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }
    }
}
