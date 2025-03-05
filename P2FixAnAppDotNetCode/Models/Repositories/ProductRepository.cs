using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace P2FixAnAppDotNetCode.Models.Repositories
{
    // La classe qui gère les données des produits
    public class ProductRepository : IProductRepository
    {
        // Stockage statique des produits
        private static List<Product> _products = new List<Product>();

        // Constructeur qui initialise la liste des produits et génère les données par défaut si nécessaire
        public ProductRepository()
        {
            if (_products == null || _products.Count == 0)
            {
                _products = new List<Product>();
                GenerateProductData();
            }
        }

        // Génère la liste par défaut des produits
        private static void GenerateProductData()
        {
            int id = 0;
            // Ajout du produit Echo Dot
            _products.Add(new Product(++id, 10, 92.50, "Echo Dot",
                "Enceinte connectée intelligente avec Alexa intégrée.",  // Version française
                "Smart speaker with Alexa built-in.",                    // Version anglaise
                "Altavoz inteligente con Alexa integrada."));            // Version espagnole

            // Ajout du produit Anker 3ft USB Cable
            _products.Add(new Product(++id, 1, 9.99, "Anker 3ft USB Cable",
                "Câble USB ultra-résistant pour charge rapide.",         // Version française
                "Ultra-durable USB cable for fast charging.",             // Version anglaise
                "Cable USB ultrarresistente para carga rápida."));        // Version espagnole

            // Ajout du produit JVC HAFX8R Headphone
            _products.Add(new Product(++id, 30, 69.99, "JVC HAFX8R Headphone",
                "Écouteurs intra-auriculaires JVC HAFX8R Riptidz, son clair et puissant.", // Version française
                "JVC HAFX8R Riptidz in-ear headphones, clear and powerful sound.",          // Version anglaise
                "Auriculares intrauditivos JVC HAFX8R Riptidz, sonido claro y potente."));     // Version espagnole

            // Ajout du produit VTech CS6114 DECT 6.0
            _products.Add(new Product(++id, 40, 32.50, "VTech CS6114 DECT 6.0",
                "Téléphone sans fil VTech CS6114 DECT 6.0 avec identification de l'appelant.", // Version française
                "VTech CS6114 DECT 6.0 Cordless Phone",                                          // Version anglaise
                "Teléfono inalámbrico VTech CS6114 DECT 6.0."));                                  // Version espagnole

            // Ajout du produit NOKIA OEM BL-5J
            _products.Add(new Product(++id, 50, 895.00, "NOKIA OEM BL-5J",
                "Batterie d'origine NOKIA OEM BL-5J, haute autonomie.", // Version française
                "Original NOKIA OEM BL-5J battery, high autonomy.",       // Version anglaise
                "Batería original NOKIA OEM BL-5J, alta autonomía."));     // Version espagnole
        }

        // Retourne tous les produits disponibles dans l'inventaire
        public List<Product> GetAllProducts()
        {
            return _products; 
        }

        // Retourne un produit à partir de son identifiant
        public Product GetProductById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            return product;
        }

        // Met à jour le stock d'un produit dans l'inventaire en fonction de son identifiant
        public void UpdateProductStocks(int productId, int quantityToRemove)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                Console.WriteLine($"🚨 ERREUR : Impossible de mettre à jour le stock, produit ID {productId} introuvable.");
                return;
            }

            if (product.Stock < quantityToRemove)
            {
                // Le stock demandé dépasse le stock disponible : on ramène le stock à zéro.
                Console.WriteLine($"⚠️ Stock insuffisant pour {product.Name}. Stock actuel : {product.Stock}, demande : {quantityToRemove}. Le stock est maintenant mis à zéro.");
                product.Stock = 0;
            }
            else
            {
                product.Stock -= quantityToRemove;
                Console.WriteLine($"📦 Stock mis à jour : {product.Name} (Stock restant : {product.Stock})");
            }
        }
    }
}
