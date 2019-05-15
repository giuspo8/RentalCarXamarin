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
    public partial class RiepilogoPrenotazione : ContentPage
    {
        public RiepilogoPrenotazione()
        {
            InitializeComponent();
            BindingContext = new CarChoosedModel();
        }
        

        //parte da spostare in un'altro file eventualmente
        public class Car : BindableObject
        {
            //definiamo la classe car che estende la classe BindableObject 
            //e quindi ci abilita a sincronizzare i dati
            //di seguito le properties della classe Car
            public String image {get; set; }
            public String model { get; set; }
            public String type { get; set; }
            public String shift { get; set; }
            public int numberOfPassengers { get; set; }
            public double price { get; set; }
        }

        public class CarChoosedModel : BindableObject
        {
            //altra classe che estende bindableobject
            //abbiamo una lista di Car
            List<Car> carItems;
            //nota bene CarItems con c maiuscolo. è la proprietà della variabile carItems
            //lo utilizziamo per fare get e set di carItems
            public List<Car> CarItems
            {
                get
                {
                    return carItems;
                }
                set
                {
                    carItems = value;//a carItems viene assegnato il valore passatogli con il set
                    //OnPropertyChanged semplicemente notifica che è avvenuta una modifica di CarItems
                    OnPropertyChanged("CarItems");
                }
            }

            //è il costruttore di CarChoosingModel
            public CarChoosedModel()
            {
                //ci riprendiamo tutti valori salvati nel dizionarioProperties
                var imageChoice = (String)Application.Current.Properties["image"];
                var modelChoice= (String)Application.Current.Properties["model"];
                var typeChoice= (String)Application.Current.Properties["type"];
                var shiftChoice= (String)Application.Current.Properties["shift"];
                var numberOfPassengersChoice= (int)Application.Current.Properties["numberOfPassengers"];
                var priceChoice = (double)Application.Current.Properties["price"];
                //associamo alla lista i valori creando un unico elemento che è quello scelto
                CarItems = new List<Car> {

                new Car {image = imageChoice, model = modelChoice, type=typeChoice, shift=shiftChoice,numberOfPassengers=numberOfPassengersChoice,price=priceChoice},

            };


            }
        }

        public async void paymentNowButton(object sender, EventArgs e)
        {
            Boolean paynow = true;
            Application.Current.Properties["payment"] = paynow;
            //va alla pagina per il pagamento
            await this.Navigation.PushAsync(new PagaOra());
        }

        public async void paymentLaterButton(object sender, EventArgs e)
        {
            Boolean paynow = false;
            Application.Current.Properties["payment"] = paynow;
            //va alla pagina per il pagamento
            await this.Navigation.PushAsync(new PagaOra());
        }
    }
}