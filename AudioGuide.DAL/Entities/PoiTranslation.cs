namespace AudioGuide.DAL.Entities;

public class PoiTranslation
{
    public int Id { get; set; }
    public int PoiId { get; set; }
    public string LanguageCode { get; set; } = "vi";   // Mã ngôn ngữ (vi, en, ja, fr, zh...)
    public string Title { get; set; } = string.Empty;
    public string DescriptionText { get; set; } = string.Empty; // Nội dung thuyết minh (text)
    public string AudioUrl { get; set; } = string.Empty;        // Đường dẫn file âm thanh/stream
    public int DurationSeconds { get; set; }

    // Navigation property
    public Poi? Poi { get; set; }
}