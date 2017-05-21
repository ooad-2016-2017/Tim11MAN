using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatTaxiAgencijaMAN.Modeli;
using ProjekatTaxiAgencijaMAN.forme;
using Windows.UI.Popups;
using System.ComponentModel;
using System.Windows.Input;
using ProjekatTaxiAgencijaMAN.Pomocne;

namespace ProjekatTaxiAgencijaMAN.ViewModeli
{
    class RegistracijaDispeceraIliSupervizora : INotifyPropertyChanged
    {
        public ICommand RegistrujDS { get; set; }
        public string kime { get; set; }
        public string ksifra { get; set; }
        public string ksifraponovo { get; set; }
        public String imeDS { get; set; }
        public String prezimeDS { get; set; }
        public DateTime datumDS { get; set; }
        public DateTime datumZDS{ get; set; }
        public String brojTelefonaDS { get; set; }
        public bool supervizorDS { get; set; }
        public bool dispecerDS { get; set; }

        private bool provjeriJeLiBroj(String s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9') return false;
            }
            return true;
        }

        public RegistracijaDispeceraIliSupervizora()
        {
            RegistrujDS = new RelayCommand<object>(Registruj, provjeraRegistracije);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Promjena(String s)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(s));
            }
        }

        public bool provjeraRegistracije(object o)
        {
            return true;
        }

        public async void IspisiErrore(String errori)
        {
            var raz = new MessageDialog(errori);
            await raz.ShowAsync();
        }

        public void Registruj(object o)
        {
            String errori = "";
            // ovdje se radi i validacija polja
            if (imeDS == null || imeDS == "")
            {
                errori += "Neispravno ime ";
            }
            if (prezimeDS == null || prezimeDS == "")
            {
                errori += "Neispravno prezime ";
            }
            if (datumDS == null || datumDS > DateTime.Now)
            {
                errori += "Neispravan datum ";
            }
            if (datumZDS == null || datumZDS > DateTime.Now)
            {
                errori += "Neispravan datum ";
            }
            if (brojTelefonaDS == null || brojTelefonaDS == "")
            {
                errori += "Neispravan broj telefona ";
            }
            if (!provjeriJeLiBroj(brojTelefonaDS))
            {
                errori += "Broj telefona iskljucivo treba da sadrzi samo cifre";
            }

            // treba provjeriti da li postoji ova registracija vozila vec u bazi

            var baza = new TaxiDbContext();
            bool postojiIme = false;

            foreach (var zaposlenik in baza.zaposlenici)
            {
                if (zaposlenik.KorisnickoIme == kime) postojiIme = true;
            }

            // i treba validirati email
            

            if (postojiIme == true || errori != "")
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
                Zaposlenik regm;
                if (supervizorDS)
                {
                    regm = new Supervizor();
                    regm.Ime = imeDS;
                    regm.KorisnickoIme = kime;
                    regm.Password = ksifra;
                    regm.Prezime = prezimeDS;
                    regm.DatumRodjenja = datumDS;
                    regm.DatumZaposlenja = datumDS;
                    regm.BrojTelefona = brojTelefonaDS;
                }
                else if (dispecerDS)
                {
                    regm = new ProjekatTaxiAgencijaMAN.Modeli.Dispecer();
                    regm.Ime = imeDS;
                    regm.KorisnickoIme = kime;
                    regm.Password = ksifra;
                    regm.Prezime = prezimeDS;
                    regm.DatumRodjenja = datumDS;
                    regm.DatumZaposlenja = datumDS;
                    regm.BrojTelefona = brojTelefonaDS;
                }

                kime = "";
                ksifra = "";
                ksifraponovo = "";
                imeDS = "";
                prezimeDS = "";
                datumDS = DateTime.Now;
                datumZDS = DateTime.Now;
                brojTelefonaDS = "";

                Promjena("kime");
                Promjena("ksifra");
                Promjena("ksifraponovo");
                Promjena("imeDS");
                Promjena("prezimeDS");
                Promjena("datumDS");
                Promjena("datumZDS");
                Promjena("brojTelefonaDS");

                // sad ga samo treba dodat u bazu ovdje
            }
        }
    }
}
