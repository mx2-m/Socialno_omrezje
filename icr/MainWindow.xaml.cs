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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Xml.Serialization;
using Microsoft.Win32;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace icr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UserStruktura userStruktura = new UserStruktura();
        public ObservableCollection<UserStruktura> userStrukturaKolekcija = new ObservableCollection<UserStruktura>();
        StringAnimationUsingKeyFrames frames = new StringAnimationUsingKeyFrames();
        Storyboard story = new Storyboard();

        public MainWindow()
        {
            InitializeComponent();
            /*  User user = new User();
              user.UserIme = ime.Text;
              user.UserPriimek = priimek.Text;
              user.UserHighS = highschool.Text;
              user.UserCollege = college.Text;
              user.UserVsebina = aboutme.Text;
              user.UserSpol = spol.Text;
              userStruktura.User = user;
              userStrukturaKolekcija.Add(userStruktura);*/

            XmlSerializer deserializer = new XmlSerializer(typeof(UserStruktura));
            TextReader tr = new StreamReader("ok.xml");
            userStruktura = (UserStruktura)deserializer.Deserialize(tr);
            tr.Close();
            userStrukturaKolekcija.Add(userStruktura);

            Objava.Items.Clear();
            Objava.ItemsSource = userStruktura.Objave;

            slike.Items.Clear();
            slike.ItemsSource = userStruktura.Objave;

            List.Items.Clear();
            List.ItemsSource = userStruktura.Prijatelji;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List.ItemsSource);
            view.Filter = UserFilter;

            this.DataContext = userStruktura.User;

            DispatcherTimer dt = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(10) };
            dt.Tick += AutoSave;
            dt.Start();

        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as Prijatelj).PrijateljIme.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(List.ItemsSource).Refresh();
        }






        private async void AutoSave(object sender, EventArgs e)
        {
            SaveState();
            //MessageBox.Show("Saved: " + DateTime.Now.ToShortTimeString());
            ((DispatcherTimer)sender).Interval = TimeSpan.FromSeconds(10);
            await Task.Delay(2000);
        }

        private void SaveState()
        {
            Properties.Settings.Default.Save();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //private void MenuItem_Click2(object sender, RoutedEventArgs e)
        //{
        //    DodajObjavu dodaj = new DodajObjavu(" ");
        //    if (dodaj.ShowDialog() == true)

        //        zid.Items.Add(dodaj.Objava);


        //}

        private void MenuItem_Objavi_Click(object sender, RoutedEventArgs e)
        {
            DodajObjavu objavi = new DodajObjavu();
            objavi.ShowDialog();

            Objava nova = new Objava();
            nova.ObjavaUser = "Minela";
            nova.ObjavaSlika = objavi.path;
            nova.ObjavaVsebina = objavi.vsebinaObjave;
            nova.ObjavaLokacija = objavi.Lokacija;
            nova.ObjavaZasebnost = objavi.Zasebnost;
            nova.ObjavaEmotikoni = objavi.emotikon;
            nova.ObjavaPrijatelji = objavi.Prijatelji;

            if (nova.ObjavaVsebina != string.Empty)
            {
                userStruktura.Objave.Add(nova);
                userStrukturaKolekcija.Add(userStruktura);
            }

            StringAnimationUsingKeyFrames strani = new StringAnimationUsingKeyFrames();
            strani.Duration = new Duration(new TimeSpan(0, 0, 9));
            strani.FillBehavior = FillBehavior.HoldEnd;
            strani.KeyFrames.Add(new DiscreteStringKeyFrame("O", TimeSpan.FromSeconds(1)));
            strani.KeyFrames.Add(new DiscreteStringKeyFrame("Ob", TimeSpan.FromSeconds(2)));
            strani.KeyFrames.Add(new DiscreteStringKeyFrame("Obj", TimeSpan.FromSeconds(3)));
            strani.KeyFrames.Add(new DiscreteStringKeyFrame("Obja", TimeSpan.FromSeconds(4)));
            strani.KeyFrames.Add(new DiscreteStringKeyFrame("Objav", TimeSpan.FromSeconds(6)));
            strani.KeyFrames.Add(new DiscreteStringKeyFrame("Objavlj", TimeSpan.FromSeconds(7)));
            strani.KeyFrames.Add(new DiscreteStringKeyFrame("Objavljeno", TimeSpan.FromSeconds(8)));
            
            Storyboard.SetTargetName(frames, lbl.Name);
            Storyboard.SetTargetProperty(frames, new PropertyPath(Label.ContentProperty));
            story.Children.Add(frames);

        }

        /*  private void button5_Click(object sender, RoutedEventArgs e)

           {
               DodajPrijatelja dodaj = new DodajPrijatelja();

               if (dodaj.ShowDialog() == true)

               List.Items.Add(dodaj.Answer);


           }*/


        private void klik(object sender, RoutedEventArgs e)

        {

            ICollectionView view = CollectionViewSource.GetDefaultView(userStruktura.Prijatelji);


            if (ComboBox.SelectedIndex == 0)
            {
                view.SortDescriptions.Add(new SortDescription("PrijateljIme", ListSortDirection.Ascending));
            }
            else
            {
                view.SortDescriptions.Add(new SortDescription("PrijateljIme", ListSortDirection.Descending));
            }

        }


        public string Lista
        {
            get { return List.Items.ToString(); }
        }


        private void btnUredi_Click(object sender, RoutedEventArgs e)
        {
            Profil uporabnik = new Profil();
            uporabnik.ShowDialog();
            ime.Text = uporabnik.ime;
            priimek.Text = uporabnik.priimek;
            spol.Text = "Spol " + uporabnik.spol;
            highschool.Text = uporabnik.h;
            college.Text = uporabnik.college1;
            aboutme.Text = uporabnik.about1;




            // doda user u xml fajl
            User user = new User();
            user.UserIme = uporabnik.ime;
            user.UserPriimek = uporabnik.priimek;
            user.UserHighS = uporabnik.h;
            user.UserCollege = uporabnik.college1;
            user.UserSpol = uporabnik.spol1;
            userStruktura.User = user;
            userStrukturaKolekcija.Add(userStruktura);




        }







        private void Uvezi_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "XML Files (*.xml)|*.xml"
            };
            if (ofd.ShowDialog() == true)
            {
                if (userStrukturaKolekcija.Count > 0)
                {
                    userStrukturaKolekcija.Clear();
                    userStruktura = null;
                }
                XmlSerializer deserializer = new XmlSerializer(typeof(UserStruktura));
                TextReader tr = new StreamReader(ofd.FileName);
                userStruktura = (UserStruktura)deserializer.Deserialize(tr);
                tr.Close();
                userStrukturaKolekcija.Add(userStruktura);

                Objava.ItemsSource = userStruktura.Objave;
                List.ItemsSource = userStruktura.Prijatelji;

                this.DataContext = userStruktura.User;
            }
        }

        private void Izvezi_Click(object sender, RoutedEventArgs e)
        {
            if (userStrukturaKolekcija.Count != 0)
            {
                SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "XML Files (*.xml)|*.xml"
                };
                if (sfd.ShowDialog() == true)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(UserStruktura));
                    TextWriter tw = new StreamWriter(sfd.FileName);
                    serializer.Serialize(tw, userStruktura);

                    tw.Close();
                }
            }
            userStrukturaKolekcija.Clear();
           
        }

        private void Button_Dodaj(object sender, RoutedEventArgs e)
        {
            DodajPrijatelja dp = new DodajPrijatelja();
            dp.ShowDialog();
            Prijatelj novi = new Prijatelj();
            novi.PrijateljIme = dp.imep.Text;
            novi.PrijateljSpol = dp.spol.Text;
            novi.About = dp.vsebina.Text;
            novi.RD = dp.rd;
            if (novi != null)
            {
                userStruktura.Prijatelji.Add(novi);
                userStrukturaKolekcija.Add(userStruktura);
            }
        }

        private void Button_Odstrani(object sender, RoutedEventArgs e)
        {
            while (List.SelectedItems.Count > 0)
            {
                userStruktura.Prijatelji.RemoveAt(List.SelectedIndex);
            }

           
        }






      /*  private void brisanje(object sender, RoutedEventArgs e)
        {
            while (objavel.SelectedItems.Count > 0)
            {
                userStruktura.Prijatelji.RemoveAt(objavel.SelectedIndex);
            }
        }*/

        private void uredi(object sender, RoutedEventArgs e)
        {
            DodajObjavu objavi = new DodajObjavu();
            objavi.ShowDialog();

            Objava nova = new Objava();
            nova.ObjavaUser = "Minela";
            nova.ObjavaSlika = objavi.path;
            nova.ObjavaVsebina = objavi.vsebinaObjave;
            nova.ObjavaLokacija = objavi.Lokacija;
            nova.ObjavaZasebnost = objavi.Zasebnost;
            nova.ObjavaEmotikoni = objavi.emotikon;
            nova.ObjavaPrijatelji = objavi.Prijatelji;
            

            if (nova.ObjavaVsebina != string.Empty)
            {
                userStruktura.Objave.Add(nova);
                userStrukturaKolekcija.Add(userStruktura);
            }

        }

    }

}

