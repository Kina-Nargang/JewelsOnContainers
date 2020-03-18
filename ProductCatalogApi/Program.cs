using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProductCatalogApi.Data;

namespace ProductCatalogApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            // before run, build services first
            // host = startup
            var host = CreateHostBuilder(args).Build();

            // CreateScope() means how your services are coming along
            // using guarantees that object to be disposed
            using (var scope = host.Services.CreateScope())
            {
                // ask for each service providers
                var serviceproviders = scope.ServiceProvider;
                // get the one provider of providers
                // get a reference from the context
                // it will wait for this service(CatalogContext) is available then give the pointer to context
                var context = serviceproviders.GetRequiredService<CatalogContext>();

                // after get context then it is guaranteed that CatalogContext is ready
                // then we can push data into tables
                CatalogSeed.Seed(context);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
