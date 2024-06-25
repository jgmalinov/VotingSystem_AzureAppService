using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using VotingSystemWebApp.Data;
using VotingSystemWebApp.Models;

namespace VotingSystemWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);
            var environment = builder.Environment.EnvironmentName;
            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<VotingSystemDbContext>(options =>
            {
                if (environment == "Development")
                {
                    options.UseSqlite(builder.Configuration.GetConnectionString("Development"));
                }
                else
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("Production"));
                }
            });

            var app = builder.Build();
            
            // Initialize seeds the db. It needs a VotingSystemDbContext to connect. The context options which come from the ServiceProvider
            // We create a scope and create a ServiceProvider in it, and pass to Initialize.
            // We dispose of the scope after the db has been seeded to free up memory.
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                SeedData.Initialize(services);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}