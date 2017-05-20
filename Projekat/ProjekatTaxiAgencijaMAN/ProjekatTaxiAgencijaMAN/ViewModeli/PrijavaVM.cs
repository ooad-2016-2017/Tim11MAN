using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatTaxiAgencijaMAN.Modeli;
using ProjekatTaxiAgencijaMAN.forme;
using ProjekatTaxiAgencijaMAN.Pomocne;

namespace ProjekatTaxiAgencijaMAN.ViewModeli
{
    class PrijavaVM
    {
        public ICommand GlavnaStranica;
        public ICommand RegistracijaStranica;
        public ICommand KontaktiranjeTaksijaStranica;
        public NavigationService NavigationServis;
        public Musterija musterijaIzPrijave;
        public RegistrovanaMusterija regmusterijaIzPrijave;
        public ProjekatTaxiAgencijaMAN.Modeli.Dispecer dispecerIzPrijave;
        public Supervizor supervizorIzPrijave;
        public Kompanija kompanijaIzPrijave;
        public String korisnickoime { get; set; }
        public String sifra { get; set; }

        public PrijavaVM()
        {
            GlavnaStranica = new RelayCommand<object>(glavnaStranica);
            RegistracijaStranica = new RelayCommand<object>(registracijaStranica);
            KontaktiranjeTaksijaStranica = new RelayCommand<object>(kontaktiranjeTaksijaStranica);
            NavigationServis = new NavigationService();
        }

        public async void glavnaStranica(object o)
        {
            // sad ovdje treba provjeriti ima li registrovani korisnik sa ovim podacima
            // kompanija, dispecer, regkorisnik, neregkorisnik ili supervizor
            SviPodaci svipodaci = new SviPodaci();
            svipodaci.postaviPodatke();
            List<RegistrovanaMusterija> rms = svipodaci.regMusterije;

            for(int i=0; i<rms.Count; i++)
            {
                if (rms[i].KorisnickoIme == korisnickoime)
                {
                    if (rms[i].Password == sifra)
                    {
                        regmusterijaIzPrijave = rms[i];
                    }
                }
            }

            if (regmusterijaIzPrijave != null)
            {
                NavigationServis.Navigate(typeof(ProjekatTaxiAgencijaMAN.forme.RegistrovaniKorisnik), new GlavnaMusterijeVM(this));
            }
            else if (dispecerIzPrijave != null)
            {

            }
            else if (supervizorIzPrijave != null)
            {

            }
            else if (kompanijaIzPrijave != null)
            {

            }
            else
            {
                // greska
            }

        }

        public void registracijaStranica(object o)
        {
            NavigationServis.Navigate(typeof(ProjekatTaxiAgencijaMAN.forme.RegistracijaMusterije), new RegistracijaMusterijeVM());
        }

        public void kontaktiranjeTaksijaStranica(object o)
        {
            NavigationServis.Navigate(typeof(KontaktiranjeTaksija), new KontaktiranjeTaksijaVM(this));
        }
    }
}
