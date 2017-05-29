using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTaxiAgencijaMAN.Modeli
{
    public class Vozac : Zaposlenik
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VozacId { get; set; }

        public Vozilo Vozilo { get; set; }
        public bool Slobodan { get; set; }
        public List<DateTime> ListaDatumaVoznji { get; set; }

        public Vozac():base()
        {
            VozacId = id;
            id++;
        }
    }
}
