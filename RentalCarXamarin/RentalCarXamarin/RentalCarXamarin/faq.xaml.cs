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
	public partial class faq : ContentPage
	{
        List<string> lista = new List<string>();
        public faq ()
		{
			InitializeComponent ();
            
            lista.Add("domanda1");
            lista.Add("domanda2");
            lst.ItemsSource = lista;
        }
        private async void itemsel(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem;
            

        }
    }
}