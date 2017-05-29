using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTaxiAgencijaMAN.Modeli
{
    public class Supervizor : Zaposlenik
    {
        public int Id { get; set; }
        public Supervizor():base()
        {
            Id = id;
        }
    }
}
