using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatTaxiAgencijaMAN.Pomocne;
using System.ComponentModel;
using ProjekatTaxiAgencijaMAN.Modeli;
using Windows.UI.Popups;

namespace ProjekatTaxiAgencijaMAN.ViewModeli
{
    class BrisanjeVozacaVM : INotifyPropertyChanged
    {
        Kompanija regm;
        DPodaci podaci;
        public ObservableCollection<String> listaVozac { get; set; }
        public String pretrazi { get; set; }
        public ICommand PretraziV { get; set; }
        public ICommand ObrisiV { get; set; }

        public BrisanjeVozacaVM(GlavnaKompanijeVM gkvm)
        {
            regm = gkvm.regm;
            podaci = gkvm.podaci;
            PretraziV = new RelayCommand<object>(pretraziK, pretraziOK);
            ObrisiV = new RelayCommand<object>(obrisi, obrisiOK);
            listaVozac = new ObservableCollection<String>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Promjena(String s)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(s));
            }
        }

        public bool provjeriid(String id)
        {
            if (id == null) return false;
            for (int i = 0; i < id.Length; i++)
                if (id[i] < '0' || id[i] > '9') return false;
            return true;
        }

        public async void IspisError(string error)
        {
            var raz = new MessageDialog(error);
            await raz.ShowAsync();
        }

        int idZaBrisanje = -1;

        public void pretraziK(object o)
        {
            listaVozac.Clear();
            bool provjera1 = false;
            if (!provjeriid(pretrazi))
            {
                IspisError("Neispravan ID");
            }
            else
            {
                for (int i= 0; i < regm.ListaZaposlenika.Count(); i++)
                {
                    if (regm.ListaZaposlenika[i] is Vozac)
                    {
                        Vozac v1 = (Vozac)regm.ListaZaposlenika[i];
                        if (v1.VozacId == Convert.ToInt32(pretrazi))
                        {
                            provjera1 = true;
                            idZaBrisanje = i;
                            listaVozac.Add(v1.Ime + "\n");
                            listaVozac.Add(v1.Prezime + "\n");
                            if (v1.ListaDatumaVoznji != null)
                            {
                                listaVozac.Add(v1.ListaDatumaVoznji.Count.ToString() + "\n");
                            }
                            else
                            {
                                listaVozac.Add("Nema voznji" + "\n");
                            }
                            listaVozac.Add(v1.Vozilo.Predjenikilometri.ToString() + "\n");
                            listaVozac.Add(v1.Vozilo.RegistracijskeTablice + "\n");
                            
                        }
                    }
                }
                if (!provjera1)
                {
                    IspisError("Nema vozaca sa ovim ID");
                    listaVozac.Clear();
                }
                Promjena("listaVozaca");
            }
        }

        public bool pretraziOK(object o)
        {
            return true;
        }

        public void obrisi(object o)
        {
            if (idZaBrisanje != -1)
            {
                regm.ListaZaposlenika.RemoveAt(idZaBrisanje);
                listaVozac.Clear();
            }
            else
            {
                IspisError("Greska");
            }
        }

        public bool obrisiOK(object o)
        {
            return true;
        }

    }
}
