using AudioGuide.BLL.DTOs;
using AudioGuide.DAL;
using AudioGuide.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AudioGuide.BLL.Services;

public class AudioGuideService : IAudioGuideService
{
    private readonly AppDbContext _context;

    public AudioGuideService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AudioGuideDto>> GetByLanguageAsync(string lang)
    {
        var targetLang = string.IsNullOrWhiteSpace(lang) ? "vi" : lang.ToLower();

        return await _context.AudioGuides
            .Where(x => x.LanguageCode == targetLang)
            .Select(x => new AudioGuideDto(x.Id, x.Title, x.LanguageCode, x.AudioUrl, x.Transcript))
            .ToListAsync();
    }

    public async Task<AudioGuideDto> CreateAsync(AudioGuideDto dto)
    {
        var entity = new AudioGuideItem
        {
            Title = dto.Title,
            LanguageCode = dto.LanguageCode.ToLower(),
            AudioUrl = dto.AudioUrl,
            Transcript = dto.Transcript
        };

        _context.AudioGuides.Add(entity);
        await _context.SaveChangesAsync();

        return new AudioGuideDto(entity.Id, entity.Title, entity.LanguageCode, entity.AudioUrl, entity.Transcript);
    }
}