using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTaxiAgencijaMAN.KlaseZaAzure
{
    class Ruta
    {
        public string id { get; set; }
        public double DuzinaRute { get; set; }
        public double KrajnjaLat { get; set; }
        public double KrajnjaLong { get; set; }
        public string OdredisnaLokacija { get; set; }
        public double PolaznaLat { get; set; }
        public double PolaznaLong { get; set; }
        public string PolaznaLokacija { get; set; }
        public double ProcjenjenoVrijeme { get; set; }
    }
}
