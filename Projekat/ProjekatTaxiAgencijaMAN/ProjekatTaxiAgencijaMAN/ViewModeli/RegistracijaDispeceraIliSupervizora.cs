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
using Microsoft.WindowsAzure.MobileServices;

namespace ProjekatTaxiAgencijaMAN.ViewModeli
{
    class RegistracijaDispeceraIliSupervizora : INotifyPropertyChanged
    {
        DPodaci podaci;
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

        public RegistracijaDispeceraIliSupervizora(GlavnaSupervizoraVM gsvm)
        {
            podaci = gsvm.podaci;
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
            IMobileServiceTable<KlaseZaAzure.Dispeceri> userTableDispeceri = App.MobileService.GetTable<KlaseZaAzure.Dispeceri>();
            IMobileServiceTable<KlaseZaAzure.Supervizori> userTableSupervizori = App.MobileService.GetTable<KlaseZaAzure.Supervizori>();
            IMobileServiceTable<KlaseZaAzure.Zaposlenik> userTableZaposlenik = App.MobileService.GetTable<KlaseZaAzure.Zaposlenik>();
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

            if (false)
            {
                foreach (var zaposlenik in baza.zaposlenici)
                {
                    if (zaposlenik.KorisnickoIme == kime) postojiIme = true;
                }
            }
            // i treba validirati email



            // TREBA PROCITATI SA AZURE I PROVJERITI DA LI POSTOJI OVO KORISNICKO IME
            

            // OVO JE ZA LOKALNU BAZU UNUTAR APP

            foreach(Zaposlenik z in podaci.zaposlenici)
            {
                if(!(z is Vozac))
                {
                    if (z.KorisnickoIme == kime) postojiIme = true;
                }
            }


            if (postojiIme == true || errori != "")
            {
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
                    baza.zaposlenici.Add(regm);
                    baza.SaveChanges();

                    try
                    {
                        KlaseZaAzure.Zaposlenik zaposlenik = new KlaseZaAzure.Zaposlenik();

                        zaposlenik.id = regm.ZaposlenikId.ToString();
                        zaposlenik.KorisnickoIme = kime;
                        zaposlenik.Prezime = prezimeDS ;
                        zaposlenik.Password = ksifra;
                        zaposlenik.Ime = imeDS;
                        zaposlenik.BrojTelefona = brojTelefonaDS;
                        zaposlenik.DatumRodjenja = datumDS;
                        zaposlenik.DatumZaposlenja = datumZDS;

                        userTableZaposlenik.InsertAsync(zaposlenik);

                        KlaseZaAzure.Supervizori supervizor = new KlaseZaAzure.Supervizori();

                        supervizor.id = regm.ZaposlenikId.ToString();

                        userTableSupervizori.InsertAsync(supervizor);

                        podaci.zaposlenici.Add(regm);
                        
                    }
                    catch (Exception e)
                    {

                    }

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
                    baza.zaposlenici.Add(regm);
                    baza.SaveChanges();

                    try
                    {
                        KlaseZaAzure.Zaposlenik zaposlenik = new KlaseZaAzure.Zaposlenik();

                        zaposlenik.id = regm.ZaposlenikId.ToString();
                        zaposlenik.KorisnickoIme = kime;
                        zaposlenik.Prezime = prezimeDS;
                        zaposlenik.Password = ksifra;
                        zaposlenik.Ime = imeDS;
                        zaposlenik.BrojTelefona = brojTelefonaDS;
                        zaposlenik.DatumRodjenja = datumDS;
                        zaposlenik.DatumZaposlenja = datumZDS;

                        userTableZaposlenik.InsertAsync(zaposlenik);

                        KlaseZaAzure.Dispeceri dispecer = new KlaseZaAzure.Dispeceri();

                        dispecer.id = regm.ZaposlenikId.ToString();

                        userTableDispeceri.InsertAsync(dispecer);

                        podaci.zaposlenici.Add(regm);

                    }
                    catch (Exception e)
                    {

                    }
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
            }
        }
    }
}
