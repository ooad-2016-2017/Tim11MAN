using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatTaxiAgencijaMAN.Pomocne;
using Windows.UI.Popups;
using ProjekatTaxiAgencijaMAN.Modeli;

namespace ProjekatTaxiAgencijaMAN.ViewModeli
{
    class UvidUVozila
    {
        public string regvozila { get; set; }
        public string modelvozila { get; set; }
        public string godistevozila { get; set; }
        public string predjenikilometrivozila { get; set; }
        public string brojvoznjivozila { get; set; }
        public string vozacvozila { get; set; }
        public bool dnevni { get; set; }
        public bool mjesecni { get; set; }

        public ICommand pretraziVozilo { get; set; }

        public UvidUVozila()
        {
            pretraziVozilo = new RelayCommand<object>(pretraga, provjera);
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
                foreach (var vozilo in baza.vozila)
                {
                    if (vozilo.RegistracijskeTablice == regvozila)
                    {
                        provjera1 = true;
                        // nastavak ...
                    }
                }

                if (!provjera1)
                {
                    IspisError("Nema vozila sa ovom registracijom");
                }

        }
    }
}
