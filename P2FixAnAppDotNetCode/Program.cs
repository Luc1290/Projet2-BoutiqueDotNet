using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace P2FixAnAppDotNetCode
{
    // Classe principale pour démarrer l'application ASP.NET Core
    public class Program
    {
        // Point d'entrée de l'application
        public static void Main(string[] args)
        {
            // Construit et exécute l'hôte web
            BuildWebHost(args).Run();
        }

        // Méthode pour construire l'hôte web en utilisant la configuration par défaut et la classe Startup
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
