using INSAT._4I4U.TryShare.Core.Interfaces.Services;
using INSAT._4I4U.TryShare.Core.Models;
using INSAT._4I4U.TryShare.Core.Services.Tricycles;
using INSAT._4I4U.TryShare.Infrastructure;
using INSAT._4I4U.TryShare.Infrastructure.Repository;
using INSAT._4I4U.TryShare.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace INSAT._4I4U.TryShare.TricyclesAvailable
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.RegisterServices();


            // Add the DbContext to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add the database exception filter
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            { 
                app.UseSwagger();
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
                .AddScoped<ITricyleService, TricyclesService>();

            return builder;
        }
    }
}