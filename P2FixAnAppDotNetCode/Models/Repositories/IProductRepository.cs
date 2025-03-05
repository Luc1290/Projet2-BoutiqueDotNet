using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Repositories
{
    // Interface définissant les opérations relatives aux produits dans le dépôt
    public interface IProductRepository
    {
        // Récupère la liste complète des produits disponibles
        List<Product> GetAllProducts();

        // Récupère un produit spécifique à partir de son identifiant
        Product GetProductById(int id);

        // Met à jour le stock d'un produit en retirant la quantité spécifiée
        void UpdateProductStocks(int productId, int quantityToRemove);
    }
}
