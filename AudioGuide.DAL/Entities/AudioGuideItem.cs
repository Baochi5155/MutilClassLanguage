namespace AudioGuide.DAL.Entities;

public class AudioGuideItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;       // Tiêu đề hiện vật/địa điểm
    public string LanguageCode { get; set; } = string.Empty; // Mã ngôn ngữ: vi, en, ja, fr...
    public string AudioUrl { get; set; } = string.Empty;     // Đường dẫn file âm thanh phát
    public string Transcript { get; set; } = string.Empty;   // Lời thoại văn bản thuyết minh
}