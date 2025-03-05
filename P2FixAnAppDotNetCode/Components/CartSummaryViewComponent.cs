using Microsoft.AspNetCore.Mvc;
using P2FixAnAppDotNetCode.Models;

namespace P2FixAnAppDotNetCode.Components
{
    // Composant de vue permettant d'afficher le résumé du panier
    public class CartSummaryViewComponent : ViewComponent
    {
        // Référence au panier
        private readonly Cart _cart;

        // Constructeur qui injecte l'interface ICart et la convertit en instance de Cart
        public CartSummaryViewComponent(ICart cart)
        {
            _cart = cart as Cart;
        }

        // Méthode Invoke qui retourne la vue associée au composant, en passant le panier en modèle
        public IViewComponentResult Invoke()
        {
            return View(_cart);
        }
    }
}
