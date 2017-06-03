using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatTaxiAgencijaMAN.forme;
using ProjekatTaxiAgencijaMAN.Pomocne;
using ProjekatTaxiAgencijaMAN.Modeli;
using Windows.UI.Popups;
using Microsoft.WindowsAzure.MobileServices;

namespace ProjekatTaxiAgencijaMAN.ViewModeli
{
    class RegistracijaMusterijeVM : INotifyPropertyChanged
    {        
        public ICommand Registracija { get; set; }
        public String ime { get; set; }
        public String prezime { get; set; }
        public String email { get; set; }
        public DateTime datum { get; set; }
        public String brojtelefona { get; set; }
        public String kime { get; set; }
        public String ksifra { get; set; }
        public String ksifraponovo { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Promjena(String s)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(s));
            }
        }

        public RegistracijaMusterijeVM()
        {
            Registracija = new RelayCommand<object>(registruj, provjeraregistracija);
        }

        public bool provjeraregistracija(object o)
        {
            return true;
        }

        public async void IspisiErrore(String errori)
        {
            var raz = new MessageDialog(errori);
            await raz.ShowAsync();
        }

        private bool provjeriJeLiBroj(String s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9') return false;
            }
            return true;
        }

        public void registruj(object o)
        {
            IMobileServiceTable<KlaseZaAzure.RegistrovaneMusterije> userTableObj = App.MobileService.GetTable<KlaseZaAzure.RegistrovaneMusterije>();
            IMobileServiceTable<KlaseZaAzure.Musterije> userTableMusterije = App.MobileService.GetTable<KlaseZaAzure.Musterije>();
            String errori = "";

            // ovdje se radi i validacija polja
            if(ime == null || ime == "")
            {
                errori += "Neispravno ime ";
            }
            if (prezime == null || prezime == "")
            {
                errori += "Neispravno prezime ";
            }
            if(datum==null || datum > DateTime.Now)
            {
                errori += "Neispravan datum ";
            }
            if (brojtelefona == null || brojtelefona == "")
            {
                errori += "Neispravan broj telefona ";
            }
            if(kime == null || kime == ""){
                errori += "Neispravno korisnicko ime ";
            }
            if(ksifra == null || ksifra == "")
            {
                errori += "Neispravna sifra ";
            }
            if(ksifraponovo == null || ksifraponovo == "" || ksifraponovo != ksifra)
            {
                errori += "Neispravna ponovno unesena sifra ";
            }
            if (!provjeriJeLiBroj(brojtelefona))
            {
                errori += "Broj telefona iskljucivo treba da sadrzi samo cifre";
            }

            // treba provjeriti je li vec postoji uneseno korisnicko ime
            // i treba validirati email

            bool postojiIme = false;

            var baza = new TaxiDbContext();

            foreach (var musterija in baza.musterije)
            {
                //error
                //if ((RegistrovanaMusterija)musterija.KorisnickoIme == kime) postojiIme = true;
            }

            if(postojiIme==true || errori != "")
            {
                // treba pozvati thread da ispise errore
                if (postojiIme == true)
                {
                    errori += "Ovo korisnicko ime vec postoji";
                }
                IspisiErrore(errori);
            }
            else
            {
                RegistrovanaMusterija regm = new RegistrovanaMusterija();
                regm.KorisnickoIme = kime;
                regm.Password = ksifra;
                regm.ImeKorisnika = ime;
                regm.PrezimeKorisnika = prezime;
                regm.EmailAdresa = email;
                regm.DatumRodjenja = datum;
                regm.BrojTelefona = brojtelefona;

                kime = "";
                ksifra = "";
                ksifraponovo = "";
                ime = "";
                prezime = "";
                email = "";
                datum = DateTime.Now;
                brojtelefona = "";

                Promjena("kime");
                Promjena("ksifra");
                Promjena("ksifraponovo");
                Promjena("ime");
                Promjena("prezime");
                Promjena("email");
                Promjena("datum");
                Promjena("brojtelefona");

                baza.musterije.Add(regm);
                baza.SaveChanges();

                try
                {
                    KlaseZaAzure.Musterije musterija = new KlaseZaAzure.Musterije();
                    KlaseZaAzure.RegistrovaneMusterije registrovanaMusterija = new KlaseZaAzure.RegistrovaneMusterije();
               

                    musterija.id = regm.Id.ToString();

                    userTableMusterije.InsertAsync(musterija);

                    registrovanaMusterija.id = regm.Id.ToString();
                    registrovanaMusterija.Ime = ime;
                    registrovanaMusterija.Prezime = prezime;
                    registrovanaMusterija.KorisnickoIme = kime;
                    registrovanaMusterija.Sifra = ksifra;
                    registrovanaMusterija.Email = email;
                    registrovanaMusterija.BrojTelefona = brojtelefona;
                    registrovanaMusterija.DatumRodjenja = datum;

                    userTableObj.InsertAsync(registrovanaMusterija);

                }
                catch (Exception e)
                {

                }
            }

        }
    }
}
