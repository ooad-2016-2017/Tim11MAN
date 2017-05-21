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
        private static int idKorisnikaglobalni = 0;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int idKorisnika = 0;

        public Musterija()
        {
            idKorisnika = idKorisnikaglobalni;
            idKorisnikaglobalni++;
        }

        public int IdKorisnika
        {
            get
            {
                return idKorisnika;
            }

            set
            {
                idKorisnika = value;
            }
        }
    }
}
