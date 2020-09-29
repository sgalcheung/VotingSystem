using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VotingSystem.Data;

namespace VotingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>(); var context = services.GetService<ApplicationDbContext>();
                var connectionString = services.GetService<IConfiguration>().GetConnectionString("DefaultConnection");
                try
                {
                    logger.LogInformation("Migrating database associated with context " + typeof(ApplicationDbContext).Name);
                    logger.LogInformation("Connection string is " + connectionString);
                    context.Database.Migrate();
                    logger.LogInformation("Migrated database associated with context " + typeof(ApplicationDbContext).Name);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while migrating the database used on context " + typeof(ApplicationDbContext).Name);
                }
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
