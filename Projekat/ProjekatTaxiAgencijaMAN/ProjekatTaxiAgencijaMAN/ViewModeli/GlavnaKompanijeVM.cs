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
    class GlavnaKompanijeVM
    {
        public DPodaci podaci;
        public ICommand RegistracijaVozaca { get; set; }
        public ICommand BrisanjeVozacaB { get; set; }
        public ICommand UvidUVozace { get; set; }
        public ICommand UvidUVozila { get; set; }
        NavigationService nservice;
        public PrijavaVM prijavaVM;
        public Kompanija regm;
        public String NazivKompanijeRegK { get; set; }
        public String AdresaKompanijeRegK { get; set; }

        public GlavnaKompanijeVM(PrijavaVM prijavaVM)
        {
            this.prijavaVM = prijavaVM;
            podaci = prijavaVM.podaci;
            regm = prijavaVM.kompanijaIzPrijave;
            NazivKompanijeRegK = regm.NazivKompanije;
            AdresaKompanijeRegK = regm.AdresaKompanije;
            RegistracijaVozaca = new RelayCommand<object>(registrujvozaca, provjeraregistracije);
            UvidUVozace = new RelayCommand<object>(uviduvozace, provjerauvidauvozace);
            UvidUVozila = new RelayCommand<object>(uviduvozila, provjerauviduvozila);
            BrisanjeVozacaB = new RelayCommand<object>(brisanjevozaca, brisanjeOK);
            nservice = new NavigationService();
        }

        public bool provjeraregistracije(object o)
        {
            return true;
        }
        public bool provjerauvidauvozace(object o)
        {
            return true;
        }
        public bool provjerauviduvozila(object o)
        {
            return true;
        }

        public bool brisanjeOK(object o)
        {
            return true;
        }

        public void registrujvozaca(object o)
        {
            nservice.Navigate(typeof(ProjekatTaxiAgencijaMAN.RegistracijaVozaca), new RegistracijaVozacaVM(this));
        }

        public void uviduvozace(object o)
        {
            nservice.Navigate(typeof(ProjekatTaxiAgencijaMAN.forme.UvidKompanijeUVozace), new UvidUVozace(this));
        }

        public void uviduvozila(object o)
        {
            nservice.Navigate(typeof(ProjekatTaxiAgencijaMAN.forme.UvidKompanijeUVozila), new UvidUVozila(this));
        }

        public void brisanjevozaca(object o)
        {
            nservice.Navigate(typeof(ProjekatTaxiAgencijaMAN.forme.BrisanjeVozaca), new BrisanjeVozacaVM(this));
        }
    }
}
