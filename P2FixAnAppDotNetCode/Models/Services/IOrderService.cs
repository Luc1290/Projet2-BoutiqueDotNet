namespace P2FixAnAppDotNetCode.Models.Services
{
    // Interface définissant le service de gestion des commandes.
    public interface IOrderService
    {
        // Sauvegarde une commande dans le système.
        void SaveOrder(Order order);
    }
}
