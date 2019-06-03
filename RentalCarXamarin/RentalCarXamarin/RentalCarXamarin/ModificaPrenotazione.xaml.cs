using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentalCarXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ModificaPrenotazione : ContentPage
	{
		public ModificaPrenotazione ()
		{
			InitializeComponent ();
		}

        public async void backToHomeButton(object sender, EventArgs e)
        {
            //toglie le pagine dallo stack e va alla home
            await this.Navigation.PopToRootAsync();
        }

        public async void searchButton(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(emailEntry.Text) || string.IsNullOrEmpty(idEntry.Text))
            {
                await DisplayAlert("Attenzione", "Per favore riempire tutti i campi", "OK");
            }
            else {
                //trasforma l'id letto come stringa dall'entry in un int
                int id = Int32.Parse(idEntry.Text);
                String email = emailEntry.Text;
                if (email.Contains("@") && email.Contains(".") && !(email.Contains(" ")) && !(email.Contains("\"")))
                {
                    search_reservation(new ServerRequest("http://rentalcar.altervista.org/cerca_prenotazione.php"), email, id);
                }
                else
                {
                    await DisplayAlert("Errore", "Email non corretta", "OK");
                }
            }
        }

        public async void ReservationTapped(object sender, ItemTappedEventArgs e)
        {
            Reservation item = (Reservation)e.Item;
            //chiama un alert e si salva la sua risposta in un bool
            bool answer=await DisplayAlert("Attenzione", "Vuoi cancellare la prenotazione?", "Si", "No");
            //se la risposta è si cancella la prenotazione
            if (answer)
            {
                delete_reservation(new ServerRequest("http://rentalcar.altervista.org/elimina_prenotazioni.php"),
                    item.Email,item.ID);
            }
            

        }

        public async void search_reservation(ServerRequest sr, String email, int id)
        {

            string URL_Param = "?Email=" + email + "&ID=" + id;
            var response = await sr._client.GetAsync(sr.URL + URL_Param);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                if (result.Equals("[]"))
                {
                    await DisplayAlert("Attenzione", "L'Email o l'ID immessi non corrispondono ad alcuna prenotazione", "OK");
                }
                else
                {
                    Dictionary<String, Reservation> result_reservation = JsonConvert.DeserializeObject<Dictionary<String, Reservation>>(result);
                    List<Reservation> prenotationList = new List<Reservation>();

                    foreach (KeyValuePair<String, Reservation> entry in result_reservation)
                    {
                        prenotationList.Add(new Reservation(entry.Value.ID,
                            entry.Value.StazioneRit,
                            entry.Value.StazioneRic,
                            entry.Value.Macchina,
                            entry.Value.DataRitiro,
                            entry.Value.DataRestituzione,
                            entry.Value.Pagamento,
                            entry.Value.Email,
                            entry.Value.Prezzo));
                    }
                    listViewReservation.ItemsSource = prenotationList;
                }
            }
            else { await DisplayAlert("Attenzione", "Nothing retrieved from the server", "OK"); }

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