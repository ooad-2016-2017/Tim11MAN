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
    class GlavnaKompanijeVM
    {
        ICommand RegistracijaVozaca;
        ICommand UvidUVozace;
        ICommand UvidUVozila;
        NavigationService nservice;
        public PrijavaVM prijavaVM;
        Kompanija regm;
        public String NazivKompanijeRegK { get; set; }
        public String AdresaKompanijeRegK { get; set; }

        public GlavnaKompanijeVM(PrijavaVM prijavaVM)
        {
            this.prijavaVM = prijavaVM;
            regm = prijavaVM.kompanijaIzPrijave;
            NazivKompanijeRegK = regm.NazivKompanije;
            AdresaKompanijeRegK = regm.AdresaKompanije;
            RegistracijaVozaca = new RelayCommand<object>(registrujvozaca, provjeraregistracije);
            UvidUVozace = new RelayCommand<object>(uviduvozace, provjerauvidauvozace);
            UvidUVozila = new RelayCommand<object>(uviduvozila, provjerauviduvozila);
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

        public void registrujvozaca(object o)
        {
            nservice.Navigate(typeof(ProjekatTaxiAgencijaMAN.forme.RegistracijaVozaca), new RegistracijaVozacaVM(this));
        }

        public void uviduvozace(object o)
        {
            nservice.Navigate(typeof(ProjekatTaxiAgencijaMAN.forme.UvidKompanijeUVozace), new UvidUVozace());
        }

        public void uviduvozila(object o)
        {
            nservice.Navigate(typeof(ProjekatTaxiAgencijaMAN.forme.UvidKompanijeUVozila), new UvidUVozila());
        }
    }
}
