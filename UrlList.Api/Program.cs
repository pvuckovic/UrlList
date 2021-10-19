using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UrlList.Api.MyDbContext;

namespace UrlList.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreatWebHostBuilder(args).Build();
            host.Run();
        }

        public static IHostBuilder CreatWebHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
