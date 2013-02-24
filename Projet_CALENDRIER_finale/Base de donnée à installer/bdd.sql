-- phpMyAdmin SQL Dump
-- version 2.9.1.1
-- http://www.phpmyadmin.net
-- 
-- Serveur: localhost
-- Généré le : Samedi 23 Février 2013 à 19:08
-- Version du serveur: 5.0.27
-- Version de PHP: 5.2.0
-- 
-- Base de données: `calendrier`
-- 

-- --------------------------------------------------------

-- 
-- Structure de la table `classe`
-- 

CREATE TABLE `classe` (
  `id_classe` int(5) NOT NULL,
  `libelle_classe` varchar(20) default NULL,
  PRIMARY KEY  (`id_classe`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Contenu de la table `classe`
-- 

INSERT INTO `classe` (`id_classe`, `libelle_classe`) VALUES 
(1, 'TES3'),
(2, 'TES2'),
(3, 'TES5'),
(4, 'TS1'),
(5, 'TL1');

-- --------------------------------------------------------

-- 
-- Structure de la table `cours`
-- 

CREATE TABLE `cours` (
  `id_classe` int(5) NOT NULL,
  `id_salle` int(5) NOT NULL,
  `id_user` int(5) NOT NULL,
  `date_cours` varchar(20) default NULL,
  `heure_debut_cours` int(10) default NULL,
  `nb_heure_cours` int(10) default NULL,
  PRIMARY KEY  (`id_classe`,`id_salle`,`id_user`),
  KEY `FK_Cours_id_salle` (`id_salle`),
  KEY `FK_Cours_id_user` (`id_user`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Contenu de la table `cours`
-- 

INSERT INTO `cours` (`id_classe`, `id_salle`, `id_user`, `date_cours`, `heure_debut_cours`, `nb_heure_cours`) VALUES 
(3, 3, 2, '26/02/2013 00:00:00', 16, 1),
(5, 1, 6, '28/02/2013 00:00:00', 13, 1);

-- --------------------------------------------------------

-- 
-- Structure de la table `matiere`
-- 

CREATE TABLE `matiere` (
  `id_matiere` int(5) NOT NULL,
  `libelle_matiere` varchar(20) default NULL,
  PRIMARY KEY  (`id_matiere`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Contenu de la table `matiere`
-- 

INSERT INTO `matiere` (`id_matiere`, `libelle_matiere`) VALUES 
(1, 'Maths'),
(2, 'Japonais'),
(3, 'Chinois'),
(4, 'Deutch'),
(5, 'Polska');

-- --------------------------------------------------------

-- 
-- Structure de la table `salle`
-- 

CREATE TABLE `salle` (
  `id_salle` int(5) NOT NULL,
  `numero_salle` int(5) default NULL,
  `capacite_salle` int(5) default NULL,
  PRIMARY KEY  (`id_salle`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Contenu de la table `salle`
-- 

INSERT INTO `salle` (`id_salle`, `numero_salle`, `capacite_salle`) VALUES 
(1, 18, 150),
(2, 15, 32),
(3, 12, 100);

-- --------------------------------------------------------

-- 
-- Structure de la table `type_user`
-- 

CREATE TABLE `type_user` (
  `id_type_user` int(5) NOT NULL,
  `libelle_type_user` varchar(20) default NULL,
  PRIMARY KEY  (`id_type_user`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Contenu de la table `type_user`
-- 

INSERT INTO `type_user` (`id_type_user`, `libelle_type_user`) VALUES 
(1, 'admin'),
(2, 'teacher'),
(3, 'student');

-- --------------------------------------------------------

-- 
-- Structure de la table `user`
-- 

CREATE TABLE `user` (
  `id_user` int(5) NOT NULL auto_increment,
  `nom_user` varchar(50) default NULL,
  `prenom_user` varchar(20) default NULL,
  `email_user` varchar(100) default NULL,
  `photo_user` varchar(255) default NULL,
  `id_classe` int(5) default NULL,
  `id_type_user` int(5) default NULL,
  `id_matiere` int(5) default NULL,
  PRIMARY KEY  (`id_user`),
  KEY `FK_user_id_classe` (`id_classe`),
  KEY `FK_user_id_type_user` (`id_type_user`),
  KEY `FK_user_id_matiere` (`id_matiere`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=12 ;

-- 
-- Contenu de la table `user`
-- 

INSERT INTO `user` (`id_user`, `nom_user`, `prenom_user`, `email_user`, `photo_user`, `id_classe`, `id_type_user`, `id_matiere`) VALUES 
(1, 'ARISTYL', 'Cherline', 'cherline@styl.fr', NULL, 1, 3, NULL),
(2, 'PRZYBYLA', 'Sandra', 'sandra.prz@ybyla.net', NULL, NULL, 2, 5),
(3, 'GEL', 'Patricia', NULL, NULL, 1, 3, NULL),
(4, 'PAUL', 'Malaki', NULL, NULL, 2, 3, NULL),
(5, 'RENEGA', 'Henri', NULL, NULL, NULL, 2, 3),
(6, 'BOULIEIL', 'Marine', NULL, NULL, NULL, 2, 2),
(7, 'STAUBLE', 'Charly', NULL, NULL, NULL, 2, 1),
(8, 'DIANINGANA', 'Jeryce', NULL, NULL, 1, 3, NULL),
(9, 'OULLA', 'Farid', NULL, NULL, 4, 3, NULL),
(10, 'VERNEUIL', 'Valerie', NULL, NULL, 4, 3, NULL),
(11, 'ARDOISE', 'Ambroise', NULL, NULL, NULL, 2, 2);

-- 
-- Contraintes pour les tables exportées
-- 

-- 
-- Contraintes pour la table `cours`
-- 
ALTER TABLE `cours`
  ADD CONSTRAINT `FK_Cours_id_classe` FOREIGN KEY (`id_classe`) REFERENCES `classe` (`id_classe`),
  ADD CONSTRAINT `FK_Cours_id_salle` FOREIGN KEY (`id_salle`) REFERENCES `salle` (`id_salle`),
  ADD CONSTRAINT `FK_Cours_id_user` FOREIGN KEY (`id_user`) REFERENCES `user` (`id_user`);

-- 
-- Contraintes pour la table `user`
-- 
ALTER TABLE `user`
  ADD CONSTRAINT `FK_user_id_classe` FOREIGN KEY (`id_classe`) REFERENCES `classe` (`id_classe`),
  ADD CONSTRAINT `FK_user_id_matiere` FOREIGN KEY (`id_matiere`) REFERENCES `matiere` (`id_matiere`),
  ADD CONSTRAINT `FK_user_id_type_user` FOREIGN KEY (`id_type_user`) REFERENCES `type_user` (`id_type_user`);
