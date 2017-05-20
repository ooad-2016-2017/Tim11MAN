using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatTaxiAgencijaMAN.Pomocne;

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

        ICommand pretraziVozilo;

        public UvidUVozila()
        {
            pretraziVozilo = new RelayCommand<object>(pretraga, provjera);
        }

        public bool provjera(object o)
        {
            return true;
        }

        public void pretraga(object o)
        {
            //samo pretraziti po registraciji
        }
    }
}
