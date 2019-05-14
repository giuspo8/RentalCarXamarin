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
	public partial class SceltaStazione : ContentPage
	{
        private readonly List<string> stations = new List<string>
        {
            "Milano Stazione","Ancona","Roma Stazione"
            
    };
        public SceltaStazione ()
		{
			InitializeComponent ();
            lststation.ItemsSource = stations;
        }
    private void SearchContent_TextChanged(object sender, TextChangedEventArgs e)
    {
        var keyword = SearchContent.Text;
        if (keyword.Length >= 1)
        {
            var suggestion = stations.Where(c => c.ToLower().Contains(keyword.ToLower()));
            lststation.ItemsSource = suggestion;
            lststation.IsVisible = true;
        }
        else
        {
            lststation.IsVisible = false;
        }
    }
}
}