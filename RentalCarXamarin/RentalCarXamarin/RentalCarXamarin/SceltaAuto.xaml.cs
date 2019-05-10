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
	public partial class SceltaAuto : ContentPage
	{
        string TIme = "";
        string Macchina = "";
		public SceltaAuto (string time,string macchina)
		{
			InitializeComponent ();
            List<string> lista= new List<string>() { macchina, "2", "3" };
            lst.ItemsSource = lista;
            this.TIme = time;
            this.Macchina = macchina;
        }
        private async void itemsel(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem;
            await this.Navigation.PushAsync(new RiepilogoPrenotazione(TIme,Macchina));
            
        }
    }
}