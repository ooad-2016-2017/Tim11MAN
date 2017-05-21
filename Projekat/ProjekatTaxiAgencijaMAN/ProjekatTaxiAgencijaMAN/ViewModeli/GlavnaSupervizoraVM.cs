using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatTaxiAgencijaMAN.Pomocne;
using ProjekatTaxiAgencijaMAN.Modeli;
using ProjekatTaxiAgencijaMAN.forme;
using ProjekatTaxiAgencijaMAN.ViewModeli;

namespace ProjekatTaxiAgencijaMAN.ViewModeli
{
    class GlavnaSupervizoraVM
    {
        public ICommand registrujKompanijuS { get; set; }
        public ICommand registrujDispeceraS { get; set; }
        public ICommand registrujSupervizoraS { get; set; }
        NavigationService nservice;
        public PrijavaVM prijavaVM;
        ProjekatTaxiAgencijaMAN.Modeli.Supervizor regm;

        public GlavnaSupervizoraVM(PrijavaVM prijavaVM)
        {
            this.prijavaVM = prijavaVM;
            regm = prijavaVM.supervizorIzPrijave;
            registrujKompanijuS = new RelayCommand<object>(registrujk, provjerareg);
            registrujDispeceraS = new RelayCommand<object>(registrujd, provjeraregd);
            registrujSupervizoraS = new RelayCommand<object>(registrujs, provjeraregs);
            nservice = new NavigationService();
        }

        public bool provjerareg(object o)
        {
            return true;
        }
        public bool provjeraregd(object o)
        {
            return true;
        }
        public bool provjeraregs(object o)
        {
            return true;
        }

        public void registrujk(object o)
        {
            nservice.Navigate(typeof(RegistracijaKompanije), new RegistracijaKompanijeVM());
        }

        public void registrujd(object o)
        {
            nservice.Navigate(typeof(RegistracijaSupervizoraIliDispecera), new ProjekatTaxiAgencijaMAN.ViewModeli.RegistracijaDispeceraIliSupervizora());
        }
        public void registrujs(object o)
        {
            nservice.Navigate(typeof(RegistracijaSupervizoraIliDispecera), new ProjekatTaxiAgencijaMAN.ViewModeli.RegistracijaDispeceraIliSupervizora());
        }
    }
}
