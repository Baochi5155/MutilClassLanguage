namespace AudioGuide.DAL.Entities;

public class Poi
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Latitude { get; set; }              // Tọa độ GPS vĩ độ
    public double Longitude { get; set; }             // Tọa độ GPS kinh độ
    public double ProximityRadius { get; set; } = 15.0; // Bán kính nhận diện (mét)
    public string ThumbnailUrl { get; set; } = string.Empty;
    public int DisplayOrder { get; set; }

    // Quan hệ 1-N: Một điểm tham quan có bản dịch/thuyết minh ở nhiều ngôn ngữ
    public ICollection<PoiTranslation> Translations { get; set; } = new List<PoiTranslation>();
}