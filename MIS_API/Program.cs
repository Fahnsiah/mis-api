using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MIS_API
{
    public class Program
    {
        //public static void Main(string[] args)
        //{
        //    var host = new WebHostBuilder()
        //            .UseKestrel()
        //                 .UseContentRoot(Directory.GetCurrentDirectory())
        //                 .UseIISIntegration()
        //                 .UseStartup<Startup>()
        //                 .Build();
        //    host.Run();
        //}
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
