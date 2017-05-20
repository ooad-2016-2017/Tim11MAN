using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatTaxiAgencijaMAN.Modeli;

namespace ProjekatTaxiAgencijaMAN
{
    public class SviPodaci
    {
        public List<RegistrovanaMusterija> regMusterije;
        public List<Zaposlenik> zaposlenici;
        public List<Kompanija> kompanije;
        public List<Vozac> vozaci;

        public void postaviPodatke()
        {
            RegistrovanaMusterija rm = new RegistrovanaMusterija();
            rm.ImeKorisnika = "Ime";
            rm.KorisnickoIme = "ime";
            rm.Password = "sifra";

            regMusterije.Add(rm);
        }
    }
}
