using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Services
{
    // Interface définissant le service de gestion des produits.
    public interface IProductService
    {
        // Récupère tous les produits.
        List<Product> GetAllProducts();

        // Récupère un produit à partir de son identifiant.
        Product GetProductById(int id);

        // Met à jour les quantités de produits dans le panier.
        void UpdateProductQuantities(Cart cart);

        // Met à jour le stock d'un produit en fonction de son identifiant et du nouveau stock.
        void UpdateProductStock(int productId, int newStock);
    }
}
