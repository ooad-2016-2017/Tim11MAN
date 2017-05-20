using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTaxiAgencijaMAN.Modeli
{
    public class Vozilo
    {
        private string vrstaVozila, registracijskeTablice, brojVozila;
        private double srednjaBrzina;
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

        public double SrednjaBrzina
        {
            get
            {
                return srednjaBrzina;
            }

            set
            {
                srednjaBrzina = value;
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
