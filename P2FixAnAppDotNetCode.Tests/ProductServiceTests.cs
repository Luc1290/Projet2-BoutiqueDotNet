using System.Collections.Generic;
using System.Linq;
using P2FixAnAppDotNetCode.Models;
using P2FixAnAppDotNetCode.Models.Repositories;
using P2FixAnAppDotNetCode.Models.Services;
using Xunit;

namespace P2FixAnAppDotNetCode.Tests
{
    // La classe de test pour le service produit
    public class ProductServiceTests
    {
        [Fact]
        public void Product()
        {
            IProductRepository productRepository = new ProductRepository();
            IOrderRepository orderRepository = new OrderRepository();
            IProductService productService = new ProductService(productRepository, orderRepository);

            var products = productService.GetAllProducts();

            // On s'attend à ce que GetAllProducts retourne une List<Product>
            Assert.IsType<List<Product>>(products);
        }

        [Fact]
        public void UpdateProductQuantities()
        {
            // Création du panier et des services nécessaires
            Cart cart = new Cart();
            IProductRepository productRepository = new ProductRepository();
            IOrderRepository orderRepository = new OrderRepository();
            IProductService productService = new ProductService(productRepository, orderRepository);

            // Récupère les produits depuis le service
            IEnumerable<Product> products = productService.GetAllProducts();
            // Ajoute 1 unité du produit d'ID 1, 2 unités du produit d'ID 3 et 3 unités du produit d'ID 5
            cart.AddItem(products.First(p => p.Id == 1), 1);
            cart.AddItem(products.First(p => p.Id == 3), 2);
            cart.AddItem(products.First(p => p.Id == 5), 3);

            // Mise à jour des quantités en fonction des articles du panier
            productService.UpdateProductQuantities(cart);

            // Vérifie que les stocks ont été mis à jour correctement :
            // Pour le produit 1 (initial stock 10) : 10 - 1 = 9
            // Pour le produit 3 (initial stock 30) : 30 - 2 = 28
            // Pour le produit 5 (initial stock 50) : 50 - 3 = 47
            Assert.Equal(9, products.First(p => p.Id == 1).Stock);
            Assert.Equal(28, products.First(p => p.Id == 3).Stock);
            Assert.Equal(47, products.First(p => p.Id == 5).Stock);

            // Deuxième passage simulant un nouveau checkout :
            // On réinitialise le panier et on utilise le même dépôt (le dépôt étant basé sur une liste statique,
            // les modifications de stock persistent)
            cart = new Cart();
            productRepository = new ProductRepository();
            productService = new ProductService(productRepository, orderRepository);
            products = productService.GetAllProducts();
            cart.AddItem(products.First(p => p.Id == 1), 1);
            cart.AddItem(products.First(p => p.Id == 3), 2);
            cart.AddItem(products.First(p => p.Id == 5), 3);
            productService.UpdateProductQuantities(cart);
            // Nouveau stock attendu :
            // Pour le produit 1 : 9 - 1 = 8
            // Pour le produit 3 : 28 - 2 = 26
            // Pour le produit 5 : 47 - 3 = 44
            Assert.Equal(8, products.First(p => p.Id == 1).Stock);
            Assert.Equal(26, products.First(p => p.Id == 3).Stock);
            Assert.Equal(44, products.First(p => p.Id == 5).Stock);
        }

        [Fact]
        public void GetProductById()
        {
            IProductRepository productRepository = new ProductRepository();
            IOrderRepository orderRepository = new OrderRepository();
            IProductService productService = new ProductService(productRepository, orderRepository);
            int id = 3;

            Product product = productService.GetProductById(id);

            // Utilisation de Assert.Equal pour comparer les valeurs de chaîne
            Assert.Equal("JVC HAFX8R Headphone", product.Name);
            Assert.Equal(69.99, product.Price);
        }
    }
}
