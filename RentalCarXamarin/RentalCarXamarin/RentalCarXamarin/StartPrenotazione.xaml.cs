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
	public partial class StartPrenotazione : ContentPage
	{
        string timeString = "ora";

        public StartPrenotazione ()
		{
			InitializeComponent ();
            
        }
        public async void carchoosing(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new SceltaAuto(timeString,"opel"));
        }
        public async void backToHomeButton(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new MainPage());
        }
    }
}