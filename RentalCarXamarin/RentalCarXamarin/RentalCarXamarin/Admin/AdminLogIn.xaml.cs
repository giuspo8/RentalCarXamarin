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
	public partial class AdminLogIn : ContentPage
	{
		public AdminLogIn ()
		{
			InitializeComponent ();
		}

        public void adminloginButton(object sender, EventArgs e)
        {
            check_admin(new ServerRequest("http://rentalcar.altervista.org/leggiAdmin.php"));

        }

        public async void backToHomeButton(object sender, EventArgs e)
        {
            //toglie tutte le pagine dallo stack e va alla pagina iniziale
            await this.Navigation.PopToRootAsync();
        }

        public async void check_admin(ServerRequest sr)
        {
            string URL_Param = "?email=" + emailEntry.Text + "&password=" + passwordEntry.Text;
            String a = emailEntry.Text;
            String p = passwordEntry.Text;
            if (a.Contains("@") && a.Contains(".") && !(a.Contains(" ")) && !(a.Contains("\"")))
            {
                if (!p.Contains(" ") && !p.Contains("\""))
                    {
                    var response = await sr._client.GetAsync(sr.URL + URL_Param);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = response.Content.ReadAsStringAsync().Result.ToString();
                        //se la query ci da in risposta l'insieme vuoto
                        if (responseText.Equals("[]"))
                        {
                            await DisplayAlert("Attenzione", "L'email o la password inserite sono errate", "OK");
                        }
                        else
                        {
                            await this.Navigation.PushAsync(new Admin_buttons());
                        }
                    }
                    else
                    {
                        //Debug.WriteLine("Error while inserting User in Post mode");
                    }
                }
                else
                    await DisplayAlert("Attenzione", "Formato Password non valido", "OK");

            }
            else
            {
                await DisplayAlert("Attenzione", "Formato Email non valido", "OK");
            }

            
        }
    }
}