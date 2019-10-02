# TennisTest

## Architecture
Utilisation simplifié de la clean architecture (Pas de domain, pas de use cases et un seul modèle pour toute l'application).

Possibilité d'ajouter des répositories pour changer le mode de stockage de données.

## Features
Récupération de tous les joueurs de tennis : /api/tennis GET

Récupération d'un seul joueur : /api/tennis/{id} GET (id étant un int)

Suppréssion d'un joueur : /api/Tennis/{id} DELETE (id étant un int)

Pour des raisons pratiques, le ficher est dupliqué lorsqu'un joueur est supprimé afin de retrouver le ficher original au prochain lancement du serveur.

## Documentation
Swagger : /swagger/index.html
GraphQL : /ui/playground

L'application se lance sur le port 5001 du localhost (localhost:5001)
