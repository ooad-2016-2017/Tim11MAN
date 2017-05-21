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
        public String imeVozaca { get; set; }
        public String prezimeVozaca { get; set; }
        public DateTime datumVozaca { get; set; }
        public DateTime datumZVozaca { get; set; }
        public String brojTelefonaVozaca { get; set; }
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
            if (imeVozaca == null || imeVozaca == "")
            {
                errori += "Neispravno ime ";
            }
            if (prezimeVozaca == null || prezimeVozaca == "")
            {
                errori += "Neispravno prezime ";
            }
            if (datumVozaca == null || datumVozaca > DateTime.Now)
            {
                errori += "Neispravan datum ";
            }
            if (datumZVozaca == null || datumZVozaca > DateTime.Now)
            {
                errori += "Neispravan datum ";
            }
            if (brojTelefonaVozaca == null || brojTelefonaVozaca == "")
            {
                errori += "Neispravan broj telefona ";
            }
            if (!provjeriJeLiBroj(brojTelefonaVozaca))
            {
                errori += "Broj telefona iskljucivo treba da sadrzi samo cifre";
            }

            // treba provjeriti da li postoji ova registracija vozila vec u bazi
            // i treba validirati email
            bool postojiIme = false;

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
                    regm.Ime = imeVozaca;
                    regm.Prezime = prezimeVozaca;
                    regm.DatumRodjenja = datumVozaca;
                    regm.DatumZaposlenja = datumVozaca;
                    regm.BrojTelefona = brojTelefonaVozaca;
                }
                else if (dispecerDS)
                {
                    regm = new ProjekatTaxiAgencijaMAN.Modeli.Dispecer();
                    regm.Ime = imeVozaca;
                    regm.Prezime = prezimeVozaca;
                    regm.DatumRodjenja = datumVozaca;
                    regm.DatumZaposlenja = datumVozaca;
                    regm.BrojTelefona = brojTelefonaVozaca;
                }

                imeVozaca = "";
                prezimeVozaca = "";
                datumVozaca = DateTime.Now;
                datumZVozaca = DateTime.Now;
                brojTelefonaVozaca = "";

                Promjena("Vracanje na fabricke postavke");

                // sad ga samo treba dodat u bazu ovdje
            }
        }
    }
}
