Lambazon - Application de Vente en Ligne
Contexte
Lambazon est un d�taillant en ligne en pleine transformation num�rique, visant � moderniser son application Web afin de r�pondre aux exigences actuelles du march�. Ce projet a �t� d�velopp� avec le framework ASP.NET Core pour am�liorer la performance, la s�curit� et l�exp�rience utilisateur globale.

Description du Projet
Cette application web permet aux utilisateurs de consulter les produits, d�ajouter des articles dans leur panier et de finaliser leurs achats via une page de paiement s�curis�e. Elle int�gre �galement une interface multilingue (Anglais, Fran�ais, Espagnol) pour offrir une meilleure accessibilit�.

Fonctionnalit�s Principales
Page d'Accueil :
Permet � l�utilisateur d�ajouter des articles dans son panier.

Pr�sentation des Produits :
Affiche le nom, la description, le prix et le nombre d�articles en stock.

Gestion du Panier :

Ajout d�un produit avec une quantit� initiale de 1.
Incr�mentation de la quantit� si le produit est d�j� pr�sent.
Affichage des totaux (sous-total par article, total g�n�ral, prix moyen).
Page de Paiement :

Validation des champs obligatoires (nom, adresse, ville, code postal, pays).
Affichage de messages d�erreur en cas de champ manquant.
Mise � jour des stocks en fonction de la commande.
S�lection de Langue :
Permet de basculer l�interface (titres, messages, boutons) entre l�Anglais, le Fran�ais et l�Espagnol via le menu d�roulant du pied de page.

Correctifs et Am�liorations
Bugs Corrig�s :

Probl�me lors de l�ajout d�articles dans le panier.
Dysfonctionnements sur la page de paiement.
Affichage incorrect des messages de confirmation/remerciement.
Int�gration des TODO :
Tous les �l�ments signal�s par des commentaires TODO dans le code ont �t� int�gr�s.

M�thode SetCulture() :
Ajustements r�alis�s pour assurer une gestion correcte de la culture et de la langue.

Pr�requis
Environnement de D�veloppement :

Visual Studio (ou tout IDE compatible avec ASP.NET Core)
.NET 6 ou version sup�rieure
Outils de Versionnage :

Git pour la gestion des versions
GitHub pour l�h�bergement et la collaboration sur le code
Installation et Ex�cution
Cloner le Repository :

bash
Copier
git clone https://github.com/Luc1290/Projet2-BoutiqueDotNet.git
Ouvrir le Projet :

Lancez Visual Studio et ouvrez la solution (.sln) pr�sente dans le dossier clon�.
Restaurer les Packages NuGet :

Visual Studio devrait automatiquement restaurer les packages n�cessaires.
Construire et Ex�cuter l�Application :

Appuyez sur F5 ou utilisez le bouton "Start" pour lancer l�application en mode debug.
R�aliser des Tests Manuels :

V�rifiez les fonctionnalit�s principales (ajout au panier, paiement, changement de langue, etc.) pour vous assurer du bon fonctionnement de l�application.
Utilisation et D�ploiement
Interface Utilisateur :
Naviguez entre la page d�accueil, la page de produits, le panier et la page de paiement pour explorer l�application.

D�ploiement :
L�application peut �tre d�ploy�e sur un serveur compatible avec ASP.NET Core. Pour cela, reportez-vous � la documentation officielle de Microsoft sur le d�ploiement d�applications ASP.NET Core.

Gestion de Versions
Commits R�guliers :
Les commits sont r�alis�s � chaque �tape pour faciliter le suivi des modifications.

Branche Principale :
La branche principale (main/master) contient la version finalis�e et test�e de l�application.

Workflow Git :
Utilisation de branches pour le d�veloppement de nouvelles fonctionnalit�s et des Pull Requests pour l�int�gration apr�s revue.

Support et Contact
Pour toute question ou suggestion concernant ce projet, veuillez contacter :

Luc Parguel
Lucparguel12720@gmail.com

