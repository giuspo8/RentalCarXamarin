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
            public String image { get; set; }
            public String model { get; set; }
            public String type { get; set; }
            public String shift { get; set; }
            public int numberOfPassengers { get; set; }
            public double price { get; set; }
        }

        public class CarChoosingModel : BindableObject
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

            public CarChoosingModel()
            {


                CarItems = new List<Car> {

                new Car {image = "cinquecento.png", model = "Fiat Cinquecento", type="Economy", shift="manuale",numberOfPassengers=5,price=100.00},

                new Car {image = "clio.png", model = "Renault Clio", type="Compatta", shift="manuale",numberOfPassengers=5,price=100.00},

                new Car {image = "golf.png", model = "Volswagen Golf", type="Luxury", shift="automatico",numberOfPassengers=5,price=100.00}

            };


            }
        }
    }
}