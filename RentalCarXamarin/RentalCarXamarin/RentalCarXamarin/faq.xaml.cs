using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        
        public faq ()
		{
			InitializeComponent ();
            BindingContext = new ListViewStringsViewModel();

        }

        public async void backToHomeButton(object sender, EventArgs e)
        {
            //toglie tutte le pagine dallo stack e va alla pagina iniziale
            await this.Navigation.PopToRootAsync();
        }

        async void ListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            string item = (string)e.Item;
            if (item== "Dopo aver prenotato, è possibile cambiare la macchina ?")
            {
                await DisplayAlert("Risposta", "No, non è possibile.", "OK");
            }
            else
            {
                await DisplayAlert("Risposta", "Il cliente verrà contattato.", "OK");
            }
            
            ((ListView)sender).SelectedItem = null;
        }

        public class ListViewStringsViewModel : BindableObject
        {
            List<string> items;
            public List<string> Items
            {
                get
                {
                    return items;
                }
                set
                {
                    items = value;
                    OnPropertyChanged("Items");
                }
            }

            public ListViewStringsViewModel()
            {
                Items = new List<string>
                    {
                        "Dopo aver prenotato, è possibile cambiare la macchina ?",
                        "Cosa succede se non si riconsegna la macchina in tempo ?",
                    };
            }
        }

    }
}