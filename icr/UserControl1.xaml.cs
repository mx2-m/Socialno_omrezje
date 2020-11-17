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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.ComponentModel;
using Microsoft.Win32;


namespace icr
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserStruktura userStruktura = new UserStruktura();
        public ObservableCollection<UserStruktura> userStrukturaKolekcija = new ObservableCollection<UserStruktura>();
        //StringAnimationUsingKeyFrames frames = new StringAnimationUsingKeyFrames();
        //Storyboard story = new Storyboard();

        public UserControl1()
        {
            InitializeComponent();
           
        }

        private void Odstrani(object sender, RoutedEventArgs e)
        {
            while (list.SelectedItems.Count > 0)
            {
                //userStruktura.Objave.RemoveAt(list.SelectedIndex);
                list.Items.RemoveAt(list.SelectedIndex);
            }
        }

        private void Uredi(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItems.Count > 0)
            {
                DodajObjavu objavi = new DodajObjavu();
                objavi.ShowDialog();

               
                

                list.Items.Clear();
               
                list.Items.Add(objavi.dodaj);
               

            }
            
        }
    }
}
