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
	public partial class Admin_buttons : ContentPage
	{
		public Admin_buttons ()
		{
			InitializeComponent ();
}

        public async void adminReservationsButton(object sender, EventArgs e)
        {
            //andiamo alla page prenotazioni
            await this.Navigation.PushAsync(new AdminPrenotazioni());

        }

        public async void adminCarButton(object sender, EventArgs e)
        {
            //andiamo alla page auto
            await this.Navigation.PushAsync(new AdminAuto());

        }

        public async void adminStationsButton(object sender, EventArgs e)
        {
            //andiamo alla page stazioni
            await this.Navigation.PushAsync(new AdminStazioni());

        }

        public async void backToHomeButton(object sender, EventArgs e)
        {
            //ritorno alla home
            await this.Navigation.PopToRootAsync();

        }
    }
}