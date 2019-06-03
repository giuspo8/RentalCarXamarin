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
	public partial class ScriviProblemi : ContentPage
	{
		public ScriviProblemi ()
		{
			InitializeComponent ();
		}

        public async void backToHomeButton(object sender, EventArgs e)
        {
            await this.Navigation.PopToRootAsync();
        }
        public void sendProblemButton(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(editor.Text))
            {
                DisplayAlert("Attenzione", "Per favore inserisci il tuo problema", "OK");
            }
            else {
                send_problem(new ServerRequest("http://rentalcar.altervista.org/inserisci_problemi.php"));
            }
            
        }

        public async void send_problem (ServerRequest sr)
        {
            string URL_Param = "?Problema=" + editor.Text;
            var response = await sr._client.GetAsync(sr.URL + URL_Param);
            if (response.IsSuccessStatusCode)
            {
                string responseText = response.Content.ReadAsStringAsync().Result.ToString();
                Insert_Result(responseText);
            }
            else
            {
                //Debug.WriteLine("Error while inserting User in Post mode");
            }
        }

        public async void Insert_Result(string ans)
        {
            if (ans == "1")
            {
                DisplayAlert("Risultato inserimento", "La segnalazione è stata inviata", "OK");
            }
            else
            {
                DisplayAlert("Risultato inserimento", "Inserimento errato. Check your query", "OK");
            }
            Task.Delay(2000);
            await this.Navigation.PopToRootAsync();
        }
    }
}