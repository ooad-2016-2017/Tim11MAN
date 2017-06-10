using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatTaxiAgencijaMAN.Pomocne;
using ProjekatTaxiAgencijaMAN.Modeli;
using ProjekatTaxiAgencijaMAN.forme;

namespace ProjekatTaxiAgencijaMAN.ViewModeli
{
    class GlavnaMusterijeVM
    {
        public ICommand KontaktiranjeTaksijaRegM { get; set; }
        public ICommand ReviewRegM { get; set; }
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
            nservice.Navigate(typeof(KontaktiranjeTaksija), new KontaktiranjeTaksijaVM(this));
        }

        public void review(object o)
        {
            nservice.Navigate(typeof(ProjekatTaxiAgencijaMAN.ReviewSlanje), new ReviewSlanjeVM());
        }
    }
}
