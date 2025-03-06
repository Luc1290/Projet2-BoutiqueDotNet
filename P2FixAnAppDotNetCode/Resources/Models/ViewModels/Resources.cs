using System;
using System.Resources;
using System.Reflection;
using System.Globalization;

namespace P2FixAnAppDotNetCode.Resources.Models.ViewModels
{
    // Classe statique pour accéder aux ressources liées aux messages d'erreur de commande
    public static class OrderValidation
    {
        // Création d'un ResourceManager pour charger les ressources de la classe Order
        public static readonly ResourceManager resourceManager = new(
            "P2FixAnAppDotNetCode.Resources.Models.ViewModels.OrderValidation",
            Assembly.GetExecutingAssembly());

        // Culture actuelle utilisée pour récupérer les ressources
        public static CultureInfo resourceCulture = CultureInfo.CurrentCulture;

        // Constructeur statique qui initialise la culture avec la culture courante
        static OrderValidation()
        {
            resourceCulture = CultureInfo.CurrentCulture;
        }

        // Propriété pour obtenir ou définir la culture utilisée par les ressources
        public static CultureInfo ResourceCulture
        {
            get => resourceCulture;
            set
            {
                if (value != null)
                {
                    resourceCulture = value;
                }
            }
        }

        // Propriétés pour récupérer les messages d'erreur à partir des ressources
        public static string ErrorMissingName => resourceManager.GetString("ErrorMissingName", resourceCulture) ?? "ErrorMissingName";
        public static string ErrorMissingAddress => resourceManager.GetString("ErrorMissingAddress", resourceCulture) ?? "ErrorMissingAddress";
        public static string ErrorMissingCity => resourceManager.GetString("ErrorMissingCity", resourceCulture) ?? "ErrorMissingCity";
        public static string ErrorMissingZip => resourceManager.GetString("ErrorMissingZip", resourceCulture) ?? "ErrorMissingZip";
        public static string ErrorMissingCountry => resourceManager.GetString("ErrorMissingCountry", resourceCulture) ?? "ErrorMissingCountry";
    }
}
