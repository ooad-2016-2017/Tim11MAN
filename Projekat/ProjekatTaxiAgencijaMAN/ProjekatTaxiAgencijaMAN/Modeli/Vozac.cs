using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTaxiAgencijaMAN.Modeli
{
    public class Vozac : Zaposlenik
    {
        private Vozilo vozilo;
        private bool slobodan;
        private List<DateTime> listaDatumaVoznji;

        internal Vozilo Vozilo
        {
            get
            {
                return vozilo;
            }

            set
            {
                vozilo = value;
            }
        }

        public bool Slobodan
        {
            get
            {
                return slobodan;
            }

            set
            {
                slobodan = value;
            }
        }

        public List<DateTime> ListaDatumaVoznji
        {
            get
            {
                return listaDatumaVoznji;
            }

            set
            {
                listaDatumaVoznji = value;
            }
        }
    }
}
