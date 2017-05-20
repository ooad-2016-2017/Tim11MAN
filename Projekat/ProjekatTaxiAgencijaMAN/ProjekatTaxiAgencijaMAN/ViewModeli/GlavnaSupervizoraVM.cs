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
    class GlavnaSupervizoraVM
    {
        ICommand registrujKompanijuS;
        NavigationService nservice;
        public PrijavaVM prijavaVM;
        ProjekatTaxiAgencijaMAN.Modeli.Supervizor regm;

        public GlavnaSupervizoraVM(PrijavaVM prijavaVM)
        {
            this.prijavaVM = prijavaVM;
            regm = prijavaVM.supervizorIzPrijave;
            registrujKompanijuS = new RelayCommand<object>(registrujk, provjerareg);
            nservice = new NavigationService();
        }

        public bool provjerareg(object o)
        {
            return true;
        }

        public void registrujk(object o)
        {
            nservice.Navigate(typeof(ProjekatTaxiAgencijaMAN.forme.RegistracijaKompanije), new RegistracijaKompanijeVM());
        }
    }
}
