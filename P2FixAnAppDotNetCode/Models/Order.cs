using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace P2FixAnAppDotNetCode.Models
{
    // Classe représentant une commande passée par un client
    public class Order
    {
        // Identifiant unique de la commande.
        // [BindNever] indique que cette propriété ne doit pas être liée via les formulaires MVC.
        [BindNever]
        public int OrderId { get; set; }

        // Date de la commande, initialisée à la date et l'heure courantes.
        // [BindNever] signifie que cette propriété ne sera pas liée automatiquement depuis une source externe.
        [BindNever]
        public DateTime Date { get; set; } = DateTime.Now;

        // Liste des lignes de commande (articles du panier).
        // [BindNever] empêche la liaison automatique de cette propriété.
        // Remarque : initialisé ici avec new List<CartLine>() pour créer une liste vide.
        [BindNever]
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        // Nom du client, requis.
        // Si manquant, un message d'erreur spécifique est affiché.
        [Required(ErrorMessageResourceType = typeof(P2FixAnAppDotNetCode.Resources.Models.ViewModels.Order),
                  ErrorMessageResourceName = "ErrorMissingName")]
        public string Name { get; set; }

        // Adresse du client, requise.
        // Un message d'erreur spécifique est utilisé si la valeur est manquante.
        [Required(ErrorMessageResourceType = typeof(P2FixAnAppDotNetCode.Resources.Models.ViewModels.Order),
                  ErrorMessageResourceName = "ErrorMissingAddress")]
        public string Address { get; set; }

        // Ville du client, requise.
        // Un message d'erreur spécifique sera affiché si cette propriété n'est pas renseignée.
        [Required(ErrorMessageResourceType = typeof(P2FixAnAppDotNetCode.Resources.Models.ViewModels.Order),
                  ErrorMessageResourceName = "ErrorMissingCity")]
        public string City { get; set; }

        // Code postal du client.
        public string Zip { get; set; }

        // Pays du client, requis.
        // Un message d'erreur spécifique sera affiché si cette valeur est absente.
        [Required(ErrorMessageResourceType = typeof(P2FixAnAppDotNetCode.Resources.Models.ViewModels.Order),
                  ErrorMessageResourceName = "ErrorMissingCountry")]
        public string Country { get; set; }

        // Méthode permettant de charger les articles du panier dans la commande.
        // Elle affecte la collection de lignes de commande provenant du panier à la propriété Lines.
        public void LoadCartItems(ICart cart)
        {
            Lines = cart.CartLines;
        }
    }
}
