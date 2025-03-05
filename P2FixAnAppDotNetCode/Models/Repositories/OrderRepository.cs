using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Repositories
{
    // Classe qui gère les données des commandes.
    public class OrderRepository : IOrderRepository
    {
        // Collection interne qui stocke les commandes.
        private readonly List<Order> _orders;

        // Constructeur qui initialise la liste des commandes.
        public OrderRepository() => _orders = new List<Order>();

        // Enregistre une commande dans le système.
        public void Save(Order order)
        {
            _orders.Add(order);
        }
    }
}
