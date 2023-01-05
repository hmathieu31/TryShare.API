using INSAT._4I4U.TryShare.Core.Interfaces.Services;
using INSAT._4I4U.TryShare.Core.Models;
using INSAT._4I4U.TryShare.Core.Services.Tricycles;
using INSAT._4I4U.TryShare.Infrastructure.Repository;
using INSAT._4I4U.TryShare.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Diagnostics;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using INSAT._4I4U.TryShare.Infrastructure.Data;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace INSAT._4I4U.TryShare.TricyclesAvailable
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.RegisterServices();

            // Add logging for the application.
            builder.Services.AddLogging();

            // Add the DbContext to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                providerOptions => providerOptions.EnableRetryOnFailure()));


            // Add the database exception filter
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TryShare API",
                    Version = "v1",
                    Description = "An ASP.NET Core Web API for TryShare tricycle project",
                });
            });

            var app = builder.Build();

            // Initialise database if not done already
            //using (var scope = app.Services.CreateScope())
            //{
            //    var initialiser = scope.ServiceProvider.GetRequiredService<DbInitialiser>();
            //    initialiser.Run();
            //    // Free all tricycles on startup
            //    initialiser.FreeTricycles();
            //}

            // Apply migrations
            //using (var context = app.Services.GetRequiredService<ApplicationDbContext>())
            //{
            //    context.Database.Migrate();
            //}


            app.UseSwagger();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddScoped<IRepository<Tricycle>, TricycleRepository>()
                .AddTransient<DbInitialiser>()
                .AddScoped<ITricyleService, TricyclesService>();

            return builder;
        }
    }
}