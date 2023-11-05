using Infrastructure.DependencyInjection;
using Ui.DependencyInjection;

namespace TestDoctorApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddControllers();
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddWebUIServices();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials() // Allow cookies to be sent
                        .WithOrigins("http://localhost:5173"); // Replace with the actual origin of your React.js frontend
                });
            });



            var app = builder.Build();
            // Configure the HTTP request pipeline.
            app.UseCors();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}