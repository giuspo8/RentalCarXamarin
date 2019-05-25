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
        public void phone(object sender, EventArgs e)
        {
            //apre i contatti
            Device.OpenUri(new Uri("tel:071-86753"));
        }
        public void instagram(object sender, EventArgs e)
        {
            //apre instagram
            Xamarin.Forms.Device.OpenUri(new Uri("https://www.instagram.com"));
        }
        public void facebook(object sender, EventArgs e)
        {
            //apre facebook
            Xamarin.Forms.Device.OpenUri(new Uri("https://www.facebook.com"));
        }
        public void email(object sender, EventArgs e)
        {
            //apre gmail
            Xamarin.Forms.Device.OpenUri(new Uri("mailto:rcm_mail@gmail.com"));
        }
        
    }

}