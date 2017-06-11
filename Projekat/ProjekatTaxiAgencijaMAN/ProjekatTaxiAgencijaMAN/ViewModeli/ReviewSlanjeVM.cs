using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatTaxiAgencijaMAN.Pomocne;
using ProjekatTaxiAgencijaMAN.Modeli;
using System.ComponentModel;

namespace ProjekatTaxiAgencijaMAN.ViewModeli
{
    class ReviewSlanjeVM: INotifyPropertyChanged
    {
        DPodaci podaci;
        public ICommand posaljiB { get; set; }
        public ICommand odustaniB { get; set; }
        public string misljenje { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Promjena(String s)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(s));
            }
        }

        public ReviewSlanjeVM(GlavnaMusterijeVM gmvm)
        {
            podaci = gmvm.podaci;
            posaljiB = new RelayCommand<object>(slanjereview, provjera);
            odustaniB = new RelayCommand<object>(odustanireview, odustaniOK);
        }

        public void odustanireview(object o)
        {
            misljenje = "";
            Promjena("misljenje");
        }

        public bool odustaniOK(object o)
        {
            return true;
        }

        public bool provjera(object o)
        {
            return true;
        }
        public void slanjereview(object o)
        {
            // samo dodat misljenje u bazu podataka
            // fali dio za bazu podataka

            Reviewovi r = new Reviewovi();
            r.Misljenje = misljenje;

            podaci.reviewovi.Add(r);
        }
    }
}
