using AudioGuide.BLL.Services;
using AudioGuide.DAL;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace AudioGuide.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddOpenApi(); // OpenAPI gốc của .NET 9

        // 1. Cấu hình DbContext dùng InMemory Database để test nhanh
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("AudioGuideDb"));

        // 2. Đăng ký Dependency Injection cho tầng BLL
        builder.Services.AddScoped<IAudioGuideService, AudioGuideService>();

        // 3. Cấu hình CORS để Web (React) và Mobile (React Native) gọi API không bị chặn
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });
        var app = builder.Build();

        // Sử dụng CORS cho tất cả request
        app.UseCors();

        // Đóng comment hoặc xóa app.UseHttpsRedirection() khi chạy trên Docker/Render
        // app.UseHttpsRedirection();
        // Tự động nạp dữ liệu mẫu vào InMemory Database khi khởi động
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.EnsureCreated();
        }

        app.MapOpenApi();
        app.MapScalarApiReference();

        app.UseHttpsRedirection();

        // Kích hoạt CORS trước Authorization
        app.UseCors("AllowAll");

        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}