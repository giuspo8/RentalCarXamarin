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
    public partial class SceltaAuto : ContentPage
    {

        public SceltaAuto()
        {
            InitializeComponent();
            BindingContext = new CarChoosingModel();

        }

        //parte da spostare in un'altro file eventualmente
        public class Car : BindableObject
        {
            //definiamo la classe car che estende la classe BindableObject 
            //e quindi ci abilita a sincronizzare i dati
            //di seguito le properties della classe Car
            public String image { get; set; }
            public String model { get; set; }
            public String type { get; set; }
            public String shift { get; set; }
            public int numberOfPassengers { get; set; }
            public double price { get; set; }
        }

        //metodo per gestire il click su un elemento della lista
        public async void CarTapped (object sender,ItemTappedEventArgs e)
        {
            //creiamo un oggetto di Car a partire dall'elemento cliccato
            Car item = (Car)e.Item;
            //salviamo tutti i suoi attributi sul dizionario Properties
            Application.Current.Properties["image"] = item.image;
            Application.Current.Properties["model"] = item.model;
            Application.Current.Properties["type"] = item.type;
            Application.Current.Properties["shift"] = item.shift;
            Application.Current.Properties["numberOfPassengers"] = item.numberOfPassengers;
            Application.Current.Properties["price"] = item.price;
            //passiamo alla prossima Page
            await this.Navigation.PushAsync(new RiepilogoPrenotazione());
        }

        public class CarChoosingModel : BindableObject
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
            public CarChoosingModel()
            {
                
                //associamo alla lista i valori che dovremo ottenere dal server

                CarItems = new List<Car> {

                new Car {image = "cinquecento.png", model = "Fiat Cinquecento", type="Economy", shift="manuale",numberOfPassengers=5,price=100.00},

                new Car {image = "clio.png", model = "Renault Clio", type="Compatta", shift="manuale",numberOfPassengers=5,price=100.00},

                new Car {image = "golf.png", model = "Volswagen Golf", type="Luxury", shift="automatico",numberOfPassengers=5,price=100.00}

            };


            }
        }
    }
}