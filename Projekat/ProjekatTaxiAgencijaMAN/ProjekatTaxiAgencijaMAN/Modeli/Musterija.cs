using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTaxiAgencijaMAN.Modeli
{
    public class Musterija
    {
        public static int idKorisnikaglobalni = 0;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MusterijaId { get; set; }

        public Musterija()
        {
            MusterijaId = idKorisnikaglobalni;
            idKorisnikaglobalni++;
        }

    }
}
