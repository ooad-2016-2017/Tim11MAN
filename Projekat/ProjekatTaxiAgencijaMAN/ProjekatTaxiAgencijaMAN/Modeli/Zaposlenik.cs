using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTaxiAgencijaMAN.Modeli
{
    public class Zaposlenik
    {
        private static int id=0;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ZaposlenikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string KorisnickoIme { get; set; }
        public string Password { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public DateTime DatumZaposlenja { get; set; }

        public Zaposlenik()
        {
            ZaposlenikId = id;
            id++;
        }

        
    }
}
