using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace P2FixAnAppDotNetCode.Models.Services
{
    // Classe qui fournit des méthodes de service pour gérer la langue de l'application
    public class LanguageService : ILanguageService
    {
        // Définit la langue de l'interface utilisateur
        public void ChangeUiLanguage(HttpContext context, string language)
        {
            // Définir la culture en fonction de la langue spécifiée
            string culture = SetCulture(language);
            // Mettre à jour le cookie de culture
            UpdateCultureCookie(context, culture);
        }

        // Définit la culture en fonction de la langue donnée
        public string SetCulture(string language)
        {
            language = language.ToLower();

            // Conversion de la langue en culture spécifique (première étape)
            language = language switch
            {
                var l when l.Contains("spanish") => "es-ES",
                var l when l.Contains("english") => "en-GB",
                var l when l.Contains("french") => "fr-FR",
                _ => language
            };

            // Retourne la culture en fonction de la valeur normalisée
            return language switch
            {
                "fr" or "fr-fr" or "fr-FR" => "fr-FR",
                "en" or "en-gb" or "en-us" or "en-US" or "en-GB" => "en-GB",
                "es" or "es-es" or "es-ES" => "es-ES",
                _ => "en-GB"
            };
        }

        // Met à jour le cookie de culture dans le contexte HTTP avec la culture spécifiée
        public void UpdateCultureCookie(HttpContext context, string culture)
        {
            var cookieValue = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture));
            context.Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, cookieValue);
        }
    }
}
