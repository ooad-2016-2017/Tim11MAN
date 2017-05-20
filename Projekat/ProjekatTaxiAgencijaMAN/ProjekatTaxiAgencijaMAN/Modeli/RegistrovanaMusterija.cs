using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTaxiAgencijaMAN.Modeli
{
    public class RegistrovanaMusterija : Musterija
    {
        private string imeKorisnika, prezimeKorisnika, korisnickoIme, password, emailAdresa;
        private DateTime datumRodjenja;
        private List<DateTime> datumVoznji; //atribut uz pomoc kojeg ce se pored ostalog odredjivati popust

        public string ImeKorisnika
        {
            get
            {
                return imeKorisnika;
            }

            set
            {
                imeKorisnika = value;
            }
        }

        public string PrezimeKorisnika
        {
            get
            {
                return prezimeKorisnika;
            }

            set
            {
                prezimeKorisnika = value;
            }
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

        public string EmailAdresa
        {
            get
            {
                return emailAdresa;
            }

            set
            {
                emailAdresa = value;
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

        public List<DateTime> DatumVoznji
        {
            get
            {
                return datumVoznji;
            }

            set
            {
                datumVoznji = value;
            }
        }
    }
}
