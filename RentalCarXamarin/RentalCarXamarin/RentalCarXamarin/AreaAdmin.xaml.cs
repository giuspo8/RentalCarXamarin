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
	public partial class AreaAdmin : ContentPage
	{
		public AreaAdmin ()
		{
			InitializeComponent ();
		}

        public async void adminCarButton(object sender, EventArgs e)
        {
            //metodo navigazione tra pagine
            await this.Navigation.PushAsync(new AdminAuto());
        }

        public async void adminStationsButton(object sender, EventArgs e)
        {
            //metodo navigazione tra pagine
            await this.Navigation.PushAsync(new AdminStazioni());
        }

        public async void backToHomeButton(object sender, EventArgs e)
        {
            //toglie tutte le pagine dallo stack e va alla pagina iniziale
            await this.Navigation.PopToRootAsync();
        }
    }
}