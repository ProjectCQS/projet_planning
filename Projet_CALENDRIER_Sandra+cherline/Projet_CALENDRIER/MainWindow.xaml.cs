using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Projet_CALENDRIER
{
    /// <summary>
    /// Logique d'interaction pour Fenetre_Administration.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int pos;
        char[] sep = { ' ', ',', '\t' };
        String[] classe, Room, Student, Teacher, Matiere;
        Traitements_SQL tsql = new Traitements_SQL();


        public MainWindow()
        {
            InitializeComponent();
            AfficheComposant();
            setLocation(((System.Windows.SystemParameters.PrimaryScreenWidth / 2) - (this.Width / 2)), ((System.Windows.SystemParameters.PrimaryScreenHeight / 2) - (this.Height / 2)));
            pos = 0; // element en modification ou non
        }

        private void AfficheComposant()
        {


            char[] sep = { ',', '\t' };
            //String[] classe, Room, Student, Teacher, Matiere;
            classe = tsql.listeSql("classe");
            String[] vclasse = new string[classe.Length];
            for (int c = 0; c < classe.Length - 1; c++)
            {
                vclasse = classe[c].Split(sep);
                listeClasse.Items.Add(vclasse[1]);
            }


            Room = tsql.listeSql("room");
            String[] vRoom = new string[Room.Length];
            for (int c = 0; c < Room.Length - 1; c++)
            {
                vRoom = Room[c].Split(sep);
                listesalles.Items.Add(vRoom[1]);
            }

            Student = tsql.listeSql("student");
            String[] vStudent = new string[Student.Length];
            for (int c = 0; c < Student.Length - 1; c++)
            {
                vStudent = Student[c].Split(sep);
                listeStudent.Items.Add(vStudent[1]);
            }

            Teacher = tsql.listeSql("teacher");
            String[] vTeacher = new string[Teacher.Length];
            for (int c = 0; c < Teacher.Length - 1; c++)
            {
                vTeacher = Teacher[c].Split(sep);
                listeTeacher.Items.Add(vTeacher[1]);
            }

            Matiere = tsql.listeSql("matiere");
            String[] vMatiere = new string[Matiere.Length];
            for (int c = 0; c < Matiere.Length - 1; c++)
            {
                vMatiere = Matiere[c].Split(sep);
                listematiere.Items.Add(vMatiere[1]);
                combo_matiere_prof.Items.Add(vMatiere[1]);
                combomatieremodif.Items.Add(vMatiere[1]);
            }
            for (int i = 0; i < listeClasse.Items.Count; i++)
            {
                classe_to_eleve.Items.Add(classe[i].Split(sep)[1]);
                classemodifstudent.Items.Add(classe[i].Split(sep)[1]);
            }
            afficheRoom.Visibility = Visibility.Hidden;
            afficheClasse.Visibility = Visibility.Hidden;
            afficheStudent.Visibility = Visibility.Hidden;
            afficheTeacher.Visibility = Visibility.Hidden;
            affichematiere.Visibility = Visibility.Hidden;
            afficheRoom.IsEnabled = false;
            afficheClasse.IsEnabled = false;
            afficheStudent.IsEnabled = false;
            afficheTeacher.IsEnabled = false;
            affichematiere.IsEnabled = false;
/*
            using (var connection = new MySqlConnection(tsql.get_MyConString()))
            {
                connection.Open();
                var query = "SELECT libelle_classe FROM classe order by libelle_classe";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {

                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            listeClasse.Items.Add(reader.GetString("libelle_classe"));
                        }
                    }
                }
                connection.Close();
            }
            afficheRoom.Visibility = Visibility.Hidden;
            afficheClasse.Visibility = Visibility.Hidden;
            afficheStudent.Visibility = Visibility.Hidden;
            afficheTeacher.Visibility = Visibility.Hidden;
            afficheRoom.IsEnabled = false;
            afficheClasse.IsEnabled = false;
            afficheStudent.IsEnabled = false;
            afficheTeacher.IsEnabled = false;
*/
        }

        private void setLocation(double l, double t)
        {
            Left = l;
            Top = t;
        }

        private void BouttonPlanning_Click(object sender, RoutedEventArgs e)
        {
            Planning p = new Planning(this);
            p.Show();
            this.Hide();
        }

        private void listeClasse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            afficheClasse.Visibility = Visibility.Visible;
            pos = 0;
            char[] sep = { ' ', ',', '\t' };
            if (listeClasse.SelectedIndex != -1)
                nommodifclasse.Text = classe[listeClasse.SelectedIndex].Split(sep)[1];
          
        }

        private void supprclasse_Click(object sender, RoutedEventArgs e)
        {
            if ((Suppression()) && (listeClasse.SelectedIndex != -1))
                tsql.deleteSql("classe", classe[listeClasse.SelectedIndex].Split(sep)[0]);
            refreshAllComponent();
        }

        private void modifclasse_Click(object sender, RoutedEventArgs e)
        {

            if (0 == pos)
            {
                afficheClasse.IsEnabled = true;
                pos = 1;
            }
            else // enregistre dans la bdd
            {
                afficheClasse.IsEnabled = false;
                pos = 0;
                String[] str = { nommodifclasse.Text };
                tsql.updateSQL("classe", classe[listeClasse.SelectedIndex].Split(sep)[0], str);
                refreshAllComponent();
            }
        }

        private void listeTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            afficheTeacher.Visibility = Visibility.Visible;
            pos = 0;
            if (listeTeacher.SelectedIndex != -1)
            {
                nomteachermodif.Text = Teacher[listeTeacher.SelectedIndex].Split(sep)[1];
                prenomteachermodif.Text = Teacher[listeTeacher.SelectedIndex].Split(sep)[2];
                string[] s =Teacher[listeTeacher.SelectedIndex].Split(sep);
                int f= Int32.Parse(s[7]);
                bool trouve = false; int i = 0;
                //for (; (); i++)
                while ((i < Matiere.Length)&& !trouve)
                {
                    if (Int32.Parse(Matiere[i].Split(sep)[0]) == f)
                    {
                        combomatieremodif.SelectedValue = Matiere[i].Split(sep)[1];
                        trouve=true;
                    }
                    i++;
                }
                
                
            }
        }

        private void modifteacher_Click(object sender, RoutedEventArgs e)
        {
            if (0 == pos)
            {
                afficheTeacher.IsEnabled = true;
                pos = 1;
            }
            else // enregistre dans la bdd
            {
                afficheTeacher.IsEnabled = false;
                pos = 0;
                String[] str = { nomteachermodif.Text, prenomteachermodif.Text, Matiere[combomatieremodif.SelectedIndex].Split(sep)[0] };
                tsql.updateSQL("teacher", Teacher[listeTeacher.SelectedIndex].Split(sep)[0], str);
                refreshAllComponent();
            }
        }

        private void supprteacher_Click(object sender, RoutedEventArgs e)
        {
            if ((Suppression()) && (listeTeacher.SelectedIndex != -1))
                tsql.deleteSql("teacher", Teacher[listeTeacher.SelectedIndex].Split(sep)[0]);
            refreshAllComponent();

        }
        
        private void listeStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            afficheStudent.Visibility = Visibility.Visible;
            pos = 0;
            if (listeStudent.SelectedIndex != -1)
            {
                nommodifstudent.Text = Student[listeStudent.SelectedIndex].Split(sep)[1];
                prenommodifstudent.Text = Student[listeStudent.SelectedIndex].Split(sep)[2];
                string[] s =Student[listeStudent.SelectedIndex].Split(sep);
                int f= Int32.Parse(s[5]);

                //int ccc = Int32.Parse();
                classemodifstudent.SelectedValue = classe[f-1].Split(sep)[1];
            }
        }
        
        private void modifstudent_Click(object sender, RoutedEventArgs e)
        {
            if (0 == pos)
            {
                afficheStudent.IsEnabled = true;
                pos = 1;
            }
            else // enregistre dans la bdd
            {
                afficheStudent.IsEnabled = false;
                pos = 0;
                String[] str = { nommodifstudent.Text, prenommodifstudent.Text, classe[classemodifstudent.SelectedIndex].Split(sep)[0] };
                tsql.updateSQL("student", Student[listeStudent.SelectedIndex].Split(sep)[0], str);
                refreshAllComponent();
            }
        }

        private void supprstudent_Click(object sender, RoutedEventArgs e)
        {
            if ((Suppression()) && (listeStudent.SelectedIndex != -1))
                tsql.deleteSql("student", Student[listeStudent.SelectedIndex].Split(sep)[0]);
            refreshAllComponent();
        }

        private void listesalles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            afficheRoom.Visibility = Visibility.Visible;
            pos = 0;
            if (listesalles.SelectedIndex != -1)
            {
                nomsallemodif.Text = Room[listesalles.SelectedIndex].Split(sep)[1];
                capacitysallemodif.Text = Room[listesalles.SelectedIndex].Split(sep)[2];
            }
     
        }

        private void modifsalle_Click(object sender, RoutedEventArgs e)
        {
            //erreur

            if (0 == pos)
            {
                afficheRoom.IsEnabled = true;
                pos = 1;
            }
            else // enregistre dans la bdd
            {
                afficheRoom.IsEnabled = false;
                pos = 0;
                String[] str = { nomsallemodif.Text, capacitysallemodif.Text };
                tsql.updateSQL("room", Room[listesalles.SelectedIndex].Split(sep)[0], str);
                refreshAllComponent();
            }
 
        }

        private void supprsalle_Click(object sender, RoutedEventArgs e)
        {
            if ((Suppression()) && (listesalles.SelectedIndex != -1))
                tsql.deleteSql("room", Room[listesalles.SelectedIndex].Split(sep)[0]);
            refreshAllComponent();
        }

        private void listematiere_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            affichematiere.Visibility = Visibility.Visible;
            pos = 0;
            if (listematiere.SelectedIndex != -1)
                nommatieremodif.Text = Matiere[listematiere.SelectedIndex].Split(sep)[1];

        }

        private void modifmatiere_Click(object sender, RoutedEventArgs e)
        {

            if (0 == pos)
            {
                affichematiere.IsEnabled = true;
                pos = 1;
            }
            else // enregistre dans la bdd
            {
                affichematiere.IsEnabled = false;
                pos = 0;
                String[] str = { nommatieremodif.Text };
                tsql.updateSQL("matiere", Matiere[listematiere.SelectedIndex].Split(sep)[0], str);
                refreshAllComponent();
            }
        }

        private void supprmatiere_Click(object sender, RoutedEventArgs e)
        {
            if ((Suppression()) && (listematiere.SelectedIndex != -1))
                tsql.deleteSql("matiere", Matiere[listematiere.SelectedIndex].Split(sep)[0]);
            refreshAllComponent();

        }
       

        /*
         * affichage classe add eleve
         */ 
        /*private void classe_to_eleve_Loaded(object sender, RoutedEventArgs e)
        {
            Traitements_SQL tsql = new Traitements_SQL();

            using (var connection = new MySqlConnection(tsql.get_MyConString()))
            {
                connection.Open();
                var query = "SELECT libelle_classe FROM classe";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {

                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            classe_to_eleve.Items.Add(reader.GetString("libelle_classe"));
                        }
                    }
                }
                connection.Close();
            }
            for (int i = 0; i < listeClasse.Items.Count; i++)
                classe_to_eleve.Items.Add(classe[i].Split(sep)[1]);}*/
        

        /*
         * Ajouter une classe
         */
        private void valider_add_classe_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(text_add_classe.Text))
            {
                MessageBox.Show("Champ vide : impossible de rajouter ce nom de classe");
            }
            else
            {
                Traitements_SQL trt_sql = new Traitements_SQL();
                trt_sql.add_classe(text_add_classe.Text);
                text_add_classe.Text = "";
                refreshAllComponent();
            }
        }


        /*
         * Ajouter matiere
         */ 
        private void valider_add_matiere_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(text_add_matiere.Text))
            {
                MessageBox.Show("Champ vide : impossible de rajouter ce nom de classe");
            }
            else
            {
                Traitements_SQL trt_sql = new Traitements_SQL();
                trt_sql.add_matiere(text_add_matiere.Text);
                text_add_matiere.Text = "";
                refreshAllComponent();
            }
        }

        /*
         * Ajouter une salle
         */
        private void valider_add_salle_Click(object sender, RoutedEventArgs e)
        {
            //erreur
            if (string.IsNullOrEmpty(text_add_nom_salle.Text) || string.IsNullOrEmpty(text_add_capacite_salle.Text))
            {
                MessageBox.Show("Champ vide : impossible de rajouter ce nom de classe");
            }
            else
            {
                Traitements_SQL trt_sql = new Traitements_SQL();
                trt_sql.add_salle(text_add_nom_salle.Text, text_add_capacite_salle.Text);
                text_add_matiere.Text = "";
                refreshAllComponent();
            }
        }

        /*
         * Ajouter un enseignent
         */ 
        private void valider_add_prof_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(text_nom_prof.Text) || string.IsNullOrEmpty(text_prenom_prof.Text))
            {
                
                MessageBox.Show("Champ vide : impossible de rajouter ce nom de classe");
            }
            else
            {
                int cl = Int32.Parse(Matiere[combo_matiere_prof.SelectedIndex].Split(sep)[0]);
                Traitements_SQL trt_sql = new Traitements_SQL();
                trt_sql.add_user(text_nom_prof.Text, text_prenom_prof.Text,"","",2,cl);
                text_add_matiere.Text = "";
                refreshAllComponent();
            }
        }

        /*
        * Afficher classe dans combobox
        */
       /* private void classemodifstudent_Loaded(object sender, RoutedEventArgs e)
        {
            Traitements_SQL tsql = new Traitements_SQL();

            using (var connection = new MySqlConnection(tsql.get_MyConString()))
            {
                connection.Open();
                var query = "SELECT libelle_classe FROM classe";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {

                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            classemodifstudent.Items.Add(reader.GetString("libelle_classe"));
                        }
                    }
                }
                connection.Close();
            }
        }*/


        private bool Suppression()
        {
            bool rep = false;
            MessageBoxResult result = MessageBox.Show(this, "Vous êtes sur le point de supprimer définitivement. voulez vous continuer?", "Suppression", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                rep = true;

            }
            return rep;
        }

        /*
         * Rafraichissement des composants
         */
        private void refreshAllComponent()
        {
            listematiere.Items.Clear();
            listeClasse.Items.Clear();
            listeTeacher.Items.Clear();
            listesalles.Items.Clear();
            listeStudent.Items.Clear();
            classe_to_eleve.Items.Clear();
            classemodifstudent.Items.Clear();
            combo_matiere_prof.Items.Clear();
            combomatieremodif.Items.Clear();
            AfficheComposant();
            //   [listematiere.SelectedIndex] = listematiere.SelectedIndex;
        }


        private void AddEleve_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nomEleve.Text) || string.IsNullOrEmpty(prenomEleve.Text))
            {

                MessageBox.Show("Champ vide : impossible de rajouter ce nom de classe");
            }
            else
            {
                int cl =  Int32.Parse(classe[classe_to_eleve.SelectedIndex].Split(sep)[0]);
                Traitements_SQL trt_sql = new Traitements_SQL();
                trt_sql.add_user(nomEleve.Text, prenomEleve.Text, "", "", cl, 3,0);
                refreshAllComponent();
            }

        }

        

        

        

       
        
    }
}
