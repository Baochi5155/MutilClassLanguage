namespace AudioGuide.BLL.DTOs;

public record AudioGuideDto(
    int Id,
    string Title,
    string LanguageCode,
    string AudioUrl,
    string Transcript
);