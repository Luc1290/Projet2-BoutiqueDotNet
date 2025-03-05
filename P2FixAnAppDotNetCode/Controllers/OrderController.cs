using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using P2FixAnAppDotNetCode.Models;
using P2FixAnAppDotNetCode.Models.Services;

namespace P2FixAnAppDotNetCode.Controllers
{
    // Contrôleur dédié aux commandes
    public class OrderController : Controller
    {
        // Référence au panier, au service de commande et au localisateur de chaînes pour la traduction
        private readonly ICart _cart;
        private readonly IOrderService _orderService;
        private readonly IStringLocalizer<OrderController> _localizer;

        // Constructeur avec injection des dépendances nécessaires
        public OrderController(ICart pCart, IOrderService service, IStringLocalizer<OrderController> localizer)
            => (_cart, _orderService, _localizer) = (pCart, service, localizer);

        // Action pour afficher le formulaire de commande
        public IActionResult Index()
        {
            // Crée une nouvelle commande
            var order = new Order();
            // Charge les articles du panier dans la commande
            order.LoadCartItems(_cart);
            // Retourne la vue en passant l'objet order en modèle
            return View(order);
        }

        // Action POST pour traiter la soumission du formulaire de commande
        [HttpPost]
        public IActionResult Index(Order order)
        {
            // Vérifie si le panier est vide
            if (_cart.CartLines.Count == 0)
            {
                ViewBag.CartEmpty = true;
            }
            // Si le modèle est valide, on procède au traitement de la commande
            if (ModelState.IsValid)
            {
                // Affecte les lignes du panier à la commande
                order.Lines = _cart.CartLines;
                // Sauvegarde la commande via le service dédié
                _orderService.SaveOrder(order);
                // Redirige vers l'action Completed pour confirmer la commande
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                // En cas d'erreurs de validation, réaffiche le formulaire avec le modèle en cours
                return View(order);
            }
        }

        // Action pour afficher la page de confirmation de commande
        public ViewResult Completed()
        {
            // Vide le panier après la commande
            _cart.Clear();
            // Retourne la vue de confirmation
            return View();
        }
    }
}
