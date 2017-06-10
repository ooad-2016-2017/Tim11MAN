using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatTaxiAgencijaMAN.Modeli;

namespace ProjekatTaxiAgencijaMAN
{
    public class DPodaci
    {
        public List<Zaposlenik> zaposlenici { get; set; }
        public List<Kompanija> kompanije { get; set; }
        public List<Musterija> musterije { get; set; }
        public List<Narudzba> narudzbe { get; set; }
        public List<Vozilo> vozila { get; set; }

        public DPodaci()
        {
            zaposlenici = new List<Zaposlenik>();
            kompanije = new List<Kompanija>();
            musterije = new List<Musterija>();
            narudzbe = new List<Narudzba>();
            vozila = new List<Vozilo>();

            zaposlenici.Add(new Dispecer()
            {
                KorisnickoIme = "dis",
                Password = "pas",
                Ime = "dis"
            });
            kompanije.Add(new Kompanija()
            {
                KorisnickoIme = "kom",
                Sifra = "pas"
            });
            musterije.Add(new RegistrovanaMusterija()
            {
                KorisnickoIme = "rm",
                Password = "pas"
            });
            Vozilo v1 = new Vozilo();
            v1.GodisteVozila = 1111;
            v1.RegistracijskeTablice = "F1";
            v1.Predjenikilometri = 100;
            v1.VrstaVozila = "Van";
            zaposlenici.Add(new Vozac()
            {
                Ime = "Vozac1",
                Prezime = "V1",
                Slobodan = true,
                DatumZaposlenja = DateTime.Now,
                DatumRodjenja = DateTime.Now,
                BrojTelefona = "000666111",
                Vozilo=v1
            });
            kompanije[0].ListaZaposlenika = new List<Zaposlenik>();
            kompanije[0].ListaZaposlenika.Add(zaposlenici[1] as Vozac);
            zaposlenici.Add(new Supervizor()
            {
                KorisnickoIme = "sup",
                Password = "pas",
                Ime = "sup"
            });


        }
    }
}
