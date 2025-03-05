using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using P2FixAnAppDotNetCode.Models;
using P2FixAnAppDotNetCode.Models.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace P2FixAnAppDotNetCode.Controllers
{
    // Contrôleur qui gère les actions liées au panier (Cart)
    public class CartController : Controller
    {
        // Référence à l'interface du panier
        private readonly ICart _cart;
        // Référence au service de gestion des produits
        private readonly IProductService _productService;

        // Constructeur avec injection de dépendances pour le panier et le service produit
        public CartController(ICart pCart, IProductService productService)
            => (_cart, _productService) = (pCart, productService);

        // Action pour afficher la vue du panier
        public ViewResult Index()
        {
            // Passage des valeurs total et moyenne du panier via le ViewBag
            ViewBag.Total = _cart.GetTotalValue();
            ViewBag.Average = _cart.GetAverageValue();
            // Retourne la vue du panier en passant l'objet _cart en modèle
            return View(_cart);
        }

        // Action pour ajouter un produit au panier via une requête POST
        [HttpPost]
        public RedirectToActionResult AddToCart(int productId, int quantity = 1)
        {
            // Récupération du produit en fonction de son identifiant
            var product = _productService.GetProductById(productId);

            // Si le produit n'existe pas, rediriger vers l'index du panier
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            // Si le stock disponible est inférieur à la quantité demandée, rediriger vers l'index
            if (product.Stock < quantity)
            {
                return RedirectToAction("Index");
            }

            // Ajout du produit au panier
            _cart.AddItem(product, quantity);
            // Mise à jour du nombre d'articles dans le panier via le ViewBag
            ViewBag.CartItemCount = _cart.CartLines.Sum(l => l.Quantity);

            // Mise à jour du stock du produit après l'ajout au panier
            _productService.UpdateProductStock(productId, product.Stock - quantity);

            // Redirection vers l'index du panier
            return RedirectToAction("Index");
        }

        // Action pour retirer un produit du panier en fonction de son identifiant
        public RedirectToActionResult RemoveFromCart(int id)
        {
            // Récupérer le produit via son ID
            Product product = _productService.GetProductById(id);
            if (product != null)
            {
                // Recherche de la ligne correspondante dans le panier
                var cartLine = _cart.CartLines.FirstOrDefault(l => l.Product.Id == id);
                if (cartLine != null)
                {
                    // Récupérer la quantité présente dans le panier pour ce produit
                    int quantityToRestore = cartLine.Quantity;
                    // Supprimer le produit du panier
                    _cart.RemoveLine(product);
                    // Mise à jour du stock : réintégrer la quantité supprimée
                    _productService.UpdateProductStock(id, product.Stock + quantityToRestore);
                }
            }
            return RedirectToAction("Index");
        }


        // Action pour vider le panier via une requête POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToActionResult Clear()
        {
            // Appel de la méthode Clear() pour vider toutes les lignes du panier
            _cart.Clear();
            // Redirection vers l'index du panier
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateQuantity(int productId, int quantityChange)
        {
            // Récupération du produit
            var product = _productService.GetProductById(productId);
            if (product != null)
            {
                // Recherche de la ligne de panier correspondant au produit
                var cartLine = _cart.CartLines.FirstOrDefault(l => l.Product.Id == productId);
                int currentQuantity = cartLine?.Quantity ?? 0;

                if (quantityChange > 0) // Augmenter la quantité
                {
                    // Vérifier que le stock est suffisant pour l'ajout
                    if (product.Stock < quantityChange)
                    {
                        TempData["Error"] = "Stock insuffisant pour ajouter cette quantité.";
                        return RedirectToAction("Index");
                    }

                    // Ajout de la quantité au panier
                    _cart.AddItem(product, quantityChange);
                    // Mise à jour du stock en soustrayant la quantité ajoutée
                    _productService.UpdateProductStock(productId, product.Stock - quantityChange);
                }
                else if (quantityChange < 0) // Diminuer la quantité
                {
                    // Calcul de la nouvelle quantité
                    int newQuantity = currentQuantity + quantityChange; // quantityChange est négatif
                    if (newQuantity <= 0)
                    {
                        // Si la nouvelle quantité est zéro ou négative, on retire le produit du panier
                        _cart.RemoveLine(product);
                        // On réintègre tout le stock de cette ligne (la totalité de currentQuantity) au stock actuel
                        _productService.UpdateProductStock(productId, product.Stock + currentQuantity);
                    }
                    else
                    {
                        // Sinon, on met à jour la quantité dans la ligne du panier
                        cartLine.Quantity = newQuantity;
                        // Le stock est augmenté du montant retiré (puisque quantityChange est négatif)
                        _productService.UpdateProductStock(productId, product.Stock - quantityChange);
                    }
                }
            }
            return RedirectToAction("Index");
        }



    }
}
