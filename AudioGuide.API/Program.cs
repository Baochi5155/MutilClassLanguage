
using AudioGuide.DAL;
using Microsoft.EntityFrameworkCore;
using AudioGuide.BLL.Services;
using Scalar.AspNetCore;

namespace AudioGuide.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi(); // Dùng OpenAPI gốc của .NET 9

            // (Các cấu hình DbContext, AddScoped giữ nguyên)

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(); // Giao diện API trực quan thay thế Swagger UI
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
