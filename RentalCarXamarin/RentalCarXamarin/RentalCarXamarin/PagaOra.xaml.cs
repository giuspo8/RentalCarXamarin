using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentalCarXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PagaOra : ContentPage
	{
        Boolean payment = (Boolean)Application.Current.Properties["payment"];
        public PagaOra ()
		{
			InitializeComponent ();
            //se non paghiamo ora mette alcuni campi invisibili
            if (!payment)
            {
                CartaCredito.IsVisible = false;
                DataScadenza.IsVisible = false;
                CodiceSicurezza.IsVisible = false;
            }
		}
        
 

        public async void ConfirmButton(object sender, EventArgs e)
        {
            //se c'è qualche campo vuoto ti avverte dell'errore
            if (string.IsNullOrEmpty(name.Text) || string.IsNullOrEmpty(surname.Text) ||
                    string.IsNullOrEmpty(emailEntry.Text) || string.IsNullOrEmpty(phone.Text))
            {
                await DisplayAlert("Attenzione", "Per favore riempire tutti i campi", "OK");
            }
            else if(payment&&(string.IsNullOrEmpty(CartaCredito.Text) || string.IsNullOrEmpty(DataScadenza.Text) ||
                    string.IsNullOrEmpty(CodiceSicurezza.Text)))
            {
                await DisplayAlert("Attenzione", "Per favore riempire tutti i campi", "OK");
            }
            else
            {
            
                //mi prendo tutti i valori e teoricamente dovrei salvarli sul server
                //per ora li salvo in properties
                String fName = name.Text;
                String sName = surname.Text;
                String email = emailEntry.Text;
                String telephone = phone.Text;
                Application.Current.Properties["name"] = fName;
                Application.Current.Properties["surname"] = sName;
                Application.Current.Properties["email"] = email;
                Application.Current.Properties["phone"] = telephone;
                //va alla pagina finale
                await this.Navigation.PushAsync(new ConfermaEmail());
            }
        }
    }
}