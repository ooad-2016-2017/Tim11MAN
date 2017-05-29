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
using Microsoft.WindowsAzure.MobileServices;

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
            IMobileServiceTable <KlaseZaAzure.Zaposlenik > userTableObj = App.MobileService.GetTable<KlaseZaAzure.Zaposlenik>();
            IMobileServiceTable<KlaseZaAzure.Vozilo> userTableObj1 = App.MobileService.GetTable<KlaseZaAzure.Vozilo>();
            IMobileServiceTable<KlaseZaAzure.Vozac> userTableObj2 = App.MobileService.GetTable<KlaseZaAzure.Vozac>();
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
            
            /*foreach (var vozilo in baza.vozila)
            {
                if (vozilo.RegistracijskeTablice == registracijaVozila) postojiIme = true;
            }
            */
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
                regm.DatumZaposlenja = datumZVozaca;
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
                //baza.vozila.Add(v);

                try
                {
                    KlaseZaAzure.Zaposlenik z = new KlaseZaAzure.Zaposlenik();

                    z.id = regm.ZaposlenikId.ToString();
                    z.KorisnickoIme = "";
                    z.Prezime = prezimeVozaca;
                    z.Password= "";
                    z.Ime = imeVozaca;
                    z.BrojTelefona = brojTelefonaVozaca;
                    z.DatumRodjenja = datumVozaca;
                    z.DatumZaposlenja = datumZVozaca;

                    userTableObj.InsertAsync(z);


                    KlaseZaAzure.Vozilo v12 = new KlaseZaAzure.Vozilo();

                    v12.id = v.VoziloId.ToString();
                    v12.Registracija = registracijaVozila;
                    v12.Vrsta = modelVozila;
                    v12.Godiste = Convert.ToInt32(godisteVozila);
                    v12.PredjeniKilometri = 0;

                    userTableObj1.InsertAsync(v12);

                    KlaseZaAzure.Vozac v123 = new KlaseZaAzure.Vozac();

                    v123.id= regm.ZaposlenikId.ToString();
                    v123.BrojTelefona = brojTelefonaVozaca;
                    v123.DatumRodjenja = datumVozaca;
                    v123.DatumZaposlenja = datumZVozaca;
                    v123.Ime = imeVozaca;
                    v123.Prezime = prezimeVozaca;
                    v123.KorisnickoIme = "";
                    v123.Sifra = "";
                    v123.Slobodan = true;
                    v123.VoziloID = v.VoziloId;
                    v123.ZaposlenikID = regm.ZaposlenikId;

                    userTableObj2.InsertAsync(v123);

                }
                catch(Exception e)
                {

                }


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
