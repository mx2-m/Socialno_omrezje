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
    /// Interaction logic for DodajPrijatelja.xaml
    /// </summary>
    public partial class DodajPrijatelja : Window
    {
        public DodajPrijatelja()
        {
            InitializeComponent();
            //imep.Text = ime;
           

        }

        public string ime, about1, spol1, datumpr,rd;

        public string rd1
        {
            get
            {
                return rd;
            }
        }



        public string ime1
        {
            get
            {
                return ime;
            }
        }
        public string about
        {
            get
            {
                return about1;
            }
        }
        public string spolp
        {
            get
            {
                return spol1;
            }
        }
        public string datumP
        {
            get
            {
                return datumpr;
            }
        }

        /*  private void btnDialogOk_Click(object sender, RoutedEventArgs e)
          {
              this.DialogResult = true;
              DodajObjavu dod = new DodajObjavu(imep.Text);

          }


          private void Window_ContentRendered(object sender, EventArgs e)
          {
              imep.SelectAll();
              imep.Focus();
              //about.SelectAll();
              //about.Focus();

          }

          public string Answer
          {
              get { return imep.Text+"\t"+ "\t"+spol.Text; }
          }
          */



        /* private void About_GotFocus(object sender, RoutedEventArgs e)
         {
             about.Text = string.Empty;
         }*/



        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (imep.Text == string.Empty || spol1 == string.Empty
                || imep.Text == "ime i priimek" || spol.Text == "spol" )
            {
                MessageBox.Show("Nepravilen vnos podatkov!");
            }
            else
            {
                ime = imep.Text;
                rd = datumPrijatelj.Text;
                spol1 = spol.Text;
                about1 = vsebina.Text;
                //datumpr = datumPrijatelj.Text;
                
            }
            this.Hide();
        }

        private void Preklici_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }



    }
    }
