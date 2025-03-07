Lambazon - Application de Vente en Ligne
Contexte
Lambazon est un détaillant en ligne en pleine transformation numérique, visant à moderniser son application Web afin de répondre aux exigences actuelles du marché. Ce projet a été développé avec le framework ASP.NET Core pour améliorer la performance, la sécurité et l’expérience utilisateur globale.

Description du Projet
Cette application web permet aux utilisateurs de consulter les produits, d’ajouter des articles dans leur panier et de finaliser leurs achats via une page de paiement sécurisée. Elle intègre également une interface multilingue (Anglais, Français, Espagnol) pour offrir une meilleure accessibilité.

Fonctionnalités Principales
Page d'Accueil :
Permet à l’utilisateur d’ajouter des articles dans son panier.

Présentation des Produits :
Affiche le nom, la description, le prix et le nombre d’articles en stock.

Gestion du Panier :

Ajout d’un produit avec une quantité initiale de 1.
Incrémentation de la quantité si le produit est déjà présent.
Affichage des totaux (sous-total par article, total général, prix moyen).
Page de Paiement :

Validation des champs obligatoires (nom, adresse, ville, code postal, pays).
Affichage de messages d’erreur en cas de champ manquant.
Mise à jour des stocks en fonction de la commande.
Sélection de Langue :
Permet de basculer l’interface (titres, messages, boutons) entre l’Anglais, le Français et l’Espagnol via le menu déroulant du pied de page.

Correctifs et Améliorations
Bugs Corrigés :

Problème lors de l’ajout d’articles dans le panier.
Dysfonctionnements sur la page de paiement.
Affichage incorrect des messages de confirmation/remerciement.
Intégration des TODO :
Tous les éléments signalés par des commentaires TODO dans le code ont été intégrés.

Méthode SetCulture() :
Ajustements réalisés pour assurer une gestion correcte de la culture et de la langue.

Prérequis
Environnement de Développement :

Visual Studio (ou tout IDE compatible avec ASP.NET Core)
.NET 6 ou version supérieure
Outils de Versionnage :

Git pour la gestion des versions
GitHub pour l’hébergement et la collaboration sur le code
Installation et Exécution
Cloner le Repository :

bash
Copier
git clone https://github.com/Luc1290/Projet2-BoutiqueDotNet.git
Ouvrir le Projet :

Lancez Visual Studio et ouvrez la solution (.sln) présente dans le dossier cloné.
Restaurer les Packages NuGet :

Visual Studio devrait automatiquement restaurer les packages nécessaires.
Construire et Exécuter l’Application :

Appuyez sur F5 ou utilisez le bouton "Start" pour lancer l’application en mode debug.
Réaliser des Tests Manuels :

Vérifiez les fonctionnalités principales (ajout au panier, paiement, changement de langue, etc.) pour vous assurer du bon fonctionnement de l’application.
Utilisation et Déploiement
Interface Utilisateur :
Naviguez entre la page d’accueil, la page de produits, le panier et la page de paiement pour explorer l’application.

Déploiement :
L’application peut être déployée sur un serveur compatible avec ASP.NET Core. Pour cela, reportez-vous à la documentation officielle de Microsoft sur le déploiement d’applications ASP.NET Core.

Gestion de Versions
Commits Réguliers :
Les commits sont réalisés à chaque étape pour faciliter le suivi des modifications.

Branche Principale :
La branche principale (main/master) contient la version finalisée et testée de l’application.

Workflow Git :
Utilisation de branches pour le développement de nouvelles fonctionnalités et des Pull Requests pour l’intégration après revue.

Support et Contact
Pour toute question ou suggestion concernant ce projet, veuillez contacter :

Luc Parguel
Lucparguel12720@gmail.com

