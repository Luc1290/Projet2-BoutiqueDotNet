using System;
using Microsoft.AspNetCore.Mvc;
using P2FixAnAppDotNetCode.Models.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace P2FixAnAppDotNetCode.Controllers
{
    // Contrôleur qui gère les actions liées aux produits
    public class ProductController : Controller
    {
        // Référence au service de gestion des produits injectée via le constructeur
        private readonly IProductService _productService;

        // Constructeur avec injection de dépendance pour le service produit
        public ProductController(IProductService productService) => _productService = productService;

        // Action pour afficher la liste des produits
        public IActionResult Index()
        {
            // Récupération de tous les produits via le service
            var products = _productService.GetAllProducts();

            // Affichage dans la console pour vérification du contenu des produits envoyés à la vue
            Console.WriteLine("📦 Vérification des produits envoyés à la vue :");
            foreach (var product in products)
            {
                Console.WriteLine($"- {product.Name} (Stock : {product.Stock})");
            }

            // Retourne la vue avec la liste des produits en modèle
            return View(products);
        }
    }
}
