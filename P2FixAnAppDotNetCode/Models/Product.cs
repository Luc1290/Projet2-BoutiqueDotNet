using System.Collections.Generic;
using System.Globalization;

namespace P2FixAnAppDotNetCode.Models
{
    // Classe représentant un produit
    public class Product
    {
        // Identifiant unique du produit
        public int Id { get; set; }

        // Nom du produit
        public string Name { get; set; }

        // Dictionnaire contenant les descriptions dans différentes langues
        private readonly Dictionary<string, string> _descriptions;

        // Constructeur du produit
        // id : Identifiant du produit
        // stock : Quantité en stock
        // price : Prix du produit
        // name : Nom du produit
        // descriptionFr : Description en français
        // descriptionEn : Description en anglais
        // descriptionEs : Description en espagnol
        public Product(int id, int stock, double price, string name, string descriptionFr, string descriptionEn, string descriptionEs)
        {
            Id = id;
            Stock = stock;
            Price = price;
            Name = name;

            // Initialisation des descriptions pour chaque langue
            _descriptions = new Dictionary<string, string>
            {
                { "fr", descriptionFr },
                { "en", descriptionEn },
                { "es", descriptionEs }
            };
        }

        // Propriété pour récupérer la description du produit selon la culture courante
        // Si la langue actuelle n'est pas disponible, retourne la description en anglais par défaut
        public string Description => _descriptions.TryGetValue(CultureInfo.CurrentCulture.TwoLetterISOLanguageName, out var desc) ? desc : _descriptions["en"];

        // Quantité en stock du produit
        public int Stock { get; set; }

        // Prix du produit
        public double Price { get; set; }
    }
}
