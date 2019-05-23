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
    public partial class AdminAuto : ContentPage
    {
        public AdminAuto()
        {
            InitializeComponent();
        }

        public async void backButton(object sender, EventArgs e)
        {
            //al click del bottone backbutton va ad AreaAdmin
            await this.Navigation.PushAsync(new Admin_buttons());
        }

        public async void insertCarButton(object sender, EventArgs e)
        {
            if (modelloEntry.Text.Equals("")|| classeEntry.Text.Equals("") || cambioEntry.Text.Equals("") ||
                numeroEntry.Text.Equals("") || prezzoEntry.Text.Equals(""))
            {
                await DisplayAlert("Attenzione", "Per favore riempire tutti i campi", "OK");
            }
            else
            {
                String model = modelloEntry.Text;
                String classCar = classeEntry.Text;
                String shift = cambioEntry.Text;
                int number = Int32.Parse(numeroEntry.Text);
                Double price = Double.Parse(prezzoEntry.Text);
                insertCar(new ServerRequest("http://rentalcar.altervista.org/aggiungi_auto.php"), model,
                    classCar,shift,number,price);
            }
        }

        public async void deleteCarButton(object sender, EventArgs e)
        {
            if (modelloEntry.Text.Equals(""))
                {
                    await DisplayAlert("Attenzione", "Per favore inserire il modello da rimuovere", "OK");
                }
            else
            {
                String model = modelloEntry.Text;
                deleteCar(new ServerRequest("http://rentalcar.altervista.org/elimina_auto.php"), model);
            }
        }

        public async void deleteCar(ServerRequest sr, String model)
        {

            string URL_Param = "?Modello=" + model;
            var response = await sr._client.GetAsync(sr.URL + URL_Param);
            if (response.IsSuccessStatusCode)
            {
                string responseText = response.Content.ReadAsStringAsync().Result.ToString();
                Delete_Result(responseText);
            }
            else { await DisplayAlert("Attenzione", "Nothing retrieved from the server", "OK"); }

        }

        public async void insertCar(ServerRequest sr, String model,String classCar,String shift,int number,double price)
        {

            string URL_Param = "?Modello=" + model+ "&Classe=" + classCar+ "&PrezzoGg=" + price+
                "&Cambio=" + shift+ "&NrPasseggeri=" + number;
            var response = await sr._client.GetAsync(sr.URL + URL_Param);
            if (response.IsSuccessStatusCode)
            {
                string responseText = response.Content.ReadAsStringAsync().Result.ToString();
                Insert_Result(responseText);
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
    }
}