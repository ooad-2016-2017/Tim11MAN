using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;
using ProjekatTaxiAgencijaMAN.Modeli;
using Windows.Storage;

namespace ProjekatTaxiAgencijaMAN.Email.Helper
{
    public class EmailCommunicateBehaviour : ICommunicateBehaviour
    {
        String textPoruke = "Postovani";

        public async void Communicate(List<RegistrovanaMusterija> lista)  // kad se ubaci tabela parametar ce biti tipa DbSet
        {
           
            var emailMessage = new Windows.ApplicationModel.Email.EmailMessage();
 
            emailMessage.Body = textPoruke;         
        
            foreach(RegistrovanaMusterija kontakt in lista)
            {
              
                var emailRecipient = new Windows.ApplicationModel.Email.EmailRecipient(kontakt.EmailAdresa);
                emailMessage.To.Add(emailRecipient);
                
            }            
             await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(emailMessage);
           
        }

        public string dajMetodKomunikacije()
        {
            return "Email";
        }
    }
}
