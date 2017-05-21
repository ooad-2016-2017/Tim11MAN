using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatTaxiAgencijaMAN.Pomocne;
using ProjekatTaxiAgencijaMAN.Modeli;

namespace ProjekatTaxiAgencijaMAN.ViewModeli
{
    class ReviewSlanjeVM
    {
        public ICommand posaljiB { get; set; }
        public string misljenje { get; set; }

        public ReviewSlanjeVM()
        {
            posaljiB = new RelayCommand<object>(slanjereview, provjera);
        }

        public bool provjera(object o)
        {
            return true;
        }
        public void slanjereview(object o)
        {
            // samo dodat misljenje u bazu podataka
            // fali dio za bazu podataka
        }
    }
}
