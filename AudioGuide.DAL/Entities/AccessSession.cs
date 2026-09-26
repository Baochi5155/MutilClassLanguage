namespace AudioGuide.DAL.Entities;

public class AccessSession
{
    public int Id { get; set; }
    public string ShortedCode { get; set; } = string.Empty; // Mã ngắn gồm 6 chữ số cho khách trả tiền mặt
    public string AuthCode { get; set; } = string.Empty;    // Auth code của hệ thống
    public string PaymentMethod { get; set; } = "Cash";    // "Cash" hoặc "Online"
    public bool IsPaid { get; set; } = false;
    public string? AccessToken { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ExpiredAt { get; set; }
}