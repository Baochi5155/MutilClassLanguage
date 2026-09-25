using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AudioGuide.Tests;

[TestClass]
public class AudioGuideLogicTests
{
    // Hàm mẫu kiểm tra mã ngôn ngữ (Logic thuần)
    private bool IsSupportedLanguage(string langCode)
    {
        var supported = new[] { "vi", "en", "ja", "fr" };
        return supported.Contains(langCode.ToLower());
    }

    [TestMethod]
    public void IsSupportedLanguage_ValidCode_ReturnsTrue()
    {
        // Arrange
        string lang = "vi";

        // Act
        bool result = IsSupportedLanguage(lang);

        // Assert (dùng Assert tích hợp sẵn của MSTest)
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsSupportedLanguage_InvalidCode_ReturnsFalse()
    {
        // Arrange
        string lang = "xyz";

        // Act
        bool result = IsSupportedLanguage(lang);

        // Assert
        Assert.IsFalse(result);
    }
}