using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatTaxiAgencijaMAN.Pomocne;

namespace ProjekatTaxiAgencijaMAN.ViewModeli
{
    class UvidUVozace
    {
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
            for (int i = 0; i < id.Length; i++)
                if (id[i] < '0' || id[i] > '9') return false;
            return true;
        }

        public UvidUVozace()
        {
            pretraziBV = new RelayCommand<object>(pretrazi, provjera);
        }

        public bool provjera(object o)
        {
            return true;
        }

        public void pretrazi(object o)
        {
            if (!provjeriid(idvozaca))
            {
                // obavijestiti da id nije uredu
            }
            else
            {
                // proci kroz vozace i provjeriti ima li vozaca sa ovim id ako nema obavijestiti
            }
        }
    }
}
