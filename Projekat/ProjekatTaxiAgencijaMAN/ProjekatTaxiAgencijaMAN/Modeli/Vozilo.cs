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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private string registracijskeTablice;
        private string vrstaVozila, brojVozila;
        private double predjenikilometri;
        private int godisteVozila;

        public string VrstaVozila
        {
            get
            {
                return vrstaVozila;
            }

            set
            {
                vrstaVozila = value;
            }
        }

        public string RegistracijskeTablice
        {
            get
            {
                return registracijskeTablice;
            }

            set
            {
                registracijskeTablice = value;
            }
        }

        public string BrojVozila
        {
            get
            {
                return brojVozila;
            }

            set
            {
                brojVozila = value;
            }
        }

        public double PredjeniKilometri
        {
            get
            {
                return predjenikilometri;
            }

            set
            {
                predjenikilometri = value;
            }
        }

        public int GodisteVozila
        {
            get
            {
                return godisteVozila;
            }

            set
            {
                godisteVozila = value;
            }
        }
    }
}
