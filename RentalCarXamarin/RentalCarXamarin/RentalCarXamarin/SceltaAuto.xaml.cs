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
    public partial class SceltaAuto : ContentPage
    {
        public SceltaAuto()
        {
            InitializeComponent();
            getCar(new ServerRequest("http://rentalcar.altervista.org/leggi_auto.php"));
        }

        //metodo per gestire il click su un elemento della lista
        public async void CarTapped (object sender,ItemTappedEventArgs e)
        {
            //creiamo un oggetto di Car a partire dall'elemento cliccato
            CarItem item = (CarItem)e.Item;
            //salviamo tutti i suoi attributi sul dizionario Properties
            Application.Current.Properties["image"] = item.Image;
            Application.Current.Properties["model"] = item.Model;
            Application.Current.Properties["type"] = item.ClassCar;
            Application.Current.Properties["shift"] = item.Shift;
            Application.Current.Properties["numberOfPassengers"] = item.Number;
            Application.Current.Properties["price"] = item.Pricegg;
            //passiamo alla prossima Page
            await this.Navigation.PushAsync(new RiepilogoPrenotazione());
        }
       

            public async void getCar(ServerRequest sr)
            {
                var response = await sr._client.GetAsync(sr.URL);
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    Dictionary<string, CarItem> result_car = JsonConvert.DeserializeObject<Dictionary<string, CarItem>>(result);
                   List<CarItem> cars = new List<CarItem>();

                foreach (KeyValuePair<string, CarItem> entry in result_car)
                    {
                            cars.Add(new CarItem (entry.Value.Model,entry.Value.Shift,entry.Value.ClassCar,
                            entry.Value.Number,entry.Value.Pricegg,entry.Value.Image));
                    }
                listView.ItemsSource = cars;
                }
                else { await DisplayAlert("Attenzione", "Nothing retrieved from the server", "OK"); }
                    
            }
            
    }
    

    }

