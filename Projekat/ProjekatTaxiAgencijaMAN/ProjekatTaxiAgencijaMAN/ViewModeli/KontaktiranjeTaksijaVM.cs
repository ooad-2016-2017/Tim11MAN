using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatTaxiAgencijaMAN.Pomocne;
using Windows.UI.Popups;
using ProjekatTaxiAgencijaMAN.Modeli;

namespace ProjekatTaxiAgencijaMAN.ViewModeli
{
    class KontaktiranjeTaksijaVM
    {
        DPodaci podaci;
        public ICommand PosaljiZahtjev { get; set; }
        public String ime { get; set; }
        public String prezime { get; set; }
        public String brojtelefona { get; set; }
        public String napomena { get; set; }
        public String duzinaRute { get; set; }
        public GlavnaMusterijeVM pvm;

        public KontaktiranjeTaksijaVM(GlavnaMusterijeVM prijavaVM)
        {
            podaci = prijavaVM.podaci;
            PosaljiZahtjev = new RelayCommand<object>(naruci, mozen);
            this.pvm = prijavaVM;
        }

        public async void IspisiErrore(String errori)
        {
            var raz = new MessageDialog(errori);
            await raz.ShowAsync();
        }

        private bool provjeriJeLiBroj(String s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9') return false;
            }
            return true;
        }
        Vozac v1;
        public void naruci(object o)
        {
            String errori = "";
            if (ime == null || ime == "")
            {
                errori += "Neispravno ime ";
            }
            if (prezime == null || prezime == "")
            {
                errori += "Neispravno prezime ";
            }
            if (brojtelefona == null || brojtelefona == "")
            {
                errori += "Neispravan broj telefona ";
            }
            if (!provjeriJeLiBroj(brojtelefona))
            {
                errori += "Broj telefona iskljucivo treba da sadrzi samo cifre";
            }

            if (errori != "")
            {
                IspisiErrore(errori);
            }
            else
            {
                // pristup bazi i unos u nju
                Ruta r = new Ruta();
                r.DuzinaRute = Convert.ToDouble(duzinaRute);
                // 60 km/h
                r.ProcjenjenoVrijeme = Convert.ToDouble(duzinaRute) / 60;

                Narudzba n = new Narudzba();

                n.DatumPrevoza = DateTime.Now;
                n.Napomene = napomena;
                n.Narucilac = pvm.regm;
                n.Ruta = r;

                foreach(Zaposlenik z in podaci.zaposlenici)
                {
                    if(z is Vozac)
                    {
                        Vozac v = (Vozac)z;
                        if (v.Slobodan == false)
                        {
                            v1 = v;
                            break;
                        }
                    }
                }

                if (v1==null)
                {
                    IspisiErrore("Nema slobodnih vozaca");
                }
                else
                {
                    //v1.Slobodan = false;
                    n.Zaduzeni = v1;
                    podaci.narudzbe.Add(n);
                }

                // proc kroz bazu i pronaci prvog slobodnog vozaca i njega dodijeliti
                //n.Zaduzeni = v1;

                // dodati i rutu i narudzbu u bazu podataka
            }
        }
        public bool mozen(object o)
        {
            return true;
        }
    }
}
