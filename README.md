# Projet IEVA : Loot Goblin

Thème : Duality  
Mécaniques à implémenter : **Eviter** & **Collectionner**  
Diversifiers : 
- Cartridge Ready : Your game should be under 10 MB.
- Undefined Language : All in-game text, symbols, spoken words, and written language must use a completely made-up language.
- \#256fes : 3D models can use no more than 256 triangles and a 256x256 texture


## Game Design

Le jeu est un jeu d'infiltration, où un gobelin doit parcourir un village en évitant les gardes pour ramasser le plus d'objets de valeur possible avant de s'enfuir par un portail magique afin de profiter de son butin. La mécanique de **Collectionner** est représentée par les collectibles dispersés dans le niveau. En atteignant le portail de fin, un score est attribué en fonction de la valeur des objets collectés, et le nombre d'objet est mis en comparaison avec le nombre total d'objets dans le niveau. Il est possible de finir la partie dès que l'on atteint le portail, mais il est également possible de simplement déposer les objets porté puis de retourner en ramasser pour augmenter son score, ce qui engage à collecter le plus d'objet possible.  
Lors de l'exploration, la mécanique d'**Eviter** est représentée par les gardes, qu'il n'est pas possible de combattre, il faut nécessairement les fuir. Chaque objet ramassé possède également un poid qui va ralentir le déplacement du personnage. Il faut donc trouver un équilibre entre la valeur que l'on veut récolter et la capacité à esquiver les gardes.


## Réalisation technique

### Mouvements du joueur
*Réalisé par Nathan*

### Déplacement des NPCs
*Réalisé par Matéo*  

Pour développer l'intelligence des NPCs, j'ai choisi d'implémenter une machine à états permettant de suivre les différents états possible des gardes.  

![Schema de la machine à état représentant le comportement des NPCs](/Docs/NPC_state_machine.drawio.png "NPC behaviour state machine")

Par défaut, les gardes sont en état de patrouille : ils naviguent entre des checkpoints définis dans l'éditeur grâce au composant navMeshAgent.  

La détection du joueur se fait au moyen d'un Collider circulaire autour du NPC. Lorsque le joueur rentre dans ce Collider, le garde trace un rayon entre lui et le joueur pour détecter d'éventuels obstacles qui lui bloqueraient la vue, et s'il est en capacité de voir le joueur, il passe en état de poursuite.  

En état de poursuite, le garde garde en mémoire la dernière position où le joueur a été détecté et s'y dirige. Cette position est mise à jour tant que le joueur est visible. Si le garde atteint cette position et que le joueur n'est plus visible ou que le temps de poursuite maximum s'est écoulé, il abandonne la poursuite et repasse en état de patrouille.  

Si le garde touche le joueur (détecté grâce à un deuxième Collider légèrement plus grand que le corps du garde), il déclenche une "attaque" sur le joueur, lui faisant perdre un objet, avant de passer en état Idle. Cet état l'immobilise et symbolise un délai avant qu'il ne recommence la poursuite, pour permette au joueur de s'échapper. L'état idle a une durée fixe, après quoi le garde recommence la détection du joueur.  

Lorque que le garde reçoit un projectile, son état actuel est interrompu et il passe en état de Stun, ce qui l'immobilise pendant une durée définie. Il reprend après son comportement normal.  


#### Implémentation technique

La classe abstraite *State* défini un état possible pour le NPC. Chaque état implémente cette classe et défini le comportement du NPC dans cet état, ainsi que la condition de fin de cet état.
Le NPC possède un composant principal NPCControler, qui rassemble les composants de détection et gère les conditions d'entrée dans chaque état.