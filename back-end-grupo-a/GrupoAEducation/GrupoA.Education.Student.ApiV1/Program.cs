using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace GrupoA.Education.Student.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program...");
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.CaptureStartupErrors(true);
                webBuilder.UseSetting("detailedErros", "true");
            }).Build().Run();
        }
    }
}