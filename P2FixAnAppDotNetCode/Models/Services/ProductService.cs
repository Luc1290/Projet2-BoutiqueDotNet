using System;
using System.Collections.Generic;
using System.Linq;
using P2FixAnAppDotNetCode.Models.Repositories;

namespace P2FixAnAppDotNetCode.Models.Services
{
    // Classe qui fournit des services pour gérer les produits
    public class ProductService : IProductService
    {
        // Référence au dépôt des produits
        private readonly IProductRepository _productRepository;
        // Référence au dépôt des commandes
        private readonly IOrderRepository _orderRepository;

        // Constructeur avec injection des dépendances pour le dépôt des produits et des commandes
        public ProductService(IProductRepository productRepository, IOrderRepository orderRepository)
            => (_productRepository, _orderRepository) = (productRepository, orderRepository);

        // Récupère tous les produits de l'inventaire
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        // Récupère un produit de l'inventaire à partir de son identifiant
        public Product GetProductById(int id)
        {
            var product = _productRepository.GetAllProducts().FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                Console.WriteLine($"Erreur : Produit ID {id} introuvable.");
            }

            return product;
        }

        // Met à jour les quantités restantes pour chaque produit de l'inventaire en fonction des quantités commandées
        public void UpdateProductQuantities(Cart cart)
        {
            foreach (var line in cart.CartLines)
            {
                _productRepository.UpdateProductStocks(line.Product.Id, line.Quantity);
            }
        }

        // Met à jour le stock d'un produit en fonction de son identifiant et du nouveau stock
        public void UpdateProductStock(int productId, int newStock)
        {
            var product = _productRepository.GetProductById(productId);

            if (product == null)
            {
                Console.WriteLine($"🚨 ERREUR : Produit ID {productId} introuvable.");
                return;
            }

            product.Stock = newStock;
            Console.WriteLine($"✅ Stock mis à jour via 'ProductService' : {product.Name} -> {newStock} restant.");
        }
    }
}
