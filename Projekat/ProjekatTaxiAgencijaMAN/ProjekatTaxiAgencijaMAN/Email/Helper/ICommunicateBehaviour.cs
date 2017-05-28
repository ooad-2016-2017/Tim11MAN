using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;
using ProjekatTaxiAgencijaMAN.Modeli;

namespace ProjekatTaxiAgencijaMAN.Email.Helper
{
    //behaviour za strategy pattern
    public interface ICommunicateBehaviour
    {
        //glavno ponasanje koje obavi komunikaciju sa kontaktom
        void Communicate(List<RegistrovanaMusterija> lista);  // kad se ubaci tabela parametar ce biti tipa DbSet
        //vraca koji je trenutni behaviour naziv njegov za UI
        string dajMetodKomunikacije();
    }
}
