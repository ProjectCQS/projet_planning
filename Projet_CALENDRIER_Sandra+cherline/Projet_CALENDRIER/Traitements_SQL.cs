﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Projet_CALENDRIER
{
    class Traitements_SQL
    {
        /*
         * chaine de caractère permettant la connexion
         */
        string MyConString = "SERVER=localhost;" + "DATABASE=calendrier;" + "UID=root;" + "PASSWORD=;";

        /*
         * retourne la chaine de connexion
         */
        public string get_MyConString()
        {
            return MyConString;
        }

        /*
         * ajout d'une classe
         */
        public void add_classe(string classe)
        {
            MySqlConnection sqlConnection = new MySqlConnection(MyConString);
            string sqlQuery = "INSERT INTO classe  VALUES ('',@class)";
            MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, sqlConnection);
            sqlCmd.Parameters.Add(new MySqlParameter("@class", classe));
            sqlConnection.Open();
            sqlCmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Vous venez de rajouter la classe "+classe);   
        }

        /*
         * ajout d'une salle
         */
        public void add_salle(string nom,string capacite)
        {
            MySqlConnection sqlConnection = new MySqlConnection(MyConString);
            string sqlQuery = "INSERT INTO salle  VALUES ('',@nom,@capacite)";
            MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, sqlConnection);
            sqlCmd.Parameters.Add(new MySqlParameter("@nom", nom));
            sqlCmd.Parameters.Add(new MySqlParameter("@capacite", capacite));
            sqlConnection.Open();
            sqlCmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Vous venez de rajouter la salle " + nom+" dont la capacite est de : "+capacite);
        }

        /*
         * ajout d'une matiere
         */
        public void add_matiere(string matiere)
        {
            MySqlConnection sqlConnection = new MySqlConnection(MyConString);
            string sqlQuery = "INSERT INTO matiere  VALUES ('',@matiere)";
            MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, sqlConnection);
            sqlCmd.Parameters.Add(new MySqlParameter("@matiere", matiere));
            sqlConnection.Open();
            sqlCmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Vous venez de rajouter la matière " + matiere);
        }

        /*
         * ajout d'un user
         */
        public void add_user(string nom,string prenom,string email,string photo,int classe,int type, int matiere)
        {
            MySqlConnection sqlConnection = new MySqlConnection(MyConString);
            string sqlQuery = "INSERT INTO user(id_user,nom_user,prenom_user,id_classe,id_type_user, id_matiere)  VALUES ('',@nom,@prenom,@classe,@type,@matiere)";//,@email,@photo,@classe
            MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, sqlConnection);
            sqlCmd.Parameters.Add(new MySqlParameter("@nom", nom));
            sqlCmd.Parameters.Add(new MySqlParameter("@prenom", prenom));
            //sqlCmd.Parameters.Add(new MySqlParameter("@photo", photo));
            sqlCmd.Parameters.Add(new MySqlParameter("@classe", classe));
            sqlCmd.Parameters.Add(new MySqlParameter("@type", type));
            sqlCmd.Parameters.Add(new MySqlParameter("@matiere", matiere));
            sqlConnection.Open();
            sqlCmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Vous venez de rajouter " +nom+" "+prenom);
        }
        public void add_user(string nom, string prenom, string email, string photo, int type, int matiere)
        {
            MySqlConnection sqlConnection = new MySqlConnection(MyConString);
            string sqlQuery = "INSERT INTO user(id_user,nom_user,prenom_user,id_type_user, id_matiere)  VALUES ('',@nom,@prenom,@type,@matiere)";//,@email,@photo,@classe
            MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, sqlConnection);
            sqlCmd.Parameters.Add(new MySqlParameter("@nom", nom));
            sqlCmd.Parameters.Add(new MySqlParameter("@prenom", prenom));
            //sqlCmd.Parameters.Add(new MySqlParameter("@photo", photo));
           // sqlCmd.Parameters.Add(new MySqlParameter("@classe", classe));
            sqlCmd.Parameters.Add(new MySqlParameter("@type", type));
            sqlCmd.Parameters.Add(new MySqlParameter("@matiere", matiere));
            sqlConnection.Open();
            sqlCmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Vous venez de rajouter " + nom + " " + prenom);
        }


        /*
         * 
         * tests modifications
         * 
         */

        /* 
         * modification d'une classe
         */
       /* public void update_classe(string libelle,int id)
        {
            MySqlConnection sqlConnexion = new MySqlConnection(MyConString);
            MySqlCommand sqlCmd = new MySqlCommand("UPDATE classe SET libelle_classe =" + libelle + " WHERE id_classe = " + id);
            sqlConnexion.Open();
            sqlCmd.ExecuteNonQuery();
            sqlConnexion.Close();
            MessageBox.Show("Vous venez de modifier "+libelle);
        }

        public void delete_classe(int id)
        {
            MessageBox.Show("supprimé : " + id);
        }*/

        private string[] connectBdd(string req)
        {
            MySqlConnection connection = new MySqlConnection(MyConString);            
             String thisrow = "";
            int j = 0;
            MySqlDataReader Reader;
            MySqlCommand command = connection.CreateCommand();
            connection.Open(); 
            command.CommandText = req; 
            Reader = command.ExecuteReader();
            while (Reader.Read()) 
            {
                for (int i = 0; i < Reader.FieldCount; i++)
                  thisrow += Reader.GetValue(i).ToString()+",";
                thisrow += ";";
            }
            connection.Close();
            char[] separator = {';','\t'};
            String[] resultat = thisrow.Split(separator);
            return resultat;
           
        }
        public String[] listeSql(string liste)
        {
            string resultat ="";

            switch (liste)
            {
                case "matiere":
                    resultat = "select * from matiere";
                break;
                case "room":
                resultat = "select * from salle";
                break;
                case "student":
                resultat = "select * from user where id_type_user = 3";
                break;
                case "teacher":
                resultat = "select * from user where id_type_user = 2";
                break;
                case "classe":
                resultat = "select * from classe";
                break;
            }
            return connectBdd(resultat);
            
        }

        public void updateSQL(string liste, string id, string[] modif)
        {
            string resultat = "";
            int i=0;
            switch (liste)
            {
                case "matiere":
                    resultat = "update matiere set libelle_matiere=\"" + modif[0] + "\"  where id_matiere =" + id;
                    break;
                case "room":
                    resultat = "update salle set numero_salle=" + modif[0] + " , capacite_salle=" + modif[1] + " where id_salle = " + id;                                
                    break;
                case "student":
                    resultat = "update user set nom_user=\"" + modif[0] + "\" , prenom_user=\"" + modif[1] + "\" , id_classe="+Int32.Parse(modif[2])+" where id_user = " + id;
                    
                    break;
                case "teacher":
                    resultat = "update user set nom_user=\"" + modif[0] + "\" , prenom_user=\"" + modif[1] + "\" , id_matiere="+Int32.Parse(modif[2])+" where id_user = " + id;
                    break;
                case "classe":
                    resultat = "update classe set libelle_classel=\"" + modif[0] + "\" where id_classe  =" + id;
                    break;
            }
            connectBdd(resultat); 
            
        }

        public void deleteSql(string liste, string id)
        {
            string resultat = "";
            switch (liste)
            {
                case "matiere":
                    resultat = "delete from matiere where id_matiere ="+ id;
                    break;
                case "room":
                    resultat = "delete from salle where id_salle = "+id;
                    break;
                case "student":
                    resultat = "delete from user where id_user = "+id;
                    break;
                case "teacher":
                    resultat = "delete from user where id_user = "+id;
                    break;
                case "classe":
                    resultat = "delete from classe where id_classe  "+id;
                    break;
            }
            connectBdd(resultat);
        }



    }
}
