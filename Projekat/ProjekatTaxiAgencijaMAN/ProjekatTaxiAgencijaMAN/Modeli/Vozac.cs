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
        private static int id = 0;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VozacId { get; set; }

        public Vozilo Vozilo { get; set; }
        public bool Slobodan { get; set; }
        public List<DateTime> ListaDatumaVoznji { get; set; }

        public Vozac()
        {
            VozacId = id;
            id++;
        }
    }
}
