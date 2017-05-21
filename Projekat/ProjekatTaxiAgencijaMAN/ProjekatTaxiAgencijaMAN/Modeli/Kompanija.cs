
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTaxiAgencijaMAN.Modeli
{
    public class Kompanija
    {
        private static int id = 0;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KompanijaId { get; set; }
        public string NazivKompanije { get; set; }
        public string AdresaKompanije { get; set; }
        public string EmailKompanije{ get; set; }
        public string KorisnickoIme { get; set; }
        public string Sifra{ get; set; }
        public DateTime DatumOsnivanja { get; set; }
        public int BrojTelefona { get; set; }
        public List<Zaposlenik> ListaZaposlenika { get; set; }

        public Kompanija()
        {
            KompanijaId = id;
            id++;
        }

    }
}
