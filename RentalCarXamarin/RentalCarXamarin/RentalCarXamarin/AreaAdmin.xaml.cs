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
	public partial class AreaAdmin : ContentPage
	{
        
		public AreaAdmin ()
		{
			InitializeComponent ();
		}

        public void adminReservationsButton(object sender, EventArgs e)
        {
            check_admin(new ServerRequest("http://rentalcar.altervista.org/leggiAdmin.php"),0);

        }

        public  void adminCarButton(object sender, EventArgs e)
        {
            check_admin(new ServerRequest("http://rentalcar.altervista.org/leggiAdmin.php"),1);
      
            
        }

        public async void adminStationsButton(object sender, EventArgs e)
        {
            check_admin(new ServerRequest("http://rentalcar.altervista.org/leggiAdmin.php"),2);

            
        }

        public async void backToHomeButton(object sender, EventArgs e)
        {
            //toglie tutte le pagine dallo stack e va alla pagina iniziale
            await this.Navigation.PopToRootAsync();
        }

        public async void check_admin(ServerRequest sr,int which)
        {
            string URL_Param = "?email=" +emailEntry.Text  + "&password=" + passwordEntry.Text;
            var response = await sr._client.PostAsync(sr.URL + URL_Param, null);
            if (response.IsSuccessStatusCode)
            {
                string responseText = response.Content.ReadAsStringAsync().Result.ToString();
                if (responseText.Equals("[]"))
                {
                    await DisplayAlert("Attenzione", "L'email o la password inserite sono errate", "OK");
                }
                else
                {
                    switch (which)
                    {
                        case 0: await this.Navigation.PushAsync(new AdminPrenotazioni());
                            break;
                        case 1: await this.Navigation.PushAsync(new AdminAuto());
                            break;
                        case 2: await this.Navigation.PushAsync(new AdminStazioni());
                            break;
                    }

                }
                
            }
            else
            {
                //Debug.WriteLine("Error while inserting User in Post mode");
            }
        }
    }
}