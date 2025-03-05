using Microsoft.AspNetCore.Mvc;
using P2FixAnAppDotNetCode.Models.Services;

namespace P2FixAnAppDotNetCode.Components
{
    // Composant de vue pour la sélection de la langue.
    public class LanguageSelectorViewComponent : ViewComponent
    {
        // La méthode Invoke est appelée pour rendre le composant de vue.
        // Elle reçoit en paramètre un service de langue (ILanguageService) qui contient la logique et les données de sélection de la langue.
        public IViewComponentResult Invoke(ILanguageService languageService)
        {
            // Retourne la vue associée au composant, en passant le service de langue en tant que modèle.
            return View(languageService);
        }
    }
}
