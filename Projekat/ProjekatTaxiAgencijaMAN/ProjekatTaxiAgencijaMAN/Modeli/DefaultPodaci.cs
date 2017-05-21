using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTaxiAgencijaMAN.Modeli
{
    class DefaultPodaci
    {
        public static void Initialize(TaxiDbContext context)
        {
            if (!context.zaposlenici.Any())
            {
                context.zaposlenici.Add(new Vozac() {
                    Ime = "Muhamed", Prezime = "Kapo", BrojTelefona = "000", DatumRodjenja = DateTime.Now, KorisnickoIme = "KiMu", Password = "sifra"
                });
            }
            if (!context.musterije.Any())
            {
                context.musterije.Add(new RegistrovanaMusterija()
                {
                    KorisnickoIme = "loca", Password = "sifra"
                });
            }
        }
    }
}
