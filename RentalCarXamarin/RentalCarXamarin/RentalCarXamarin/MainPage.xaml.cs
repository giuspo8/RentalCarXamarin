using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RentalCarXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public async void nuova_prenotazione(object sender,EventArgs e)
        {
            await this.Navigation.PushAsync(new StartPrenotazione());
        }
    }

}
