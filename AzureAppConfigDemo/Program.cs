﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

namespace AzureAppConfigDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
             .ConfigureAppConfiguration((hostingContext, config) =>
             {
                 var settings = config.Build();
                 config.AddAzureAppConfiguration(options =>
                 {
                     options.Connect(settings["ConnectionStrings:AppConfig"])
                         .UseFeatureFlags();
                 });
             })
                .UseStartup<Startup>();
    }
}
