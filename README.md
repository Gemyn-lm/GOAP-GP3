# Pr�sentation du Projet

## Description

Le projet consiste en une simulation o� une intelligence artificielle (IA) effectue une s�rie de t�ches planifi�es par un algorithme dans le but d'atteindre un objectif de la mani�re la plus efficace possible, en minimisant le co�t total de la s�rie de t�ches. Les t�ches peuvent avoir un co�t variable, par exemple plus �lev� si le lieu o� elles doivent �tre r�alis�es est �loign� de l'emplacement actuel de l'agent. Dans cette simulation, Jeff (le petit d�mon rouge) doit r�colter 300 pi�ces d'or. Pour ce faire, il peut travailler sur son ordinateur ou tuer des squelettes, cette derni�re option lui rapportant davantage. Cependant, Jeff doit poss�der une �p�e, qu'il peut fabriquer avec une b�che et un lingot de fer.

## Fonctionnement

L'algorithme qui planifie la suite de t�ches suit le fonctionnement du pathfinding A*. Les "nodes," qui repr�sentent des positions dans l'algorithme de base, deviennent l'�tat de l'agent. L'algorithme A* optimise le temps de recherche en calculant, pour chaque node, sa distance par rapport � la destination. Cet effet est reproduit en calculant une "distance" entre l'�tat de l'agent et son but. Par exemple, pour l'objectif "avoir 300 pi�ces d'or," la distance est la diff�rence de pi�ces d'or entre l'�tat actuel et 300. L'IA dispose d'un maximum de temps de calcul (le nombre d'it�rations de l'algorithme dans le code) allou� pour trouver le meilleur "chemin." S'il n'a pas trouv�, l'agent emprunte le chemin avec le rapport co�t/distance au but le moins �lev� et recommence � chercher apr�s avoir effectu� toutes les t�ches.

## Piste d'Am�lioration

Une fonctionnalit� qui serait utile, voire indispensable dans le contexte d'un jeu, serait de pr�voir le cas o� l'agent ne peut pas r�aliser certaines t�ches apr�s les avoir simul�es. Par exemple, l'IA peut planifier de se d�placer jusqu'� un ennemi, mais celui-ci peut mourir ou devenir hors d'atteinte pendant que les t�ches sont effectu�es. Dans ce cas, l'agent peut avoir une limite de co�t (si on attribue le co�t au temps) � d�passer avant de devoir recalculer une suite de t�ches.

---
