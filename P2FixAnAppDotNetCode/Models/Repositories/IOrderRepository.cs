namespace P2FixAnAppDotNetCode.Models.Repositories
{
    // Interface définissant les opérations de sauvegarde pour une commande
    public interface IOrderRepository
    {
        // Méthode pour enregistrer une commande dans le système (base de données, fichier, etc.)
        void Save(Order order);
    }
}
