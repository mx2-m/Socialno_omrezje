using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace icr
{
    /// <summary>
    /// Interaction logic for Profil.xaml
    /// </summary>
    public partial class Profil : Window
    {
        public Profil()
        {
            InitializeComponent();
            MainWindow mw = new MainWindow();
            imep.Text = mw.ime.Text;
            primek.Text = mw.priimek.Text;
            spol.Text = mw.spol.Text;
            highs.Text = mw.highschool.Text;
            college.Text = mw.college.Text;
            about.Text = mw.aboutme.Text;

        }

        public string ime, priimek, spol1, h, college1, about1;

        public string Ime{get{return ime;}}
        public string Priimek{get{return priimek;}}
        public string Spol{get{return spol1;}}
        public string College{get{return college1;}}
        public string About {get{return about1;}}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ime = imep.Text;
            priimek = primek.Text;
            spol1 = spol.Text;
            h= highs.Text;
            college1 = college.Text;
            about1 = about.Text;
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}

