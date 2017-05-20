using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTaxiAgencijaMAN.Modeli
{
    public class Zaposlenik
    {
        private static int id=0;
        private int idZaposlenog;
        private string ime, prezime, brojTelefona, korisnickoIme, password;
        private DateTime datumRodjenja, datumZaposlenja;

        public Zaposlenik()
        {
            idZaposlenog = id;
            id++;
        }

        public string KorisnickoIme
        {
            get
            {
                return korisnickoIme;
            }

            set
            {
                korisnickoIme = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public int IdZaposlenog
        {
            get
            {
                return idZaposlenog;
            }

            set
            {
                idZaposlenog = value;
            }
        }

        public string Ime
        {
            get
            {
                return ime;
            }

            set
            {
                ime = value;
            }
        }

        public string Prezime
        {
            get
            {
                return prezime;
            }

            set
            {
                prezime = value;
            }
        }

        public string BrojTelefona
        {
            get
            {
                return brojTelefona;
            }

            set
            {
                brojTelefona = value;
            }
        }

        public DateTime DatumRodjenja
        {
            get
            {
                return datumRodjenja;
            }

            set
            {
                datumRodjenja = value;
            }
        }

        public DateTime DatumZaposlenja
        {
            get
            {
                return datumZaposlenja;
            }

            set
            {
                datumZaposlenja = value;
            }
        }
    }
}
