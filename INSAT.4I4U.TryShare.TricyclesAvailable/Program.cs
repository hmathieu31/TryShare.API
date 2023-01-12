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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Logging;

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

            // Configure authentication and authentification
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(builder.Configuration);
            builder.Services.AddAuthorization();

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

            app.UseSwagger();
            app.UseSwaggerUI();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

#pragma warning disable ASP0014 // Suggest using top level route registrations
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
#pragma warning restore ASP0014 // Suggest using top level route registrations

            // Debug configuration: do not hide personal information in exceptions
            // Remove after debug
            IdentityModelEventSource.ShowPII = true;


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