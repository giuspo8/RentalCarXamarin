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
    public partial class Contatti : ContentPage
    {
        public Contatti()
        {
            InitializeComponent();
        }

        public async void backToHomeButton(object sender, EventArgs e)
        {
            //toglie tutte le pagine dallo stack e va alla pagina iniziale
            await this.Navigation.PopToRootAsync();
        }
        public async void instagram(object sender, EventArgs e)
        {
            Xamarin.Forms.Device.OpenUri(new Uri("https://www.instagram.com/?hl=it"));
        }
        public async void facebook(object sender, EventArgs e)
        {
            Xamarin.Forms.Device.OpenUri(new Uri("https://it-it.facebook.com/"));
        }
        public async void gmail(object sender, EventArgs e)
        {
            Xamarin.Forms.Device.OpenUri(new Uri("https://support.google.com/mail/answer/56256?hl=it"));
        }
    }
}