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
	public partial class ScriviProblemi : ContentPage
	{
		public ScriviProblemi ()
		{
			InitializeComponent ();
		}

        public async void backToHomeButton(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new MainPage());
        }
    }
}