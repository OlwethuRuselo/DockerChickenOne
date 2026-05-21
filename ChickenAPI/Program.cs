using ChickenAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ChickenAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<FarmDbContext>(options =>
                options.UseSqlServer(Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING")));

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (true)
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options =>
                {
                    //Tell swagger ui to look at the native .NET OpenApi endpoint
                    options.SwaggerEndpoint("/openapi/v1.json", "Chicken API v1");
                    options.RoutePrefix = "swagger";
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
