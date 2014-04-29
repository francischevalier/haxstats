HaxStats
========

Tableau de bord accompagnant le jeu de soccer 2D, HaxBall. En plus d’être personnalisable, ce tableau de bord permet de chronométrer le temps de possession en attaque de chaque équipe. Il est également en mesure de détecter les buts de façon automatique.

Installations nécessaires :

- Microsoft .NET Framework
- AForge.NET Framework (déjà inclus)

Ce programme qui est complètement indépendant du jeu HaxBall, utilise des procédés de traitements d’images. Le principe est simple, le programme prend x nombre de captures d’écran par seconde. Pour chaque capture d’écran, le programme analyse l’image à l’aide de la librairie AForge.NET afin de détecter la position des «blobs» (ici, il s’agit de cercles étant donné que les joueurs, la balle ainsi que les poteaux en sont tous). À partir de ses informations, il est possible de savoir dans quel territoire se situe la balle en détectant si celle-ci se trouve à la droite ou à la gauche des poteaux. Par la même technique, il est possible de détecter les buts automatiquement. L’interface du programme est entièrement codée avec GDI, il est possible de personnaliser les couleurs etc.

Auteur : Francis Chevalier<br />
Création : 1er mai 2012<br />
Dernière modification : 14 mai 2012<br />
Développement : Visual Studio 2010 / C#
