using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Net;


namespace TodoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel(options => options.Listen(IPAddress.Any, 5050));
    }
}
