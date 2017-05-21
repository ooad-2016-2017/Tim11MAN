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
        private int brojNarudzbe;
        private Musterija narucilac;
        private DateTime vrijemeZaPrevoz, datumPrevoza;
        private Vozac zaduzeni;
        private Ruta ruta;
        private string napomene;

        public int BrojNarudzbe
        {
            get
            {
                return brojNarudzbe;
            }

            set
            {
                brojNarudzbe = value;
            }
        }

        public Musterija Narucilac
        {
            get
            {
                return narucilac;
            }

            set
            {
                narucilac = value;
            }
        }

        public DateTime VrijemeZaPrevoz
        {
            get
            {
                return vrijemeZaPrevoz;
            }

            set
            {
                vrijemeZaPrevoz = value;
            }
        }

        public DateTime DatumPrevoza
        {
            get
            {
                return datumPrevoza;
            }

            set
            {
                datumPrevoza = value;
            }
        }

        internal Vozac Zaduzeni
        {
            get
            {
                return zaduzeni;
            }

            set
            {
                zaduzeni = value;
            }
        }

        internal Ruta Ruta
        {
            get
            {
                return ruta;
            }

            set
            {
                ruta = value;
            }
        }

        public string Napomene
        {
            get
            {
                return napomene;
            }

            set
            {
                napomene = value;
            }
        }
    }
}
