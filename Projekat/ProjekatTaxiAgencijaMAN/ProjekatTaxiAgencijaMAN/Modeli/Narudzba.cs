using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTaxiAgencijaMAN.Modeli
{
    public class Narudzba
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NarudzbaId { get; set; }
        public Musterija Narucilac { get; set; }
        public DateTime VrijemeZaPrevoz { get; set; }
        public DateTime DatumPrevoza { get; set; }
        public Vozac Zaduzeni { get; set; }
        public Ruta Ruta { get; set; }
        public string Napomene { get; set; }

        
    }
}
