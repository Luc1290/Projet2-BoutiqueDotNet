using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using P2FixAnAppDotNetCode.Models;
using P2FixAnAppDotNetCode.Models.Repositories;
using P2FixAnAppDotNetCode.Models.Services;

namespace P2FixAnAppDotNetCode
{
    // Classe de démarrage de l'application ASP.NET Core
    public class Startup
    {
        // Constructeur qui reçoit la configuration de l'application
        public Startup(IConfiguration configuration) => Configuration = configuration;

        // Propriété de configuration de l'application
        public IConfiguration Configuration { get; }

        // Méthode appelée par le runtime pour ajouter des services au conteneur DI
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuration de la localisation en spécifiant le dossier des ressources
            services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });

            // Enregistrement des services pour le panier et la gestion de la langue en mode Singleton
            services.AddSingleton<ICart, Cart>();
            services.AddSingleton<ILanguageService, LanguageService>();

            // Enregistrement des services de produits et commandes en mode Transient
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            // Ajout du cache en mémoire et des sessions
            services.AddMemoryCache();
            services.AddSession();

            // Ajout des services MVC avec la localisation des vues et la localisation des annotations de données
            services.AddMvc()
                .AddViewLocalization(
                    LanguageViewLocationExpanderFormat.Suffix,
                    opts => { opts.ResourcesPath = "Resources"; })
                .AddDataAnnotationsLocalization();

            // Configuration des options de localisation pour la requête HTTP
            services.Configure<RequestLocalizationOptions>(opts =>
            {
                // Définition des cultures supportées
                var supportedCultures = new List<CultureInfo>()
                {
                     new CultureInfo("en-GB"),
                     new CultureInfo("en-US"),
                     new CultureInfo("fr-FR"),
                     new CultureInfo("es-ES"),
                };

                // Définition de la culture par défaut
                opts.DefaultRequestCulture = new RequestCulture("fr-FR");
                // Utilisé pour le formatage des nombres, dates, etc.
                opts.SupportedCultures = supportedCultures;
                // Utilisé pour les chaînes d'interface utilisateur localisées
                opts.SupportedUICultures = supportedCultures;
            });
        }

        // Méthode appelée par le runtime pour configurer le pipeline HTTP
        public void Configure(IApplicationBuilder app)
        {
            // Utilisation des fichiers statiques (wwwroot, etc.)
            app.UseStaticFiles();

            // Récupération et application des options de localisation configurées
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            // Activation de la gestion des sessions
            app.UseSession();

            // Configuration du routage
            app.UseRouting();

            // Middleware pour désactiver la mise en cache en ajoutant l'en-tête Cache-Control
            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue
                {
                    NoStore = true
                };
                await next();
            });

            // Configuration des points de terminaison avec une route par défaut
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=Index}/{id?}");
            });

            // Middleware pour afficher dans la console la culture actuellement appliquée
            app.Use(async (context, next) =>
            {
                var culture = context.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture.Name;
                Console.WriteLine($"🛠️ Langue actuellement appliquée : {culture}");
                await next();
            });
        }
    }
}
