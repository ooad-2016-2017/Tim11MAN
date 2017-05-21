using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Input;
using ProjekatTaxiAgencijaMAN.Pomocne;
using System.ComponentModel;
using ProjekatTaxiAgencijaMAN.forme;
using ProjekatTaxiAgencijaMAN.Modeli;
using Windows.UI.Popups;

namespace ProjekatTaxiAgencijaMAN.ViewModeli
{
    class RegistracijaVozacaVM : INotifyPropertyChanged
    {
        public ICommand RegistracijaVozaca { get; set; }
        GlavnaKompanijeVM kompanija;
        public String imeVozaca { get; set; }
        public String prezimeVozaca { get; set; }
        public DateTime datumVozaca { get; set; }
        public DateTime datumZVozaca { get; set; }
        public String brojTelefonaVozaca { get; set; }

        public String modelVozila { get; set; }
        public String godisteVozila { get; set; }
        public String registracijaVozila { get; set; }

        private bool provjeriJeLiBroj(String s)
        {
            for(int i=0; i<s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9') return false;
            }
            return true;
        }

        public RegistracijaVozacaVM(GlavnaKompanijeVM kompanija)
        {
            this.kompanija = kompanija;
            RegistracijaVozaca = new RelayCommand<object>(Registruj, provjeraRegistracije);
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
            if(registracijaVozila==null || registracijaVozila == "")
            {
                errori += "Neispravna registracija vozila ";
            }
            if(modelVozila==null || modelVozila == "")
            {
                errori += "Neispravan model vozila ";
            }
            if(godisteVozila==null || godisteVozila == "")
            {
                errori += "Neispravno godište vozila ";
            }
            if (!provjeriJeLiBroj(brojTelefonaVozaca))
            {
                errori += "Broj telefona iskljucivo treba da sadrzi samo cifre";
            }
            if (!provjeriJeLiBroj(godisteVozila))
            {
                errori += "Godiste vozila iskljucivo treba da sadrzi samo cifre";
            }

            // treba provjeriti da li postoji ova registracija vozila vec u bazi
            // i treba validirati email
            bool postojiIme = false;

            var baza = new TaxiDbContext();

            foreach (var vozilo in baza.vozila)
            {
                if (vozilo.RegistracijskeTablice == registracijaVozila) postojiIme = true;
            }

            if (postojiIme == true || errori != "")
            {
                // treba pozvati thread da ispise errore
                if (postojiIme == true)
                {
                    errori += "Ova registracija vec postoji ";
                }
                IspisiErrore(errori);
            }
            else
            {
                Zaposlenik regm = new Vozac();
                regm.Ime = imeVozaca;
                regm.Prezime = prezimeVozaca;
                regm.DatumRodjenja = datumVozaca;
                regm.DatumZaposlenja = datumVozaca;
                regm.BrojTelefona = brojTelefonaVozaca;

                Vozilo v = new Vozilo();
                v.GodisteVozila = Convert.ToInt32(godisteVozila);
                v.VrstaVozila = modelVozila;
                v.RegistracijskeTablice = registracijaVozila;

                Vozac v1 = (Vozac)regm;
                v1.Vozilo = v;

                regm = v1;

                baza.zaposlenici.Add(regm);
                baza.vozaci.Add(v1);
                baza.vozila.Add(v);

                imeVozaca = "";
                prezimeVozaca = "";
                datumVozaca = DateTime.Now;
                datumZVozaca = DateTime.Now;
                brojTelefonaVozaca = "";
                modelVozila = "";
                godisteVozila = "";
                registracijaVozila = "";

                Promjena("imeVozaca");
                Promjena("prezimeVozaca");
                Promjena("datumVozaca");
                Promjena("datumZVozaca");
                Promjena("brojTelefonaVozaca");
                Promjena("modelVozila");
                Promjena("godisteVozila");
                Promjena("registracijaVozila");
            }
        }
    }
}
