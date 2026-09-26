using Microsoft.EntityFrameworkCore;
using AudioGuide.DAL.Entities;

namespace AudioGuide.DAL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Poi> Pois => Set<Poi>();
    public DbSet<PoiTranslation> PoiTranslations => Set<PoiTranslation>();
    public DbSet<AccessSession> AccessSessions => Set<AccessSession>();
    public DbSet<AudioGuideItem> AudioGuides => Set<AudioGuideItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Khóa duy nhất: 1 địa điểm không thể có 2 bản dịch trùng cùng một ngôn ngữ
        modelBuilder.Entity<PoiTranslation>()
            .HasIndex(t => new { t.PoiId, t.LanguageCode })
            .IsUnique();

        // Nạp dữ liệu mẫu ban đầu cho Chùa Linh Ứng - Bãi Bụt (Đà Nẵng)
        modelBuilder.Entity<Poi>().HasData(
            new Poi
            {
                Id = 1,
                Name = "Tượng Phật Bà Quan Âm",
                Latitude = 16.1001,
                Longitude = 108.2778,
                ProximityRadius = 20.0,
                ThumbnailUrl = "https://images.unsplash.com/photo-1599831104328-b14176c5b46e",
                DisplayOrder = 1
            },
            new Poi
            {
                Id = 2,
                Name = "Chính Điện Chùa Linh Ứng",
                Latitude = 16.1005,
                Longitude = 108.2782,
                ProximityRadius = 15.0,
                ThumbnailUrl = "https://images.unsplash.com/photo-1548013146-72479768bada",
                DisplayOrder = 2
            }
        );

        modelBuilder.Entity<PoiTranslation>().HasData(
            new PoiTranslation
            {
                Id = 1,
                PoiId = 1,
                LanguageCode = "vi",
                Title = "Tượng Phật Bà Quan Âm cao 67m",
                DescriptionText = "Tượng Quán Thế Âm Bồ Tát tại Chùa Linh Ứng Bãi Bụt cao 67m, hướng nhìn ra biển Đông bình yên.",
                AudioUrl = "https://storage.example.com/audio/linhung_quan_am_vi.mp3",
                DurationSeconds = 120
            },
            new PoiTranslation
            {
                Id = 2,
                PoiId = 1,
                LanguageCode = "en",
                Title = "Lady Buddha Statue 67m",
                DescriptionText = "The Lady Buddha statue at Linh Ung Pagoda is 67 meters tall, facing towards the peaceful East Sea.",
                AudioUrl = "https://storage.example.com/audio/linhung_quan_am_en.mp3",
                DurationSeconds = 115
            },
            new PoiTranslation
            {
                Id = 3,
                PoiId = 2,
                LanguageCode = "vi",
                Title = "Chính Điện Chùa Linh Ứng",
                DescriptionText = "Nơi thờ tượng Phật Thích Ca, Quan Thế Âm và Địa Tạng Vương Bồ Tát với kiến trúc mái ngói uốn cong.",
                AudioUrl = "https://storage.example.com/audio/linhung_chinh_dien_vi.mp3",
                DurationSeconds = 140
            }
        );
    }
}