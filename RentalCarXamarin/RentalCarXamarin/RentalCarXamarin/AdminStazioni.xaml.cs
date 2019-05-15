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
	public partial class AdminStazioni : ContentPage
	{
		public AdminStazioni ()
		{
			InitializeComponent ();
		}

        public async void backButton(object sender, EventArgs e)
        {
            //al click del bottone va ad AreaAdmin
            await this.Navigation.PushAsync(new AreaAdmin());
        }
    }
}