using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatTaxiAgencijaMAN.Pomocne;
using ProjekatTaxiAgencijaMAN.Modeli;
using Windows.UI.Popups;
using System.ComponentModel;

namespace ProjekatTaxiAgencijaMAN.ViewModeli
{
    class UvidUVozace: INotifyPropertyChanged
    {
        DPodaci podaci;
        Kompanija regm;
        public string idvozaca { get; set; }
        public string imevozaca { get; set; }
        public string prezimevozaca { get; set; }
        public string predjenikilometrivozaca { get; set; }
        public string brojvoznjivozaca { get; set; }
        public string regvozilavozaca { get; set; }
        public bool dnevni { get; set; }
        public bool mjesecni { get; set; }

        public ICommand pretraziBV { get; set; }

        public bool provjeriid(String id)
        {
            if (id == null) return false;
            for (int i = 0; i < id.Length; i++)
                if (id[i] < '0' || id[i] > '9') return false;
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Promjena(String s)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(s));
            }
        }

        public UvidUVozace(GlavnaKompanijeVM gkvm)
        {
            this.regm = gkvm.regm;
            podaci = gkvm.podaci;
            pretraziBV = new RelayCommand<object>(pretrazi, provjera);
        }

        public bool provjera(object o)
        {
            return true;
        }

        public async void IspisError(string error)
        {
            var raz = new MessageDialog(error);
            await raz.ShowAsync();
        }

        public void pretrazi(object o)
        {
            var baza = new TaxiDbContext();

            

            if (!provjeriid(idvozaca))
            {
                // obavijestiti da id nije uredu
                IspisError("Neispravan ID");
            }
            else
            {
                bool provjera1 = false;

                // NE RADI
                if (false)
                {
                    // OVO NE RADI!!!
                    // proci kroz vozace i provjeriti ima li vozaca sa ovim id ako nema obavijestiti
                    foreach (var vozac in baza.vozaci)
                    {
                        if (vozac.VozacId == Convert.ToInt32(idvozaca))
                        {
                            provjera1 = true;
                            // nastavak ...
                        }
                    }
                }
                // NE RADI

                foreach(Zaposlenik v in regm.ListaZaposlenika)
                {
                    if(v is Vozac)
                    {
                        Vozac v1 = (Vozac)v;
                        if (v1.VozacId == Convert.ToInt32(idvozaca))
                        {
                            provjera1 = true;
                            imevozaca = v1.Ime;
                            prezimevozaca = v1.Prezime;
                            if (v1.ListaDatumaVoznji != null)
                            {
                                brojvoznjivozaca = v1.ListaDatumaVoznji.Count.ToString();
                            }
                            else
                            {
                                brojvoznjivozaca = "Nema voznji";
                            }
                            predjenikilometrivozaca = v1.Vozilo.Predjenikilometri.ToString();
                            regvozilavozaca = v1.Vozilo.RegistracijskeTablice;
                        }
                    }
                }

                if (!provjera1)
                {
                    imevozaca = "";
                    prezimevozaca = "";
                    brojvoznjivozaca = "";
                    predjenikilometrivozaca = "";
                    regvozilavozaca = "";
                    IspisError("Nema vozaca sa ovim ID");
                }

                Promjena("imevozaca");
                Promjena("prezimevozaca");
                Promjena("brojvoznjivozaca");
                Promjena("predjenikilometrivozaca");
                Promjena("regvozilavozaca");
            }
        }
    }
}
