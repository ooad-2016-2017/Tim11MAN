﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Windows.UI.Popups;
using ProjekatTaxiAgencijaMAN.Pomocne;
using ProjekatTaxiAgencijaMAN.Modeli;

namespace ProjekatTaxiAgencijaMAN.ViewModeli
{
    class RegistracijaKompanijeVM
    {
        ICommand RegistracijaKompanije;
        public String imeKompanije { get; set; }
        public String emailKompanije { get; set; }
        public DateTime datumKompanije { get; set; }
        public String brojTelefonaKompanije { get; set; }
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

        public RegistracijaKompanijeVM()
        {
            RegistracijaKompanije = new RelayCommand<object>(registruj, provjeraregistracija);
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
            String errori = "";
            // ovdje se radi i validacija polja
            if (imeKompanije == null || imeKompanije == "")
            {
                errori += "Neispravno ime ";
            }
            if (datumKompanije == null || datumKompanije > DateTime.Now)
            {
                errori += "Neispravan datum ";
            }
            if (brojTelefonaKompanije == null || brojTelefonaKompanije == "")
            {
                errori += "Neispravan broj telefona ";
            }
            if (kime == null || kime == "")
            {
                errori += "Neispravno korisnicko ime ";
            }
            if (ksifra == null || ksifra == "")
            {
                errori += "Neispravna sifra ";
            }
            if (ksifraponovo == null || ksifraponovo == "" || ksifraponovo != ksifra)
            {
                errori += "Neispravna ponovno unesena sifra ";
            }
            if (!provjeriJeLiBroj(brojTelefonaKompanije))
            {
                errori += "Broj telefona iskljucivo treba da sadrzi samo cifre";
            }

            // treba provjeriti je li vec postoji uneseno korisnicko ime
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
                Kompanija regm = new Kompanija();
                regm.KorisnickoIme = kime;
                regm.Sifra = ksifra;
                regm.NazivKompanije = imeKompanije;
                regm.EmailKompanije = emailKompanije;
                regm.DatumOsnivanja = datumKompanije;
                regm.BrojTelefona = Convert.ToInt32(brojTelefonaKompanije);

                kime = "";
                ksifra = "";
                imeKompanije = "";
                emailKompanije = "";
                datumKompanije = DateTime.Now;
                brojTelefonaKompanije = "";

                Promjena("Vracanje na fabricke postavke");

                // sad ga samo treba dodat u bazu ovdje
            }

        }
    }
}
