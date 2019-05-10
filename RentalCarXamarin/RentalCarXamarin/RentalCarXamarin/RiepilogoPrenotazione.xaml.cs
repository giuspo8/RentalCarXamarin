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
	public partial class RiepilogoPrenotazione : ContentPage
	{
		public RiepilogoPrenotazione (string time,string macchi)
		{
			InitializeComponent ();
            macchina.Text = time;
		}
	}
}