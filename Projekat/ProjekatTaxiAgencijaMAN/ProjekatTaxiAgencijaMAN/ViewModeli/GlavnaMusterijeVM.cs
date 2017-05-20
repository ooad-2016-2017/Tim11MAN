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
    class GlavnaMusterijeVM
    {
        ICommand KontaktiranjeTaksijaRegM;
        ICommand ReviewRegM;
        NavigationService nservice;
        public PrijavaVM prijavaVM;
        public RegistrovanaMusterija regm;
        public String ImeRegK { get; set; }
        public String PrezimeRegK { get; set; }

        public GlavnaMusterijeVM(PrijavaVM prijavaVM)
        {
            this.prijavaVM = prijavaVM;
            regm = prijavaVM.regmusterijaIzPrijave;
            ImeRegK = regm.ImeKorisnika;
            PrezimeRegK = regm.PrezimeKorisnika;
            KontaktiranjeTaksijaRegM = new RelayCommand<object>(kontaktiranjetaksija, provjerakontaktiranja);
            ReviewRegM = new RelayCommand<object>(review, provjerareview);
            nservice = new NavigationService();
        }

        public bool provjerakontaktiranja(object o)
        {
            return true;
        }
        public bool provjerareview(object o)
        {
            return true;
        }

        public void kontaktiranjetaksija(object o)
        {
            nservice.Navigate(typeof(ProjekatTaxiAgencijaMAN.forme.KontaktiranjeTaksija), new KontaktiranjeTaksijaVM(this));
        }

        public void review(object o)
        {
            nservice.Navigate(typeof(ProjekatTaxiAgencijaMAN.forme.ReviewSlanje), new ReviewSlanjeVM());
        }
    }
}
