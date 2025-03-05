using System;
using System.Collections.Generic;
using System.Linq;
using P2FixAnAppDotNetCode.Models;

namespace P2FixAnAppDotNetCode.Models
{
    public class Cart : ICart
    {
        // Liste des lignes du panier
        public List<CartLine> CartLines { get; set; } = new();

        // Ajoute un produit au panier. Si le produit existe déjà, la quantité est augmentée.
        public void AddItem(Product product, int quantity)
        {
            if (product == null)
            {
                return;
            }

            // Recherche d'une ligne contenant déjà le produit via son identifiant
            var line = CartLines.FirstOrDefault(l => l.Product.Id == product.Id);

            if (line == null)
            {
                // Si le produit n'existe pas encore dans le panier, on ajoute une nouvelle ligne.
                CartLines.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                // Sinon, on augmente simplement la quantité.
                line.Quantity += quantity;
            }
        }

        // Supprime toutes les lignes contenant le produit spécifié.
        public void RemoveLine(Product product)
        {
            CartLines.RemoveAll(l => l.Product.Id == product.Id);
        }

        // Vide le panier.
        public void Clear()
        {
            CartLines.Clear();
        }

        // Calcule la valeur totale du panier.
        public double GetTotalValue()
        {
            return CartLines.Sum(l => l.Product.Price * l.Quantity);
        }

        // Calcule la valeur moyenne par produit dans le panier.
        public double GetAverageValue()
        {
            int totalItems = CartLines.Sum(line => line.Quantity);
            return totalItems > 0 ? GetTotalValue() / totalItems : 0;
        }

        // Recherche et retourne un produit dans les lignes du panier à partir de son identifiant.
        public Product FindProductInCartLines(int productId)
        {
            foreach (var cartLine in this.CartLines)
            {
                if (cartLine.Product != null && cartLine.Product.Id == productId)
                {
                    return cartLine.Product;
                }
            }
            return null;
        }
    }
}
