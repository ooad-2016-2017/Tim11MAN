using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatTaxiAgencijaMAN.Pomocne;
using ProjekatTaxiAgencijaMAN.Modeli;

namespace ProjekatTaxiAgencijaMAN.ViewModeli
{
    class GlavnaDispeceraVM
    {
        public ICommand KontaktiranjeVozacaD { get; set; }
        public ICommand ProvjeraVozilaD { get; set; }
        NavigationService nservice;
        public PrijavaVM prijavaVM;
        ProjekatTaxiAgencijaMAN.Modeli.Dispecer regm;

        public GlavnaDispeceraVM(PrijavaVM prijavaVM)
        {
            this.prijavaVM = prijavaVM;
            regm = prijavaVM.dispecerIzPrijave;
            KontaktiranjeVozacaD = new RelayCommand<object>(kontaktiranjevozaca, provjerakontaktiranjevozaca);
            ProvjeraVozilaD = new RelayCommand<object>(provjeravozila, provjeraprovjeravozila);
            nservice = new NavigationService();
        }

        public bool provjerakontaktiranjevozaca(object o)
        {
            return true;
        }
        public bool provjeraprovjeravozila(object o)
        {
            return true;
        }

        public void kontaktiranjevozaca(object o)
        {
            nservice.Navigate(typeof(ProjekatTaxiAgencijaMAN.forme.KontaktiranjeVozaca), new KontaktiranjeVozacaVM());
        }

        public void provjeravozila(object o)
        {
            nservice.Navigate(typeof(ProjekatTaxiAgencijaMAN.UvidKompanijeUVozila), new ProjekatTaxiAgencijaMAN.ViewModeli.UvidUVozila());
        }
    }
}
