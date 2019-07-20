using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabblyApi.Data;

namespace RabblyApi.Tests.IntegrationTests
{
    public class CustomWebAppFactory<TStartup> : WebApplicationFactory<RabblyApi.Api.Startup>
    {
        public DatabaseContext MyDbContext
        {
            get
            {
                return this.Server.Host.Services.GetService(typeof(DatabaseContext)) as DatabaseContext;
            }
        }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

                services.AddDbContext<DatabaseContext>(opt =>
                {
                    opt.UseInMemoryDatabase("rabbly");
                    opt.UseInternalServiceProvider(serviceProvider);
                }, ServiceLifetime.Singleton);

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var appDb = scopedServices.GetRequiredService<DatabaseContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebAppFactory<TStartup>>>();
                    // Why does this make everything error out...?
                    appDb.Database?.EnsureCreated();

                    // try
                    // {
                    //     appDb.Database.Migrate();
                    // }
                    // catch(Exception ex)
                    // {
                    //     logger.LogError(ex, "Could not migrate DB");
                    // }
                    // finally
                    // {
                    //     logger.LogDebug("Made it here");
                    // }
                }
            });
        }
    }
}