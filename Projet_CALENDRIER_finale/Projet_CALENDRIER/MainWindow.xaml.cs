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
        public char[] sep = { ' ', ',', '\t' };
        public String[] classe, Room, Student, Teacher, Matiere, Cours, Users;
        public Traitements_SQL tsql = new Traitements_SQL();


        public MainWindow()
        {
            InitializeComponent();
            AfficheComposant();
            setLocation(((System.Windows.SystemParameters.PrimaryScreenWidth / 2) - (this.Width / 2)), ((System.Windows.SystemParameters.PrimaryScreenHeight / 2) - (this.Height / 2)));
            pos = 0; // element en modification ou non
        }

        private void AfficheComposant()
        {
            int[] horaire = new int[11];
            for (int h = 8, i = 0; h < 19; h++, i++)
            {
                horaire[i] = h;
                add_cours_heure.Items.Add(horaire[i]);
            }

            char[] sep = { ',', '\t' };
            //String[] classe, Room, Student, Teacher, Matiere;

            classe = tsql.listeSql("classe");
            String[] vclasse = new string[classe.Length];
            for (int c = 0; c < classe.Length - 1; c++)
            {
                vclasse = classe[c].Split(sep);
                listeClasse.Items.Add(vclasse[1]);
                add_cours_classe.Items.Add(vclasse[1]);
            }

            Room = tsql.listeSql("room");
            String[] vRoom = new string[Room.Length];
            for (int c = 0; c < Room.Length - 1; c++)
            {
                vRoom = Room[c].Split(sep);
                listesalles.Items.Add(vRoom[1]);
                add_cours_room.Items.Add(vRoom[1]);
            }

            Users = tsql.listeSql("users");

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
                add_cours_enseignant.Items.Add(vTeacher[1]);
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

            Cours = tsql.listeSql("cours");
            String[] vcours = new string[Cours.Length];
            bool trouve = false; int ii = 0;
            for (int c = 0; c < Cours.Length - 1; c++)
            {
                vcours = Cours[c].Split(sep);                
                while ((ii < Teacher.Length) && !trouve)
                {
                    if (Teacher[ii].Split(sep)[0].Trim() != "")
                    {
                        if (Int32.Parse(Teacher[ii].Split(sep)[0]) == Int32.Parse(vcours[2]))
                        {
                            listecours.Items.Add(Teacher[ii].Split(sep)[1]);
                            trouve = true;
                        }
                    }
                    ii++;
                }
                trouve = false;
                //listecours.Items.Add(detailCours(vcours)); probleme cherline
            }

            afficheRoom.Visibility = Visibility.Hidden;
            afficheClasse.Visibility = Visibility.Hidden;
            afficheStudent.Visibility = Visibility.Hidden;
            afficheTeacher.Visibility = Visibility.Hidden;
            affichematiere.Visibility = Visibility.Hidden;
            detCours.Visibility = Visibility.Hidden;
            detCours.IsEnabled = false;
            afficheRoom.IsEnabled = false;
            afficheClasse.IsEnabled = false;
            afficheStudent.IsEnabled = false;
            afficheTeacher.IsEnabled = false;
            affichematiere.IsEnabled = false;
            add_cours_matiere.IsEnabled = false;

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
            add_cours_classe.Items.Clear();
            add_cours_enseignant.Items.Clear();
            add_cours_room.Items.Clear();
            add_cours_heure.Items.Clear();
            listecours.Items.Clear();
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

        private void add_cours_enseignant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (add_cours_enseignant.SelectedIndex != -1)
            {
                String ff = Teacher[add_cours_enseignant.SelectedIndex].Split(sep)[7];
                int i = 0;
                bool trouve = false;
                while ((i < Matiere.Length) && (!trouve))
                {
                    if (Matiere[i].Split(sep)[0] == ff)
                    {
                        add_cours_matiere.Text = Matiere[i].Split(sep)[1];
                        trouve = true;
                    }
                    i++;
                }
            }
               
        }

        private void valider_add_cours_Click(object sender, RoutedEventArgs e)
        {
            Traitements_SQL trt_sql = new Traitements_SQL();
            int prof, cl, salle, heure, nb_heure = 1;
            string datec;
            prof = Int32.Parse(Teacher[add_cours_enseignant.SelectedIndex].Split(sep)[0]);
            cl = Int32.Parse(classe[add_cours_classe.SelectedIndex].Split(sep)[0]);
            salle = Int32.Parse(Room[add_cours_room.SelectedIndex].Split(sep)[0]);
            heure = Int32.Parse(add_cours_heure.SelectedValue.ToString());
            datec = ""+datecours.SelectedDate;
            trt_sql.add_cours(prof,salle, cl,datec,heure,nb_heure);
            refreshAllComponent();
        }

        private void listecours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            detCours.Visibility = Visibility.Visible;
            pos = 0;
            if (listecours.SelectedIndex != -1)
            {
                coursprof.Text = listecours.SelectedValue.ToString();
                string[] s =Teacher[listecours.SelectedIndex].Split(sep);
                int f= Int32.Parse(s[7]);
                bool trouve = false; int i = 0;
                //for (; (); i++)
                while ((i < Matiere.Length)&& !trouve)
                {
                    if (Int32.Parse(Matiere[i].Split(sep)[0]) == f)
                    {
                        coursmatiere.Text= Matiere[i].Split(sep)[1];
                        trouve=true;
                    }
                    i++;
                }
                trouve = false;i = 0;
                 while ((i < classe.Length)&& !trouve)
                {
                     if (Int32.Parse(classe[i].Split(sep)[0]) == Int32.Parse(Cours[listecours.SelectedIndex].Split(sep)[0]))
                     {
                          coursclasse.Text=classe[i].Split(sep)[1];
                          trouve=true;
                     }
                     i++;
                }
                 trouve = false;i = 0;
                 while ((i < classe.Length)&& !trouve)
                {
                     if (Int32.Parse(Room[i].Split(sep)[0]) == Int32.Parse(Cours[listecours.SelectedIndex].Split(sep)[1]))
                     {
                          courssalle.Text=Room[i].Split(sep)[1];
                          trouve=true;
                     } i++;
                }
                coursdate.Text=Cours[listecours.SelectedIndex].Split(sep)[3]+ " à "+Cours[listecours.SelectedIndex].Split(sep)[5]+'h';

            }
        }

        private void supprcours_Click(object sender, RoutedEventArgs e)
        {
            if ((Suppression()) && (listecours.SelectedIndex != -1))
            {
                string prof, cl, salle;
                prof = Cours[listecours.SelectedIndex].Split(sep)[2];
                cl = Cours[listecours.SelectedIndex].Split(sep)[0];
                salle = Cours[listecours.SelectedIndex].Split(sep)[1];
                tsql.deleteCours(cl,prof,salle);
            }
            refreshAllComponent();

        }
    }
}
