using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTaxiAgencijaMAN.Modeli
{
    public class Ruta
    {
        private string polaznaLokacija, odredisnaLokacija;
        private double duzinaRute, procjenjenoVrijeme;

        public string PolaznaLokacija
        {
            get
            {
                return polaznaLokacija;
            }

            set
            {
                polaznaLokacija = value;
            }
        }

        public string OdredisnaLokacija
        {
            get
            {
                return odredisnaLokacija;
            }

            set
            {
                odredisnaLokacija = value;
            }
        }

        public double DuzinaRute
        {
            get
            {
                return duzinaRute;
            }

            set
            {
                duzinaRute = value;
            }
        }

        public double ProcjenjenoVrijeme
        {
            get
            {
                return procjenjenoVrijeme;
            }

            set
            {
                procjenjenoVrijeme = value;
            }
        }
    }
}
