using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Admin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(options =>
                {
                    options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(35);
                    options.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(35);
                })
                .UseStartup<Startup>();
    }
}
