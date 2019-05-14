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
        string TImerit = "";
        string TImeric = "";
        public SceltaAuto (string timeric, string timerit,string stazione)
		{
			InitializeComponent ();           
            this.TImerit = timerit;
            this.TImeric = timeric;
            
        }
        
    }
}