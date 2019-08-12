using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Net;

namespace ConsoleAppCoreWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {

            string strHostName = string.Empty;
            // Getting Ip address of local machine...
            // First get the host name of local machine.
            strHostName = Dns.GetHostName();
            // Then using host name, get the IP address list..
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;

            for (int i = 0; i < addr.Length; i++)
            {
                System.Console.Write("IP Address {0}: {1} ", i, addr[i].ToString());
            }

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