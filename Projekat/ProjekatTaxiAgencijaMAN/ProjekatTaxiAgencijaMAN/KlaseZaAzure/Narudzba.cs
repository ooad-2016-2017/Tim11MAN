using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTaxiAgencijaMAN.KlaseZaAzure
{
    class Narudzba
    {
        public string id { get; set; }
        public DateTime DatumPrevoza { get; set; }
        public string Napomene { get; set; }
        public int NarucilacID { get; set; }
        public int RutaID { get; set; }
        public string VrijemeZaPrevoz { get; set; }
        public int ZaduzeniVozacID { get; set; }
    }
}
