   M S B A M L   `   `   `  ����  Projet_CALENDRIER"    Projet_CALENDRIER.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Fenetre_Administration��5   	   $��558.4��6(   $	��800��67   .��5      � .+�5   
   �� $
��Left=�6   $	��450��60   $��	10,69,0,0q�6=   $	��Top=�6P   $	��774��6h   .@�5      �� $��Gestion des Classes��6   $��2,0,-2,0q�63   $	��192��6E   .��5      � ���	#FFE5E5E5.+�5	      �� $
��Left=�6!   $	��402��6<   $��	10,10,0,0q�6I   $	��Top=�6\   $	��749��6t   .@�5
      �� $��Afficher les Classes��6"   .��5      � ���	#FFE5E5E5.+�5   "   �� -   5        $��listeClasse��5   *   $
��Left=�6=   $
��auto��6X   $	��300��6f   6r   �� 5   "   -   5        $��modifclasse��5   )   $��Modifier��6<   $��Center=�6O   $��50��6l   $	��100��6x   $	��Top=�6�   6�   �� 5   "   -   5        $��supprclasse��5   )   $��	Supprimer��6<   $��Center=�6P   $��50��6m   $	��100��6y   $��Stretch=�6�   6�   � 5   "   -   5        $��afficheClasse��5   '   $��Right=�6<   $	��300��6X   .+�5   &   �� $��Nom : ��6-   �� 5   &   $��	Niveau : ��6,   $��0,50,0,0q�6@   �� 5   &   -   5        $��nommodifclasse��5   .   $��50,0,0,0q�6D   $	��250��6V   $��30��6b   $	��Top=�6n   �� 5   &   -   5        $��niveaumodifclasse��5   /   $	��Top=�6H   $	��200��6`   $��30��6l   $��
 50,50,0,0q�6x   5   #   5      5      �� 5      $��Ajouter une Classe��6"   .��5      � ���	#FFE5E5E5.+�5   "   �� -   5         ��Name$ text_add_classe��5   *   $
��Left=�6C   $��30��6^   $��339,172,0,0q�6j    �� TextWrapping$
 Wrap=�6   $	��Top=�6�   $	��300��6�   �� 5   "   -   5         ��Name$ valider_add_classe��5   )   $��Valider��6E   $
��Left=�6W   $��30��6r   $��278,256,0,0q�6~   $	��Top=�6�   $	��100��6�   6�   �� 5   "   $%��Saisissez le nom de la classe :��6(   $
��Left=�6R   $��30��6m   $��124,172,0,0q�6y   $	��Top=�6�   $	��183��6�   5      5      5       5!      5"      �� 5#      $��Gestion des Enseignants��6   $
��Left=�67   $��20��6R   $	��Top=�6^   $	��192��6v   $��1.075,0,-1.075,0q�6�   .��5$      � ���	#FFE5E5E5.+�5%      �� $
��Left=�6!   $	��398��6<   $��	10,10,0,0q�6I   $	��Top=�6\   $	��742��6t   .@�5&      �� $��Afficher les Enseignants��6"   .��5'      � ���	#FFE5E5E5.+�5(   "   �� -	   5        $��listeTeacher��5(   *   $
��Left=�6>   $
��auto��6Y   $	��300��6g   6�   �� 5)   "   -
   5        $��modifteacher��5)   )   $��Modifier��6=   $��Center=�6P   $��50��6m   $	��100��6y   $	��Top=�6�   6�   �� 5*   "   -   5        $��supprteacher��5*   )   $��	Supprimer��6=   $��Center=�6Q   $��50��6n   $	��100��6z   $��Stretch=�6�   6�   � 5+   "   -   5        $��afficheTeacher��5+   '   $��Right=�6=   $	��300��6Y   .+�5,   &   �� $��Nom : ��6,   �� 5-   &   $��	Prenom : ��6,   $��0,50,0,0q�6@   �� 5.   &   $��Matière : ��6,   $��	0,100,0,0q�6A   �� 5/   &   -   5        $��nomteachermodif��5/   .   $��50,0,0,0q�6E   $	��250��6W   $��30��6c   $	��Top=�6o   �� 50   &   -   5        $��prenomteachermodif��50   .   $	��Top=�6H   $	��200��6`   $��30��6l   $��
 50,50,0,0q�6x   �� 51   &   -   5         ��Name$ combomatieremodif��51   0   $	��Top=�6K   $��30��6c   $��100,100,0,0q�6o   52   #   53      54      �� 55      $��Ajouter un Enseignant��6"   .��56      � ���	#FFE5E5E5.+�57   "   �� $��
