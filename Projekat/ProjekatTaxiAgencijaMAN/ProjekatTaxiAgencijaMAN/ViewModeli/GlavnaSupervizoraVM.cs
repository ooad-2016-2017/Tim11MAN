using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatTaxiAgencijaMAN.Pomocne;
using ProjekatTaxiAgencijaMAN.Modeli;
using ProjekatTaxiAgencijaMAN.forme;
using ProjekatTaxiAgencijaMAN.Email.Helper;
using ProjekatTaxiAgencijaMAN.ViewModeli;
using Windows.ApplicationModel.Contacts;
using Microsoft.Data.Entity;

namespace ProjekatTaxiAgencijaMAN.ViewModeli
{
    class GlavnaSupervizoraVM
    {
        public ICommand registrujKompanijuS { get; set; }
        public ICommand registrujDispeceraS { get; set; }
        public ICommand registrujSupervizoraS { get; set; }
        public ICommand Email { get; set; }
        Contact trenutniKontak;
        NavigationService nservice;
        EmailCommunicateBehaviour eservice;
        public PrijavaVM prijavaVM;

        List<RegistrovanaMusterija> lista;
        DbSet<Musterija> korisnici;
      
        
        ProjekatTaxiAgencijaMAN.Modeli.Supervizor regm;

        public GlavnaSupervizoraVM(PrijavaVM prijavaVM)
        {
            this.prijavaVM = prijavaVM;
            regm = prijavaVM.supervizorIzPrijave;
            registrujKompanijuS = new RelayCommand<object>(registrujk, provjerareg);
            registrujDispeceraS = new RelayCommand<object>(registrujd, provjeraregd);
            registrujSupervizoraS = new RelayCommand<object>(registrujs, provjeraregs);
            Email = new RelayCommand<object>(sendEmail);
            trenutniKontak = new Contact();

            lista = new List<RegistrovanaMusterija>(); // ovo je samo za testiranje, kad se ubaci tabela u migration promijeniti da parametar u sendEmail bude DbSet
           
            var db = new TaxiDbContext();
            korisnici = db.musterije;

            nservice = new NavigationService();
            eservice = new EmailCommunicateBehaviour();
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

        public void sendEmail(object o)
        {
            eservice.Communicate(lista); // kad se ubaci tabela parametar ce biti tipa DbSet
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
