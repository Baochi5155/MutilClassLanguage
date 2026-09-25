using Microsoft.EntityFrameworkCore;
using AudioGuide.DAL.Entities;

namespace AudioGuide.DAL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<AudioGuideItem> AudioGuides => Set<AudioGuideItem>();
}