Prénom : ��6(   $
��Left=�6<   $��30��6W   $��	94,83,0,0q�6c   $	��Top=�6v   $	��165��6�   �� 58   "   $��Nom : ��6(   $
��Left=�69   $��30��6T   $��
94,139,0,0q�6`   $	��Top=�6t   $	��165��6�   �� 59   "   $��Matière enseignée : ��6(   $
��Left=�6G   $��30��6b   $��
94,195,0,0q�6n   $	��Top=�6�   $	��165��6�   �� 5:   "   -   5        $ text_prenom_prof��5:   *   $
��Left=�6D   $��30��6_   $��
310,83,0,0q�6k   $
 Wrap=�6   $	��Top=�6�   $	��238��6�   �� 5;   "   -   5        $ text_nom_prof��5;   *   $
��Left=�6A   $��30��6\   $��310,139,0,0q�6h   $
 Wrap=�6}   $	��Top=�6�   $	��238��6�   �� 5<   "   -   5        $ combo_matiere_prof��5<   ,   $	��Top=�6H   $��30��6`   $��310,195,184,0q�6l   �� 5=   "   -   5        $ valider_add_prof��5=   )   $��Valider��6C   $
��Left=�6U   $��30��6p   $��297,256,0,0q�6|   $	��Top=�6�   $	��110��6�   6�   5>      5?      5@      5A      5B      �� 5C      $��Gestion des Elèves��6   $
��Left=�62   $��20��6M   $	��Top=�6Y   $	��192��6q   $��-0.337,0,0,0q�6}   .��5D      � ���	#FFE5E5E5.+�5E      �� $
��Left=�6!   $	��398��6<   $��	10,10,0,0q�6I   $	��Top=�6\   $	��742��6t   .@�5F      �� $��Afficher les Elèves��6"   .��5G      � ���	#FFE5E5E5.+�5H   "   �� -   5        $��listeStudent��5H   *   $
��Left=�6>   $
��auto��6Y   $	��300��6g   6�   �� 5I   "   -   5        $��modifstudent��5I   )   $��Modifier��6=   $��Center=�6P   $��50��6m   $	��100��6y   $	��Top=�6�   6�   �� 5J   "   -   5        $��supprstudent��5J   )   $��	Supprimer��6=   $��Center=�6Q   $��50��6n   $	��100��6z   $��Stretch=�6�   6�   � 5K   "   -   5        $��afficheStudent��5K   '   $��Right=�6=   $	��300��6Y   .+�5L   &   �� $��Nom : ��6,   �� 5M   &   $��	Prenom : ��6,   $��0,50,0,0q�6@   �� 5N   &   $��	Classe : ��6,   $��	0,100,0,0q�6@   �� 5O   &   -   5        $��nommodifstudent��5O   /   $��50,0,0,0q�6F   $	��250��6X   $��30��6d   $	��Top=�6p   �� 5P   &   -   5        $��prenommodifstudent��5P   .   $��	50,50,0,0q�6H   $	��240��6[   $��30��6g   $	��Top=�6s   �� 5Q   &   -   5        $��classemodifstudent��5Q   0   $	��Top=�6J   $	��200��6b   $��30��6n   $�� 50,100,0,0q�6z   5R   #   5S      5T      �� 5U      $��Ajouter un Elève��6"   .��5V      � ���	#FFE5E5E5.+�5W   "   �� $��
Prénom : ��6(   $
��Left=�6<   $��30��6W   $��	94,83,0,0q�6c   $	��Top=�6v   $	��165��6�   �� 5X   "   $��Nom : ��6(   $
��Left=�69   $��30��6T   $��
94,139,0,0q�6`   $	��Top=�6t   $	��165��6�   �� 5Y   "   -   5        $��prenomEleve��5Y   *   $
��Left=�6=   $��30��6X   $��
310,83,0,0q�6d   $
 Wrap=�6x   $	��Top=�6�   $	��238��6�   �� 5Z   "   -   5        $��AddEleve��5Z   )   $��Valider��69   $
��Left=�6K   $��30��6f   $��340,286,0,0q�6r   $	��Top=�6�   $	��110��6�   6�   �� 5[   "   -   5        $��nomEleve��5[   *   $
��Left=�6:   $��30��6U   $��310,141,0,0q�6a   $
 Wrap=�6v   $	��Top=�6�   $	��238��6�   �� 5\   "   $��	Classe : ��6(   $
��Left=�6<   $��30��6W   $��
94,205,0,0q�6c   $	��Top=�6w   $	��165��6�   �� 5]   "   -   5        $ classe_to_eleve��5]   +   $
��Left=�6D   $��30��6_   $��313,205,0,0q�6k   $	��Top=�6�   $	��235��6�   5^      5_      5`      5a      5b      �� 5c      $��Gestion des Salles��6   $
��Left=�62   $��20��6M   $	��Top=�6Y   $	��192��6q   $��-1,0,0,0q�6}   .��5d      � ���	#FFE5E5E5.+�5e      �� $
��Left=�6!   $	��398��6<   $��	10,10,0,0q�6I   $	��Top=�6\   $	��742��6t   .@�5f      �� $��Afficher les Salles��6"   .��5g      � ���	#FFE5E5E5.+�5h   "   �� -   5        $��listesalles��5h   *   $
��Left=�6>   $
��auto��6Y   $	��300��6g   6�   �� 5i   "   -    5        $��
modifsalle��5i   )   $��Modifier��6;   $��Center=�6N   $��50��6k   $	��100��6w   $	��Top=�6�   6�   �� 5j   "   -!   5        $��
supprsalle��5j   *   $��	Supprimer��6<   $��Center=�6P   $��50��6m   $	��100��6y   $��Stretch=�6�   6�   � 5k   "   -"   5        $��afficheRoom��5k   '   $��Right=�6:   $	��300��6V   .+�5l   &   �� $��Nom de la salle: ��6,   �� 5m   &   $��Capacité : ��6,   $��0,50,0,0q�6B   �� 5n   &   -#   5        $��nomsallemodif��5n   .   $��50,0,0,0q�6C   $	��250��6U   $��30��6a   $	��Top=�6m   �� 5o   &   -$   5        $��capacitysallemodif��5o   .   $	��Top=�6H   $	��200��6`   $��30��6l   $��
 50,50,0,0q�6x   5p   #   5q      5r      �� 5s      $��Ajouter une Salle��6"   .��5t      � ���	#FFE5E5E5.+�5u   "   �� $��Nom de la Salle : ��6(   $
