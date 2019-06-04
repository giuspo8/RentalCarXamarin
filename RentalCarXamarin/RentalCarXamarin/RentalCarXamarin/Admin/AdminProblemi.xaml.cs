using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace RentalCarXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdminProblemi : ContentPage
	{
        public AdminProblemi()
        {
            InitializeComponent();
            getProblems(new ServerRequest("http://rentalcar.altervista.org/leggi_problemi.php"));
        }

        public async void getProblems(ServerRequest sr)
        {
            var response = await sr._client.GetAsync(sr.URL);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                Dictionary<string, Segnalazione> result_problems = JsonConvert.DeserializeObject<Dictionary<string, Segnalazione>>(result);
                List<Segnalazione> probl = new List<Segnalazione>();

                foreach (KeyValuePair<string, Segnalazione> entry in result_problems)
                {
                    probl.Add(new Segnalazione(entry.Value.Problema));
                }
                listView.ItemsSource = probl;
            }
            else { await DisplayAlert("Attenzione", "Nothing retrieved from the server", "OK"); }

        }
    }
}