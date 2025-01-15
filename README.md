# Présentation du Projet

## Description

Le projet consiste en une simulation où une intelligence artificielle (IA) effectue une série de tâches planifiées par un algorithme dans le but d'atteindre un objectif de la manière la plus efficace possible, en minimisant le coût total de la série de tâches. Les tâches peuvent avoir un coût variable, par exemple plus élevé si le lieu où elles doivent être réalisées est éloigné de l'emplacement actuel de l'agent. Dans cette simulation, Jeff (le petit démon rouge) doit récolter 300 pièces d'or. Pour ce faire, il peut travailler sur son ordinateur ou tuer des squelettes, cette dernière option lui rapportant davantage. Cependant, Jeff doit posséder une épée, qu'il peut fabriquer avec une bûche et un lingot de fer.

## Fonctionnement

L'algorithme qui planifie la suite de tâches suit le fonctionnement du pathfinding A*. Les "nodes," qui représentent des positions dans l'algorithme de base, deviennent l'état de l'agent. L'algorithme A* optimise le temps de recherche en calculant, pour chaque node, sa distance par rapport à la destination. Cet effet est reproduit en calculant une "distance" entre l'état de l'agent et son but. Par exemple, pour l'objectif "avoir 300 pièces d'or," la distance est la différence de pièces d'or entre l'état actuel et 300. L'IA dispose d'un maximum de temps de calcul (le nombre d'itérations de l'algorithme dans le code) alloué pour trouver le meilleur "chemin." S'il n'a pas trouvé, l'agent emprunte le chemin avec le rapport coût/distance au but le moins élevé et recommence à chercher après avoir effectué toutes les tâches.

## Piste d'Amélioration

Une fonctionnalité qui serait utile, voire indispensable dans le contexte d'un jeu, serait de prévoir le cas où l'agent ne peut pas réaliser certaines tâches après les avoir simulées. Par exemple, l'IA peut planifier de se déplacer jusqu'à un ennemi, mais celui-ci peut mourir ou devenir hors d'atteinte pendant que les tâches sont effectuées. Dans ce cas, l'agent peut avoir une limite de coût (si on attribue le coût au temps) à dépasser avant de devoir recalculer une suite de tâches.

---