��Left=�6E   $��30��6`   $��115,104,0,0q�6l   $	��Top=�6�   $	��135��6�   �� 5v   "   $��Capacité : ��6(   $
��Left=�6>   $��30��6Y   $��115,174,0,0q�6e   $	��Top=�6z   $	��135��6�   �� 5w   "   -%   5        $ text_add_nom_salle��5w   *   $
��Left=�6F   $��30��6a   $��317,104,0,0q�6m   $
 Wrap=�6�   $	��Top=�6�   $	��261��6�   �� 5x   "   -&   5        $ text_add_capacite_salle��5x   *   $
��Left=�6K   $��30��6f   $��317,174,0,0q�6r   $
 Wrap=�6�   $	��Top=�6�   $	��261��6�   �� 5y   "   -'   5        $ valider_add_salle��5y   )   $��Valider��6D   $
��Left=�6V   $��30��6q   $��285,271,0,0q�6}   $	��Top=�6�   $	��110��6�   6�   5z      5{      5|      5}      5~      �� 5      $��Gestion des Matières��6   $
��Left=�64   $��20��6O   $	��Top=�6[   $	��192��6s   $��-1,0,0,0q�6   .��5�      � ���	#FFE5E5E5.+�5�      �� $
��Left=�6!   $	��398��6<   $��	10,10,0,0q�6I   $	��Top=�6\   $	��742��6t   .@�5�      �� $��Afficher les matières��6"   .��5�      � ���	#FFE5E5E5.+�5�   "   �� -(   5        $��listematiere��5�   *   $
��Left=�6?   $
��auto��6Z   $	��300��6h   6�   �� 5�   "   -)   5        $��modifmatiere��5�   )   $��Modifier��6=   $��Center=�6P   $��50��6m   $	��100��6y   $	��Top=�6�   6�   �� 5�   "   -*   5        $��supprmatiere��5�   *   $��	Supprimer��6>   $��Center=�6R   $��50��6o   $	��100��6{   $��Stretch=�6�   6�   �� 5�   "   -+   5        $��affichematiere��5�   )   $��Right=�6?   $	��300��6[   .+�5�   &   �� $��Nom de la matiere: ��6,   �� 5�   &   -,   5        $��nommatieremodif��5�   .   $��50,0,0,0q�6E   $	��250��6W   $��30��6c   $	��Top=�6o   5�   #   5�      5�      �� 5�      $��Ajouter une matiere��6"   .��5�      � ���	#FFE5E5E5.+�5�   "   �� $��Nom de la matiere : ��6(   $
��Left=�6G   $��30��6b   $��115,104,0,0q�6n   $	��Top=�6�   $	��135��6�   �� 5�   "   --   5        $ text_add_matiere��5�   *   $
��Left=�6D   $��30��6_   $��317,104,0,0q�6k   $
 Wrap=�6�   $	��Top=�6�   $	��261��6�   �� 5�   "   -.   5        $ valider_add_matiere��5�   )   $��Valider��6F   $
��Left=�6X   $��30��6s   $��285,271,0,0q�6   $	��Top=�6�   $	��110��6�   6�   5�      5�      5�      5�      5�      5�      �� 5�   
   -/   5        $ BouttonPlanning��5�      $��Afficher le Planning��6*   $
��Left=�6I   $��30��6d   $��
243,21,0,0q�6p   $	��Top=�6�   $	��263��6�   6�   5�      5�      