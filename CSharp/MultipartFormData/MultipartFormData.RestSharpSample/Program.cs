using System;
using System.Net;
// install RestSharp >= 104.2.0 from NuGet
using RestSharp;

namespace MultipartFormData.RestSharpSample
{
    internal class Program
    {
        private static void Main(string[] args) {
            var url = "https://api.alpinebits.dev/endpoint";
            var username = "username";
            var password = "password";

            var request = new RestRequest("/", Method.POST) {
                Credentials = new NetworkCredential(username, password),
                AlwaysMultipartFormData = true
            };

            request.AddParameter("action", "getVersion", ParameterType.GetOrPost);
            //request.AddParameter("request", "<xml></xml>", ParameterType.GetOrPost);

            var client = new RestClient(url);
            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK) {
                Console.WriteLine("Endpoint returned version: '{0}'", response.Content);
            } else {
                Console.WriteLine("Request failed.");
                Console.WriteLine("Status code: '{0}'", response.StatusCode);
                Console.WriteLine("Error message: '{0}'", response.ErrorMessage);
            }
            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }
    }
}
