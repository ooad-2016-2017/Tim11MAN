using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatTaxiAgencijaMAN.Pomocne;
using ProjekatTaxiAgencijaMAN.Modeli;
using System.ComponentModel;
using Windows.UI.Popups;

namespace ProjekatTaxiAgencijaMAN.ViewModeli
{
    class KontaktiranjeVozacaVM: INotifyPropertyChanged
    {
        DPodaci podaci;
        public ICommand PretraziVozaca { get; set; }
        public String brojTelefonaVozaca { get; set; }
        public String id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Promjena(String s)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(s));
            }
        }

        public KontaktiranjeVozacaVM(GlavnaDispeceraVM gdvm)
        {
            podaci = gdvm.podaci;
            PretraziVozaca = new RelayCommand<object>(kontaktiranje, mozekontaktiranje);
        }

        public bool mozekontaktiranje(object o)
        {
            return true;
        }

        public async void IspisError(string error)
        {
            var raz = new MessageDialog(error);
            await raz.ShowAsync();
        }

        public bool provjeriid(String id)
        {
            if (id == null) return false;
            for (int i = 0; i < id.Length; i++)
                if (id[i] < '0' || id[i] > '9') return false;
            return true;
        }

        public void kontaktiranje(object o)
        {

            var baza = new TaxiDbContext();

            if (!provjeriid(id))
            {
                // obavijestiti da id nije uredu
                IspisError("Neispravan ID");
            }
            else
            {
                bool provjera1 = false;

                // NE RADI
                if (false)
                {
                    // OVO NE RADI!!!
                    // proci kroz vozace i provjeriti ima li vozaca sa ovim id ako nema obavijestiti
                    foreach (var vozac in baza.vozaci)
                    {
                        if (vozac.VozacId == Convert.ToInt32(id))
                        {
                            provjera1 = true;
                            // nastavak ...
                        }
                    }
                }
                // NE RADI

                foreach (Zaposlenik v in podaci.zaposlenici)
                {
                    if (v is Vozac)
                    {
                        Vozac v1 = (Vozac)v;
                        if (v1.VozacId == Convert.ToInt32(id))
                        {
                            provjera1 = true;
                            brojTelefonaVozaca = v1.BrojTelefona;
                        }
                    }
                }

                if (!provjera1)
                {
                    brojTelefonaVozaca = "";
                    IspisError("Nema vozaca sa ovim ID");
                }

                Promjena("brojTelefonaVozaca");
            }

        }
    }
}
