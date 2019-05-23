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
	public partial class AdminStazioni : ContentPage
	{
		public AdminStazioni ()
		{
			InitializeComponent ();
		}

        public async void backButton(object sender, EventArgs e)
        {
            //al click del bottone va ad AreaAdmin
            await this.Navigation.PushAsync(new Admin_buttons());
        }

        public async void aggiungiStazioneButton(object sender, EventArgs e)
        {
            if (stationEntry.Text.Equals(""))
            {
                await DisplayAlert("Attenzione", "Per favore inserisci la stazione da inserire", "OK");
            }
            else
            {
                String stazione = stationEntry.Text;
                addStation(new ServerRequest("http://rentalcar.altervista.org/aggiungi_stazioni.php"), stazione);
            }
        }

        public async void rimuoviStazioneButton(object sender, EventArgs e)
        {
            if (stationEntry.Text.Equals(""))
            {
                await DisplayAlert("Attenzione", "Per favore inserisci la stazione da cancellare", "OK");
            }
            else
            {
                String stazione = stationEntry.Text;
                removeStation(new ServerRequest("http://rentalcar.altervista.org/elimina_stazioni.php"), stazione);
            }
        }

        public async void addStation(ServerRequest sr, String station)
        {

            string URL_Param = "?NomeStazione=" + station;
            var response = await sr._client.GetAsync(sr.URL + URL_Param);
            if (response.IsSuccessStatusCode)
            {
                string responseText = response.Content.ReadAsStringAsync().Result.ToString();
                Insert_Result(responseText);
            }
            else { await DisplayAlert("Attenzione", "Nothing retrieved from the server", "OK"); }

        }

        public async void removeStation(ServerRequest sr, String station)
        {

            string URL_Param = "?NomeStazione=" + station;
            var response = await sr._client.GetAsync(sr.URL + URL_Param);
            if (response.IsSuccessStatusCode)
            {
                string responseText = response.Content.ReadAsStringAsync().Result.ToString();
                Delete_Result(responseText);
            }
            else { await DisplayAlert("Attenzione", "Nothing retrieved from the server", "OK"); }

        }

        public void Insert_Result(string ans)
        {
            if (ans == "1")
            {
                DisplayAlert("Risultato inserimento", "Inserimento effettuato", "OK");
            }
            else
            {
                DisplayAlert("Risultato inserimento", "Inserimento errato. Check your query", "OK");
            }
        }

        public void Delete_Result(string ans)
        {
            if (ans == "1")
            {
                DisplayAlert("Risultato cancellazione", "Cancellazione effettuata", "OK");
            }
            else
            {
                DisplayAlert("Risultato cancellazione", "Cancellazione errata. Check your query", "OK");
            }
        }
    }
}