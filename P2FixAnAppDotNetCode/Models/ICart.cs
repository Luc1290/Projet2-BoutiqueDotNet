using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models
{
    // Interface représentant un panier
    public interface ICart
    {
        // Collection des lignes du panier
        List<CartLine> CartLines { get; set; }

        // Ajoute un produit dans le panier avec la quantité spécifiée
        void AddItem(Product product, int quantity);

        // Supprime la ligne du panier correspondant au produit donné
        void RemoveLine(Product product);

        // Vide le contenu du panier
        void Clear();

        // Calcule et retourne la valeur totale du panier
        double GetTotalValue();

        // Calcule et retourne la valeur moyenne par produit dans le panier
        double GetAverageValue();
    }
}
