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
    class KontaktiranjeVozacaVM
    {
        ICommand PretraziVozaca;
        public String brojTelefonaVozaca { get; set; }
        public String id { get; set; }

        public KontaktiranjeVozacaVM()
        {
            PretraziVozaca = new RelayCommand<object>(kontaktiranje, mozekontaktiranje);
        }

        public bool mozekontaktiranje(object o)
        {
            return true;
        }

        public void kontaktiranje(object o)
        {
            // pretrazit bazu sa ovim id
            // samo sto ovdje ne ide new vozac
            Vozac v = new Vozac();
            brojTelefonaVozaca = v.BrojTelefona;
        }
    }
}
