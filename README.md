# PlayersAPI
Players Web API

Cette API simple permetent de retourner les statistiques des joueurs de tennis.
Elle exposent a trois services :
-  un service GET /players : qui retourne tous les joueurs. La liste doit être triée du meilleur
au moins bon.
-  un service GET /player/{player_id} : qui permet de retourner les informations d’un joueur grâce à son ID.
-  un service GET /statistics : qui retourne les statistiques suivantes :
    - Pays qui a le plus grand ratio de parties gagnées
    - IMC moyen de tous les joueurs
    - La médiane de la taille des joueurs
