using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using P2FixAnAppDotNetCode.Models.Repositories;

namespace P2FixAnAppDotNetCode.Models.Services
{
    // Classe fournissant des services pour gérer une commande
    public class OrderService : IOrderService
    {
        // Référence au panier
        private readonly ICart _cart;
        // Référence au dépôt des commandes
        private readonly IOrderRepository _repository;
        // Référence au service de gestion des produits
        private readonly IProductService _productService;

        // Constructeur avec injection des dépendances : panier, dépôt des commandes et service de produits
        public OrderService(ICart cart, IOrderRepository orderRepo, IProductService productService)
            => (_cart, _repository, _productService) = (cart, orderRepo, productService);

        // Sauvegarde une commande
        public void SaveOrder(Order order)
        {
            // Met à jour la date de la commande avec la date et l'heure actuelles
            order.Date = DateTime.Now;
            // Sauvegarde la commande dans le dépôt
            _repository.Save(order);
            // Vide le panier
            _cart.Clear();
        }
    }
}
