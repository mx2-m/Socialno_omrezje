using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Serialization;
using Microsoft.Win32;

namespace icr
{
    /// <summary>
    /// Interaction logic for DodajObjavu.xaml
    /// </summary>
    public partial class DodajObjavu : Window
    {

        public UserStruktura userStruktura = new UserStruktura();
        public ObservableCollection<UserStruktura> userStrukturaKolekcija = new ObservableCollection<UserStruktura>();

        public DodajObjavu()
        {
            
            InitializeComponent();
            XmlSerializer deserializer = new XmlSerializer(typeof(UserStruktura));
            TextReader tr = new StreamReader("ok.xml");
            userStruktura = (UserStruktura)deserializer.Deserialize(tr);
            tr.Close();
            userStrukturaKolekcija.Add(userStruktura);
            friend.Items.Clear();
            friend.ItemsSource = userStruktura.Prijatelji;
            //prijatelji.Text = l;
        }

        public string vsebina;
        public string vsebinaObjave
        {
            get
            {
                return vsebina;
            }
        }
        public string tbUsername;
        public string username
        {
            get
            {
                return tbUsername;
            }
        }
        public string path1;
        public string path
        {
            get
            {
                return path1;
            }
        }

        public string emotikon1;
        public string emotikon
        {
            get
            {
                return emotikon1;
            }
        }

        public string lokacija1;
        public string Lokacija
        {
            get
            {
                return lokacija1;
            }
        }

        public string prijatelji1;
        public string Prijatelji
        {
            get
            {
                return prijatelji1;
            }
        }

        public string zasebnost;
        public string Zasebnost
        {
            get
            {
                return zasebnost;
            }
        }

        private void btnDialogOk_Click1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            vsebina = new TextRange(objava.Document.ContentStart, objava.Document.ContentEnd).Text;
            lokacija1 = location.Text;
            zasebnost = stopnja.Text;
           
            prijatelji1 = friend.Text;


        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                //imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
                path1 = op.FileName;
            }
            else
            {
                path1 = string.Empty;
            }

        }


       /* private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            // ... A List.
            List<string> data = new List<string>();
            data.Add(friend.Text);


            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // ... Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;

            // ... Make the first item selected.
            comboBox.SelectedIndex = 0;
        }*/

        


        public string dodaj
        {
           

            get
            {
                
                return vsebina.ToString() + "\t" + path1 + "\t" + location.Text + "\t" +friend.Text
                    + "\t"+stopnja.Text + "\t" +emotikoni.ToString()
                    ; }
        }







    }
}
