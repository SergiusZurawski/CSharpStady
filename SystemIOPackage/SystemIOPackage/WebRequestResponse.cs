using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SystemIOPackage
{
    public class WebRequestResponse
    {
        public static void Example()
        {
            WebRequest request = WebRequest.Create("http://www.microsoft.com");
            WebResponse response = request.GetResponse();

            StreamReader responseStream = new StreamReader(response.GetResponseStream());
            string responseText = responseStream.ReadToEnd();

            Console.WriteLine(responseText); // Displays the HTML of the website 
            response.Close();
        }

        //async HTTP request
        public static async Task ExampleAsync()
        {
            await ReadAsyncHttpRequest();
        }
        public static async Task ReadAsyncHttpRequest()
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync("http://www.microsoft.com"); 
        }

    }
}
