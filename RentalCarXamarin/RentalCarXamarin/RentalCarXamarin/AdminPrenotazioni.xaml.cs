using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Newtonsoft.Json;
using Xamarin.Forms.Xaml;

namespace RentalCarXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdminPrenotazioni : ContentPage
	{
		public AdminPrenotazioni ()
		{
			InitializeComponent ();
            getReservations(new ServerRequest("http://rentalcar.altervista.org/leggi_prenotazioni.php"));
		}

        public async void getReservations(ServerRequest sr)
        {
            var response = await sr._client.GetAsync(sr.URL);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                Dictionary<string, Reservation> result_reservations = JsonConvert.DeserializeObject<Dictionary<string, Reservation>>(result);
                List<Reservation> reservationsList = new List<Reservation>();

                foreach (KeyValuePair<string, Reservation> entry in result_reservations)
                {
                    reservationsList.Add(new Reservation(entry.Value.ID, entry.Value.StazioneRit, entry.Value.StazioneRic,
                    entry.Value.Macchina, entry.Value.DataRitiro, entry.Value.DataRestituzione,
                    entry.Value.Pagamento,entry.Value.Email,entry.Value.Prezzo));
                }
                listView.ItemsSource = reservationsList;
            }
            else { await DisplayAlert("Attenzione", "Nothing retrieved from the server", "OK"); }

        }

        public async void TappedReservation(object sender, ItemTappedEventArgs e)
        {
            Reservation item = (Reservation)e.Item;
            bool answer = await DisplayAlert("Attenzione", "Vuoi cancellare la prenotazione?", "Si", "No");
            if (answer)
            {
                delete_reservation(new ServerRequest("http://rentalcar.altervista.org/elimina_prenotazioni.php"),
                    item.Email, item.ID);
            }
        }

        public async void delete_reservation(ServerRequest sr, String email, int id)
        {

            string URL_Param = "?Email=" + email + "&ID=" + id;
            var response = await sr._client.GetAsync(sr.URL + URL_Param);
            if (response.IsSuccessStatusCode)
            {
                string responseText = response.Content.ReadAsStringAsync().Result.ToString();
                Delete_Result(responseText);
            }
            else { await DisplayAlert("Attenzione", "Nothing retrieved from the server", "OK"); }

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