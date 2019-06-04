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
        String RetireStation = (String)Application.Current.Properties["stationRetire"];
        String RestitutionStation = (String)Application.Current.Properties["stationRestitution"];
        String RetireDate = (String)Application.Current.Properties["dateRetire"];
        String RestitutionDate = (String)Application.Current.Properties["dateRestitution"];
        Double price = (Double)Application.Current.Properties["price"];
        Double days = (Double)Application.Current.Properties["days"];

        public RiepilogoPrenotazione()
        {
            InitializeComponent();
            DataRit.Text = RetireDate;
            DataRic.Text = RestitutionDate;
            ricStation.Text = RestitutionStation;
            retStation.Text = RetireStation;
            Double totalPrice = (price*days)+price;
            Double totalPriceStation = totalPrice+25;
            paynow.Text = "paga ora (" + totalPrice + "€)";
            Application.Current.Properties["totalPrice"]=totalPrice;
            paystation.Text = "paga alla stazione (" + totalPriceStation + "€)";
            Application.Current.Properties["totalPriceStation"] = totalPriceStation;
            var imageChoice = (String)Application.Current.Properties["image"];
            var modelChoice = (String)Application.Current.Properties["model"];
            var typeChoice = (String)Application.Current.Properties["type"];
            var shiftChoice = (String)Application.Current.Properties["shift"];
            var numberOfPassengersChoice = (int)Application.Current.Properties["numberOfPassengers"];
            var priceChoice = (double)Application.Current.Properties["price"];
            List<CarItem> CarItems = new List<CarItem> {

                new CarItem {Image = imageChoice, Model = modelChoice,
                    ClassCar =typeChoice, Shift=shiftChoice,
                    Number =numberOfPassengersChoice,Pricegg=priceChoice},

            };
            listView.ItemsSource = CarItems;
        }
        

        public async void paymentNowButton(object sender, EventArgs e)
        {
            Boolean paynow = true;
            Application.Current.Properties["payment"] = paynow;
            //va alla pagina per il pagamento settando il paynow a true
            await this.Navigation.PushAsync(new PagaOra());
        }

        public async void paymentLaterButton(object sender, EventArgs e)
        {
            Boolean paynow = false;
            Application.Current.Properties["payment"] = paynow;
            //va alla pagina per il pagamento settando il paynow a false
            await this.Navigation.PushAsync(new PagaOra());
        }

        public async void backToHomeButton(object sender, EventArgs e)
        {
            //ritorno alla home
            await this.Navigation.PopToRootAsync();

        }
    }
}