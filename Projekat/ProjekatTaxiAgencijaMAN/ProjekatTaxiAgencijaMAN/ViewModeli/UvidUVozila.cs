using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatTaxiAgencijaMAN.Pomocne;
using Windows.UI.Popups;
using ProjekatTaxiAgencijaMAN.Modeli;
using System.ComponentModel;

namespace ProjekatTaxiAgencijaMAN.ViewModeli
{
    class UvidUVozila : INotifyPropertyChanged
    {
        Kompanija regm;
        Dispecer dis;
        DPodaci podaci;
        public string regvozila { get; set; }
        public string modelvozila { get; set; }
        public string godistevozila { get; set; }
        public string predjenikilometrivozila { get; set; }
        public string brojvoznjivozila { get; set; }
        public string vozacvozila { get; set; }
        public bool dnevni { get; set; }
        public bool mjesecni { get; set; }

        public ICommand pretraziVozilo { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Promjena(String s)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(s));
            }
        }

        public UvidUVozila(GlavnaKompanijeVM gkvm)
        {
            this.regm = gkvm.regm;
            pretraziVozilo = new RelayCommand<object>(pretraga, provjera);
            podaci = gkvm.podaci;
        }

        public UvidUVozila(GlavnaDispeceraVM gdvm)
        {
            dis = gdvm.regm;
            pretraziVozilo = new RelayCommand<object>(pretraga, provjera);
            podaci = gdvm.podaci;
        }

        public async void IspisError(string error)
        {
            var raz = new MessageDialog(error);
            await raz.ShowAsync();
        }

        public bool provjera(object o)
        {
            return true;
        }

        public void pretraga(object o)
        {
            //samo pretraziti po registraciji

            var baza = new TaxiDbContext();

                bool provjera1 = false;
            // proci kroz vozace i provjeriti ima li vozaca sa ovim id ako nema obavijestiti


            // NE RADI
            if (false)
            {
                // OVO NE RADI
                foreach (var vozilo in baza.vozila)
                {
                    if (vozilo.RegistracijskeTablice == regvozila)
                    {
                        provjera1 = true;
                        // nastavak ...
                    }
                }
            }
            // NE RADI
            if (dis == null)
            {
                foreach (Zaposlenik v in regm.ListaZaposlenika)
                {
                    if (v is Vozac)
                    {
                        Vozac v1 = (Vozac)v;
                        if (v1.Vozilo.RegistracijskeTablice == regvozila)
                        {
                            provjera1 = true;
                            godistevozila = v1.Vozilo.GodisteVozila.ToString();
                            modelvozila = v1.Vozilo.VrstaVozila;
                            predjenikilometrivozila = v1.Vozilo.Predjenikilometri.ToString();
                            if (v1.ListaDatumaVoznji != null)
                            {
                                brojvoznjivozila = v1.ListaDatumaVoznji.Count.ToString();
                            }
                            else
                            {
                                brojvoznjivozila = "Nema voznji";
                            }
                            vozacvozila = v1.Ime;
                        }
                    }
                }
            }
            else if(regm == null)
            {
                foreach (Zaposlenik v in podaci.zaposlenici)
                {
                    if (v is Vozac)
                    {
                        Vozac v1 = (Vozac)v;
                        if (v1.Vozilo.RegistracijskeTablice == regvozila)
                        {
                            provjera1 = true;
                            godistevozila = v1.Vozilo.GodisteVozila.ToString();
                            modelvozila = v1.Vozilo.VrstaVozila;
                            predjenikilometrivozila = v1.Vozilo.Predjenikilometri.ToString();
                            if (v1.ListaDatumaVoznji != null)
                            {
                                brojvoznjivozila = v1.ListaDatumaVoznji.Count.ToString();
                            }
                            else
                            {
                                brojvoznjivozila = "Nema voznji";
                            }
                            vozacvozila = v1.Ime;
                        }
                    }
                }
            }

            if (!provjera1)
            {
                godistevozila = "";
                modelvozila = "";
                predjenikilometrivozila = "";
                brojvoznjivozila = "";
                vozacvozila = "";
                IspisError("Nema vozila sa ovom registracijom");
            }

            Promjena("godistevozila");
            Promjena("modelvozila");
            Promjena("brojvoznjivozila");
            Promjena("predjenikilometrivozila");
            Promjena("vozacvozila");

        }
    }
}
