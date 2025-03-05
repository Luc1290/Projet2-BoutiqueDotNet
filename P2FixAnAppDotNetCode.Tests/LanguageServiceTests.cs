using P2FixAnAppDotNetCode.Models.Services;
using Xunit;

namespace P2FixAnAppDotNetCode.Tests
{
    // La classe de test pour le service de langue
    public class LanguageServiceTests
    {
        [Fact]
        public void SetCulture()
        {
            // Arrange
            ILanguageService languageService = new LanguageService();
            string language = "French";

            // Act
            string culture = languageService.SetCulture(language);

            // Assert
            Assert.Equal("fr-FR", culture);
        }
    }
}
