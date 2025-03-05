using Microsoft.AspNetCore.Http;

namespace P2FixAnAppDotNetCode.Models.Services
{
    // Interface définissant les opérations de gestion de la langue de l'interface utilisateur.
    public interface ILanguageService
    {
        // Change la langue de l'interface utilisateur en fonction du contexte HTTP et de la langue spécifiée.
        void ChangeUiLanguage(HttpContext context, string language);

        // Définit la culture à utiliser en fonction de la langue donnée et retourne la chaîne de culture correspondante.
        string SetCulture(string language);

        // Met à jour le cookie de culture dans le contexte HTTP avec la culture spécifiée.
        void UpdateCultureCookie(HttpContext context, string culture);
    }
}
