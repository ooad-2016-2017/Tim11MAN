
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTaxiAgencijaMAN.Modeli
{
    public class Kompanija
    {
        private string nazivKompanije, adresaKompanije, emailKompanije, korisnickoIme, sifra;
        private DateTime datumOsnivanja;
        private int brojTelefona;
        private List<Zaposlenik> listaZaposlenika;

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

        public string Sifra
        {
            get
            {
                return sifra;
            }
            set
            {
                sifra = value;
            }
        }

        public string NazivKompanije
        {
            get
            {
                return nazivKompanije;
            }

            set
            {
                nazivKompanije = value;
            }
        }

        public string AdresaKompanije
        {
            get
            {
                return adresaKompanije;
            }

            set
            {
                adresaKompanije = value;
            }
        }

        public string EmailKompanije
        {
            get
            {
                return emailKompanije;
            }

            set
            {
                emailKompanije = value;
            }
        }

        public DateTime DatumOsnivanja
        {
            get
            {
                return datumOsnivanja;
            }

            set
            {
                datumOsnivanja = value;
            }
        }

        public int BrojTelefona
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

        public List<Zaposlenik> ListaZaposlenika
        {
            get
            {
                return listaZaposlenika;
            }

            set
            {
                listaZaposlenika = value;
            }
        }
    }
}
