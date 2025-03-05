using System;
using Microsoft.AspNetCore.Mvc;
using P2FixAnAppDotNetCode.Models.Services;
using P2FixAnAppDotNetCode.Models.ViewModels;

namespace P2FixAnAppDotNetCode.Controllers
{
    // Contrôleur dédié aux actions de gestion de la langue de l'interface utilisateur
    public class LanguageController : Controller
    {
        // Service de gestion de la langue injecté via le constructeur
        private readonly ILanguageService _languageService;

        // Constructeur avec injection de dépendance pour le service de langue
        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        // Action pour changer la langue de l'interface utilisateur via une requête POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangeUiLanguage(LanguageViewModel model, string returnUrl)
        {
            // Affiche un message dans la console pour indiquer la réception de la requête POST
            Console.WriteLine("🔍 Requête POST reçue pour changer la langue");

            // Vérifie que la langue sélectionnée dans le modèle n'est pas nulle
            if (model.Language != null)
            {
                // Affiche la langue sélectionnée dans la console pour le debug
                Console.WriteLine($"🌍 Langue sélectionnée : {model.Language}");
                // Appelle le service pour changer la langue de l'interface utilisateur
                _languageService.ChangeUiLanguage(HttpContext, model.Language);
            }
            else
            {
                // Affiche un message d'erreur dans la console si aucune langue n'est reçue
                Console.WriteLine("🚨 ERREUR : Aucune langue reçue.");
            }

            // Redirige vers l'URL de retour après le changement de langue
            return Redirect(returnUrl);
        }
    }
}
