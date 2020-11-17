using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml.Serialization;


namespace icr
{
    [Serializable]
    public class UserStruktura : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private User uporabnik;
        private ObservableCollection<Objava> objava;
        //private Objava objava;
        private ObservableCollection<Prijatelj> prijatelji;

        [XmlElement("User")]
        public User User{get{ return uporabnik;}set{uporabnik = value;}}

        [XmlArray("Objave")]
        [XmlArrayItem("Objava")]
        public ObservableCollection<Objava> Objave {get{return objava;}set{objava = value;}}

        [XmlArray("Prijatelji")]
        [XmlArrayItem("Prijatelj")]
        public ObservableCollection<Prijatelj> Prijatelji{get{return prijatelji;}set{ prijatelji = value;}}

        public void OnPropertyChanged(PropertyChangedEventArgs e){PropertyChanged?.Invoke(this, e);}}
}

public class User : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    private string userIme, userPriimek, userHighS, userCollege, userVsebina, userSpol;

    public string UserIme
    {
        get
        {
            return userIme;
        }
        set
        {
            userIme = value;
            OnPropertyChanged(new PropertyChangedEventArgs(""));
        }
    }

    public string UserPriimek
    {
        get
        {
            return userPriimek;
        }
        set
        {
            userPriimek = value;
            OnPropertyChanged(new PropertyChangedEventArgs(""));
        }
    }

    
    public string UserHighS
    {
        get
        {
            return userHighS;
        }
        set
        {
            userHighS = value;
            OnPropertyChanged(new PropertyChangedEventArgs(""));
        }
    }

    public string UserCollege
    {
        get
        {
            return userCollege;
        }
        set
        {
            userCollege = value;
            OnPropertyChanged(new PropertyChangedEventArgs(""));
        }
    }

    public string UserVsebina
    {
        get
        {
            return userVsebina;
        }
        set
        {
            userVsebina = value;
            OnPropertyChanged(new PropertyChangedEventArgs(""));
        }
    }

   

    public string UserSpol
    {
        get
        {
            return userSpol;
        }
        set
        {
            userSpol = value;
            OnPropertyChanged(new PropertyChangedEventArgs(""));
        }
    }

    public void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        PropertyChanged?.Invoke(this, e);
    }
}

public class Objava : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    private string objavaUser, objavaSlika, objavaVsebina,objavaPrijatelji,objavaLokacija,objavaZasebnost, objavaEmotikoni;

    public Objava()
    {
        this.objavaUser = ObjavaUser;
        this.objavaSlika = ObjavaSlika;
        this.objavaVsebina = ObjavaVsebina;
        this.objavaPrijatelji = ObjavaPrijatelji;
        this.objavaLokacija = ObjavaLokacija;
        this.objavaZasebnost = ObjavaZasebnost;
        this.objavaEmotikoni = ObjavaEmotikoni;
    }
    public string ObjavaEmotikoni
    {
        get
        {
            return objavaEmotikoni;
        }
        set
        {
            objavaEmotikoni = value;
            OnPropertyChanged(new PropertyChangedEventArgs(""));
        }
    }

    public string ObjavaZasebnost
    {
        get
        {
            return objavaZasebnost;
        }
        set
        {
            objavaZasebnost = value;
            OnPropertyChanged(new PropertyChangedEventArgs(""));
        }
    }

    public string ObjavaLokacija
    {
        get
        {
            return objavaLokacija;
        }
        set
        {
            objavaLokacija = value;
            OnPropertyChanged(new PropertyChangedEventArgs(""));
        }
    }


    public string ObjavaPrijatelji
    {
        get
        {
            return objavaPrijatelji;
        }
        set
        {
            objavaPrijatelji = value;
            OnPropertyChanged(new PropertyChangedEventArgs(""));
        }
    }




    public string ObjavaUser
    {
        get
        {
            return objavaUser;
        }
        set
        {
            objavaUser = value;
            OnPropertyChanged(new PropertyChangedEventArgs(""));
        }
    }
    public string ObjavaSlika
    {
        get
        {
            return objavaSlika;
        }
        set
        {
            objavaSlika = value;
            OnPropertyChanged(new PropertyChangedEventArgs(""));
        }
    }
    public string ObjavaVsebina
    {
        get
        {
            return
                objavaVsebina;
        }
        set
        {
            objavaVsebina = value;
            OnPropertyChanged(new PropertyChangedEventArgs(""));
        }
    }
    public void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        PropertyChanged?.Invoke(this, e);
    }
}

public class Prijatelj : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    private string prijateljIme, prijateljSpol,about,stopnja1,stopnja2,stopnja3,rd;

    public Prijatelj()
    {
        this.prijateljIme = PrijateljIme;
      
        this.prijateljSpol = PrijateljSpol;
        this.about = About;
        this.rd = RD;
    }

    public string RD
    {
        get
        {
            return rd;
        }
        set
        {
            rd = value;
            OnPropertyChanged(new PropertyChangedEventArgs(""));
        }
    }



    public string PrijateljIme
    {
        get
        {
            return prijateljIme;
        }
        set
        {
            prijateljIme = value;
            OnPropertyChanged(new PropertyChangedEventArgs(""));
        }
    }
    

    public string About
    {
        get
        {
            return about;
        }
        set
        {
            about= value;
            OnPropertyChanged(new PropertyChangedEventArgs(""));
        }
    }
    public string PrijateljSpol
    {
        get
        {
            return
                prijateljSpol;
        }
        set
        {
            prijateljSpol = value;
            OnPropertyChanged(new PropertyChangedEventArgs(""));
        }
    }

    public string Stopnja1
    {
        get
        {
            return
                stopnja1;
        }
        set
        {
            stopnja1 = value;
            OnPropertyChanged(new PropertyChangedEventArgs(""));
        }
    }

    public string Stopnja2
    {
        get
        {
            return
                stopnja2;
        }
        set
        {
            stopnja2 = value;
            OnPropertyChanged(new PropertyChangedEventArgs(""));
        }
    }

    public string Stopnja3
    {
        get
        {
            return
                stopnja3;
        }
        set
        {
            stopnja3 = value;
            OnPropertyChanged(new PropertyChangedEventArgs(""));
        }
    }


    public void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        PropertyChanged?.Invoke(this, e);
    }

}