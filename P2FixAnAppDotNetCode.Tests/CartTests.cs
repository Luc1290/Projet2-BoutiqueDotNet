using System.Collections.Generic;
using System.Linq;
using P2FixAnAppDotNetCode.Models;
using P2FixAnAppDotNetCode.Models.Repositories;
using P2FixAnAppDotNetCode.Models.Services;
using Xunit;

namespace P2FixAnAppDotNetCode.Tests
{
    // La classe de test pour le panier
    public class CartTests
    {
        // Teste l'ajout d'un même produit dans le panier afin d'incrémenter la quantité
        [Fact]
        public void AddItemInCart()
        {
            // Création d'un nouveau panier
            Cart cart = new Cart();
            // Création de deux produits identiques
            Product product1 = new Product(1, 0, 20, "name", "descriptionFR", "descriptionEN", "descriptionES");
            Product product2 = new Product(1, 0, 20, "name", "descriptionFR", "descriptionEN", "descriptionES");

            // Ajout des deux produits dans le panier
            cart.AddItem(product1, 1);
            cart.AddItem(product2, 1);

            // Vérifie que le panier contient bien des lignes et qu'il n'y en a qu'une seule
            Assert.NotEmpty(cart.CartLines);
            Assert.Single(cart.CartLines);
            // Vérifie que la quantité de cette ligne est égale à 2
            Assert.Equal(2, cart.CartLines.First().Quantity);
        }

        // Teste le calcul de la valeur moyenne des produits dans le panier
        [Fact]
        public void GetAverageValue()
        {
            ICart cart = new Cart();
            IProductRepository productRepository = new ProductRepository();
            IOrderRepository orderRepository = new OrderRepository();
            IProductService productService = new ProductService(productRepository, orderRepository);

            // Récupère les produits depuis le service
            IEnumerable<Product> products = productService.GetAllProducts();
            // Ajoute 2 unités du produit d'ID 2 et 1 unité du produit d'ID 5
            cart.AddItem(products.First(p => p.Id == 2), 2);
            cart.AddItem(products.First(p => p.Id == 5), 1);
            double averageValue = cart.GetAverageValue();
            // Calcul de la valeur moyenne attendue : (9.99 * 2 + 895.00) / 3
            double expectedValue = (9.99 * 2 + 895.00) / 3;

            Assert.Equal(expectedValue, averageValue);
        }

        // Teste le calcul de la valeur totale du panier
        [Fact]
        public void GetTotalValue()
        {
            ICart cart = new Cart();
            IProductRepository productRepository = new ProductRepository();
            IOrderRepository orderRepository = new OrderRepository();
            IProductService productService = new ProductService(productRepository, orderRepository);

            IEnumerable<Product> products = productService.GetAllProducts();
            // Ajoute des produits avec différentes quantités
            cart.AddItem(products.First(p => p.Id == 1), 1);
            cart.AddItem(products.First(p => p.Id == 4), 3);
            cart.AddItem(products.First(p => p.Id == 5), 1);
            double totalValue = cart.GetTotalValue();
            // Calcul de la valeur totale attendue : 92.50 + 32.50 * 3 + 895.00
            double expectedValue = 92.50 + 32.50 * 3 + 895.00;

            Assert.Equal(expectedValue, totalValue);
        }

        // Teste la méthode FindProductInCartLines pour rechercher un produit dans le panier
        [Fact]
        public void FindProductInCartLines()
        {
            Cart cart = new Cart();
            // Création d'un produit avec un ID spécifique
            Product product = new Product(999, 0, 20, "name", "descriptionFR", "descriptionEN", "descriptionES");

            // Ajout du produit dans le panier
            cart.AddItem(product, 1);
            // Recherche du produit par son ID
            Product result = cart.FindProductInCartLines(999);

            Assert.NotNull(result);
        }
    }
}
