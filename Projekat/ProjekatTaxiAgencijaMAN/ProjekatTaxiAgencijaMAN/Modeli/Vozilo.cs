using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTaxiAgencijaMAN.Modeli
{
    public class Vozilo
    {
        private static int id = 0;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VoziloId { get; set; }
        public string RegistracijskeTablice { get; set; }
        public string VrstaVozila { get; set; }
        public double Predjenikilometri { get; set; }
        public int GodisteVozila { get; set; }

        public Vozilo()
        {
            VoziloId = id;
            id++;
        }

        
    }
}
