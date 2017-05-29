using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTaxiAgencijaMAN.KlaseZaAzure
{
    class Zaposlenik
    {
        public string id
        {
            get;set;
        }
        public string BrojTelefona
        {
            get;set;
        }
        public DateTime DatumRodjenja
        {
            get;set;
        }
        public DateTime DatumZaposlenja
        {
            get;set;
        }
        public string Ime
        {
            get;set;
        }
        public int KompanijaID
        {
            get;set;
        }
        public string KorisnickoIme
        {
            get;set;
        }
        public string Password
        {
            get;set;
        }
        public string Prezime
        {
            get;set;
        }
    }
}
