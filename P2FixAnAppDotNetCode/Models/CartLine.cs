using System;

namespace P2FixAnAppDotNetCode.Models
{
    // Classe repr�sentant une ligne du panier.
    public class CartLine
    {
        // Identifiant unique de la ligne de commande.
        public int OrderLineId { get; set; }

        // Produit associ� � cette ligne du panier.
        public Product Product { get; set; }

        // Quantit� du produit dans cette ligne.
        public int Quantity { get; set; }
    }
}
