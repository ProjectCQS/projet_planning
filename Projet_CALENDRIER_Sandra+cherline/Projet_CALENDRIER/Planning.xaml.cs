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
        private Window parent;

        public Planning(Window p)
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

            hideAll();
            changeContentCase(2, 8, "Maths", "Mr. LIBERT", "Salle 12");
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
            for (int i = 1; i < 8; i++)
            {
                for (int j = 1; j < 13; j++)
                {
                    changeContentCase(i, j, "", "", "");
                }
            }
        }

        private void changeContentCase(int i, int j, String lesson, String prof, String room)
        {
            if (lesson != "")
            {
                ((Label)(RootGrid.FindName("name_" + i + "_" + j))).Content = lesson;
                ((Label)(RootGrid.FindName("name_" + i + "_" + j))).Background = Brushes.Gray;
            }
            else
            {
                ((Label)(RootGrid.FindName("name_" + i + "_" + j))).Content = lesson;
                ((Label)(RootGrid.FindName("name_" + i + "_" + j))).Background = Brushes.Transparent;
            }
            if (prof != "" || room != "")
            {
                ((Label)(RootGrid.FindName("desc_" + i + "_" + j))).Content = prof + " - " + room;
                ((Label)(RootGrid.FindName("desc_" + i + "_" + j))).Background = Brushes.Gray;
            }
            else
            {
                ((Label)(RootGrid.FindName("desc_" + i + "_" + j))).Content = "";
                ((Label)(RootGrid.FindName("desc_" + i + "_" + j))).Background = Brushes.Transparent;
            }
        }

        private void bt_back_Click(object sender, RoutedEventArgs e)
        {
            currentDate = DateTime.Today;
            while (currentDate.DayOfWeek.ToString() != "Monday") currentDate = currentDate.AddDays(-1);
            setTitles();
        }

        private void bt_prev_Click(object sender, RoutedEventArgs e)
        {
            currentDate = currentDate.AddDays(-7);
            setTitles();
        }

        private void bt_next_Click(object sender, RoutedEventArgs e)
        {
            currentDate = currentDate.AddDays(7);
            setTitles();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            parent.Show();
            base.OnClosing(e);
        }
    }
}
