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
        public DPodaci podaci;
        public ICommand GlavnaStranica { get; set; }
        public ICommand RegistracijaStranica { get; set; }
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
            dispecerIzPrijave = null;
            musterijaIzPrijave = null;
            supervizorIzPrijave = null;
            kompanijaIzPrijave = null;
            // sad ovdje treba provjeriti ima li registrovani korisnik sa ovim podacima
            // kompanija, dispecer, regkorisnik, neregkorisnik ili supervizor
            /*
            List<RegistrovanaMusterija> rms = new List<RegistrovanaMusterija>();
            rms.Add(new RegistrovanaMusterija()
            {
                KorisnickoIme = "loca",
                Password = "sifra"
            });

            List<Supervizor> spr = new List<Supervizor>();
            spr.Add(new Modeli.Supervizor()
            {
                KorisnickoIme = "ime",
                Password = "sifra"
            });

            List<Kompanija> kmp = new List<Kompanija>();
            kmp.Add(new Kompanija()
            {
                KorisnickoIme = "k",
                Sifra = "s"
            });
            List<ProjekatTaxiAgencijaMAN.Modeli.Dispecer> dis = new List<ProjekatTaxiAgencijaMAN.Modeli.Dispecer>();
            dis.Add(new ProjekatTaxiAgencijaMAN.Modeli.Dispecer()
            {
                KorisnickoIme = "d",
                Password = "s"
            });

            for (int i=0; i<rms.Count; i++)
            {
                if (rms[i].KorisnickoIme == korisnickoime)
                {
                    if (rms[i].Password == sifra)
                    {
                        regmusterijaIzPrijave = rms[i];
                    }
                }
            }

            for (int i = 0; i < kmp.Count; i++)
            {
                if (kmp[i].KorisnickoIme == korisnickoime)
                {
                    if (kmp[i].Sifra== sifra)
                    {
                        kompanijaIzPrijave = kmp[i];
                    }
                }
            }

            for (int i = 0; i < spr.Count; i++)
            {
                if (spr[i].KorisnickoIme == korisnickoime)
                {
                    if (spr[i].Password == sifra)
                    {
                        supervizorIzPrijave = spr[i];
                    }
                }
            }

            for (int i = 0; i < dis.Count; i++)
            {
                if (dis[i].KorisnickoIme == korisnickoime)
                {
                    if (dis[i].Password == sifra)
                    {
                        dispecerIzPrijave = dis[i];
                    }
                }
            }*/
            podaci = new DPodaci();

            List<Kompanija> kmp = podaci.kompanije;

            for (int i = 0; i < kmp.Count; i++)
            {
                if (kmp[i].KorisnickoIme == korisnickoime)
                {
                    if (kmp[i].Sifra == sifra)
                    {
                        kompanijaIzPrijave = kmp[i];
                    }
                }
            }
            List<Musterija> rms = podaci.musterije;
            for (int i = 0; i < rms.Count; i++)
            {
                RegistrovanaMusterija rm = (RegistrovanaMusterija)rms[i];
                if (rm.KorisnickoIme == korisnickoime)
                {
                    if (rm.Password == sifra)
                    {
                        regmusterijaIzPrijave = rm;
                    }
                }
            }


            if (supervizorIzPrijave != null)
            {
                NavigationServis.Navigate(typeof(SupervizorForma), new GlavnaSupervizoraVM(this));
            }
            else if (dispecerIzPrijave != null)
            {
                NavigationServis.Navigate(typeof(ProjekatTaxiAgencijaMAN.forme.Dispecer), new GlavnaDispeceraVM(this));
            }
            else if (regmusterijaIzPrijave != null)
            {
                NavigationServis.Navigate(typeof(ProjekatTaxiAgencijaMAN.forme.RegistrovaniKorisnik), new GlavnaMusterijeVM(this));
            }
            else if (kompanijaIzPrijave != null)
            {
                NavigationServis.Navigate(typeof(ProfilKompanije), new GlavnaKompanijeVM(this));
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
    }
}
