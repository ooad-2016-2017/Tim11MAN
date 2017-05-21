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
        public ICommand GlavnaStranica { get; set; }
        public ICommand RegistracijaStranica { get; set; }
        public ICommand KontaktiranjeTaksijaStranica { get; set; }
        public NavigationService NavigationServis;
        public Musterija musterijaIzPrijave = null;
        public RegistrovanaMusterija regmusterijaIzPrijave = null;
        public ProjekatTaxiAgencijaMAN.Modeli.Dispecer dispecerIzPrijave;
        public Supervizor supervizorIzPrijave = null;
        public Kompanija kompanijaIzPrijave = null;
        public String korisnickoime { get; set; }
        public String sifra { get; set; }

        public PrijavaVM()
        {
            GlavnaStranica = new RelayCommand<object>(glavnaStranica, prva);
            RegistracijaStranica = new RelayCommand<object>(registracijaStranica, druga);
            KontaktiranjeTaksijaStranica = new RelayCommand<object>(kontaktiranjeTaksijaStranica, treca);
            NavigationServis = new NavigationService();
        }

        public Boolean prva(Object o)
        {
            return true;
        }

        public Boolean druga(Object o)
        {
            return true;
        }

        public Boolean treca(Object o)
        {
            return true;
        }

        public async void glavnaStranica(object o)
        {
            // sad ovdje treba provjeriti ima li registrovani korisnik sa ovim podacima
            // kompanija, dispecer, regkorisnik, neregkorisnik ili supervizor

            List<RegistrovanaMusterija> rms = new List<RegistrovanaMusterija>();
            rms.Add(new RegistrovanaMusterija()
            {
                KorisnickoIme = "loca",
                Password = "sifra"
            });

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
                NavigationServis.Navigate(typeof(ProjekatTaxiAgencijaMAN.RegistrovaniKorisnik), new GlavnaMusterijeVM(this));
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
            NavigationServis.Navigate(typeof(ProjekatTaxiAgencijaMAN.RegistracijaMusterije), new RegistracijaMusterijeVM());
        }

        public void kontaktiranjeTaksijaStranica(object o)
        {
            NavigationServis.Navigate(typeof(KontaktiranjeTaksija), new KontaktiranjeTaksijaVM(this));
        }
    }
}
