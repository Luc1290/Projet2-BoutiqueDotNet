using System;

namespace P2FixAnAppDotNetCode.Models
{
    // Classe représentant une ligne du panier.
    public class CartLine
    {
        // Identifiant unique de la ligne de commande.
        public int OrderLineId { get; set; }

        // Produit associé à cette ligne du panier.
        public Product Product { get; set; }

        // Quantité du produit dans cette ligne.
        public int Quantity { get; set; }
    }
}
