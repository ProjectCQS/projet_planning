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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projet_CALENDRIER
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class Planning : Window
    {
        private DateTime currentDate;
        private MainWindow parent;

        public Planning(MainWindow p)
        {
            parent = p;
            InitializeComponent();
            InitializeWindow();
        }

        private void InitializeWindow()
        {
            setSize(1280, 800);
            setLocation(((System.Windows.SystemParameters.PrimaryScreenWidth / 2) - (1280 / 2)), ((System.Windows.SystemParameters.PrimaryScreenHeight / 2) - (800 / 2)));
            currentDate = DateTime.Today;
            while (currentDate.DayOfWeek.ToString() != "Monday") currentDate = currentDate.AddDays(-1);
            setTitles();

            changeCourses();
        }

        private void changeCourses()
        {
            hideAll();
            for (int i = 0; i < parent.Cours.Length; i++)
            {
                if (parent.Cours[i].Trim() != "")
                {
                    int Daydiff = (Convert.ToDateTime(parent.Cours[i].Split(parent.sep)[3]) - currentDate).Days;
                    if (Daydiff >= 0 && Daydiff < 7)
                    {
                        int heure = int.Parse(parent.Cours[i].Split(parent.sep)[5]);
                        int salle = int.Parse(parent.Cours[i].Split(parent.sep)[1]);
                        int user = int.Parse(parent.Cours[i].Split(parent.sep)[2]);
                        int nbCours = int.Parse(parent.Cours[i].Split(parent.sep)[6]);

                        for (int j = 0; j < nbCours; j++)
                        {
                            changeContentCase(Daydiff,
                                              heure,
                                              parent.tsql.selectSqlbyId("matiere", int.Parse(parent.tsql.selectSqlbyId("user", user)[0].Split(parent.sep)[7]))[0].Split(parent.sep)[1],
                                              parent.tsql.selectSqlbyId("user", user)[0].Split(parent.sep)[1],
                                              parent.tsql.selectSqlbyId("salle", salle)[0].Split(parent.sep)[1]);
                        }
                    }
                }
            }
        }

        private void setSize(float w, float h)
        {
            this.Width = w;
            this.Height = h;
        }

        private void setLocation(double l, double t)
        {
            Left = l;
            Top = t;
        }

        private void setTitles()
        {
            Title_calendar.Content = "Semaine du " + currentDate.Day + " " + GetMonth(currentDate) + " " + currentDate.Year + " au " + currentDate.AddDays(6).Day + " " + GetMonth(currentDate.AddDays(6)) + " " + currentDate.AddDays(6).Year;
            text_mon.Content = "Lundi " + currentDate.Day + " " + GetMonth(currentDate) + " " + currentDate.Year;
            text_tue.Content = "Mardi " + currentDate.AddDays(1).Day + " " + GetMonth(currentDate.AddDays(1)) + " " + currentDate.AddDays(1).Year;
            text_wed.Content = "Mercredi " + currentDate.AddDays(2).Day + " " + GetMonth(currentDate.AddDays(2)) + " " + currentDate.AddDays(2).Year;
            text_thu.Content = "Jeudi " + currentDate.AddDays(3).Day + " " + GetMonth(currentDate.AddDays(3)) + " " + currentDate.AddDays(3).Year;
            text_fri.Content = "Vendredi " + currentDate.AddDays(4).Day + " " + GetMonth(currentDate.AddDays(4)) + " " + currentDate.AddDays(4).Year;
            text_sat.Content = "Samedi " + currentDate.AddDays(5).Day + " " + GetMonth(currentDate.AddDays(5)) + " " + currentDate.AddDays(5).Year;
            text_sun.Content = "Dimanche " + currentDate.AddDays(6).Day + " " + GetMonth(currentDate.AddDays(6)) + " " + currentDate.AddDays(6).Year;
        }

        private String GetMonth(DateTime date)
        {
            if (date.Month == 1) return "Janvier";
            if (date.Month == 2) return "Février";
            if (date.Month == 3) return "Mars";
            if (date.Month == 4) return "Avril";
            if (date.Month == 5) return "Mai";
            if (date.Month == 6) return "Juin";
            if (date.Month == 7) return "Juillet";
            if (date.Month == 8) return "Août";
            if (date.Month == 9) return "Septembre";
            if (date.Month == 10) return "Octobre";
            if (date.Month == 11) return "Novembre";
            if (date.Month == 12) return "Décembre";
            return null;
        }

        private void hideAll()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int heure = 8; heure < 20; heure++)
                {
                    changeContentCase(i, heure, "", "", "");
                }
            }
        }

        private void changeContentCase(int jours, int heure, String lesson, String prof, String room)
        {
            heure = heure - 7;
            jours = jours + 1;
            if (lesson != "")
            {
                ((Label)(RootGrid.FindName("name_" + jours + "_" + heure))).Content = lesson;
                ((Label)(RootGrid.FindName("name_" + jours + "_" + heure))).Background = Brushes.Gray;
            }
            else
            {
                ((Label)(RootGrid.FindName("name_" + jours + "_" + heure))).Content = lesson;
                ((Label)(RootGrid.FindName("name_" + jours + "_" + heure))).Background = Brushes.Transparent;
            }
            if (prof != "" || room != "")
            {
                ((Label)(RootGrid.FindName("desc_" + jours + "_" + heure))).Content = "M. " + prof + " - Salle " + room;
                ((Label)(RootGrid.FindName("desc_" + jours + "_" + heure))).Background = Brushes.Gray;
            }
            else
            {
                ((Label)(RootGrid.FindName("desc_" + jours + "_" + heure))).Content = "";
                ((Label)(RootGrid.FindName("desc_" + jours + "_" + heure))).Background = Brushes.Transparent;
            }
        }

        private void bt_back_Click(object sender, RoutedEventArgs e)
        {
            currentDate = DateTime.Today;
            while (currentDate.DayOfWeek.ToString() != "Monday") currentDate = currentDate.AddDays(-1);
            setTitles();
            changeCourses();
        }

        private void bt_prev_Click(object sender, RoutedEventArgs e)
        {
            currentDate = currentDate.AddDays(-7);
            setTitles();
            changeCourses();
        }

        private void bt_next_Click(object sender, RoutedEventArgs e)
        {
            currentDate = currentDate.AddDays(7);
            setTitles();
            changeCourses();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            parent.Show();
            base.OnClosing(e);
        }
    }
}
