using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTaxiAgencijaMAN.Modeli
{
    public class Reviewovi
    {
        public static int id=0;
        public int Id { get; set; }
        public string Misljenje { get; set; }
        public Reviewovi()
        {
            Id = id;
            id++;
        }
    }
}
