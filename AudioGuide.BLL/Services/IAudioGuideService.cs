using AudioGuide.BLL.DTOs;

namespace AudioGuide.BLL.Services;

public interface IAudioGuideService
{
    Task<IEnumerable<AudioGuideDto>> GetByLanguageAsync(string lang);
    Task<AudioGuideDto> CreateAsync(AudioGuideDto dto);
}