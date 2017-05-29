using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTaxiAgencijaMAN.Modeli
{
    public class RegistrovanaMusterija : Musterija
    {
        public int Id { get; set; }
        public string ImeKorisnika { get; set; }
        public string PrezimeKorisnika { get; set; }
        public string KorisnickoIme { get; set; }
        public string Password { get; set; }
        public string EmailAdresa { get; set; }
        public string BrojTelefona { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public List<DateTime> DatumVoznji { get; set; } //atribut uz pomoc kojeg ce se pored ostalog odredjivati popust
        public RegistrovanaMusterija(): base()
        {
            Id = idKorisnikaglobalni;
        }
    }
}
