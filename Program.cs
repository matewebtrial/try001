using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ConsoleAppCoreWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = new WebHostBuilder()
                .UseUrls("http://192.168.194.155", "https://192.168.194.155")
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}