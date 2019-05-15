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
            public String image {get; set; }
            public String model { get; set; }
            public String type { get; set; }
            public String shift { get; set; }
            public int numberOfPassengers { get; set; }
            public double price { get; set; }
        }

        public class CarChoosedModel : BindableObject
        {
            List<Car> carItems;
            public List<Car> CarItems
            {
                get
                {
                    return carItems;
                }
                set
                {
                    carItems = value;
                    OnPropertyChanged("CarItems");
                }
            }

            public CarChoosedModel()
            {
                var imageChoice = (String)Application.Current.Properties["image"];
                var modelChoice= (String)Application.Current.Properties["model"];
                var typeChoice= (String)Application.Current.Properties["type"];
                var shiftChoice= (String)Application.Current.Properties["shift"];
                var numberOfPassengersChoice= (int)Application.Current.Properties["numberOfPassengers"];
                var priceChoice = (double)Application.Current.Properties["price"];
                CarItems = new List<Car> {

                new Car {image = imageChoice, model = modelChoice, type=typeChoice, shift=shiftChoice,numberOfPassengers=numberOfPassengersChoice,price=priceChoice},

            };


            }
        }
    }
}