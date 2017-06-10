using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTaxiAgencijaMAN.Modeli
{
    public class Ruta
    {
        private static int id = 0;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RutaId { get; set; }
        public double DuzinaRute { get; set; }
        public double ProcjenjenoVrijeme { get; set; }

        public Ruta()
        {
            RutaId = id;
            ++id;
        }

    }
}
