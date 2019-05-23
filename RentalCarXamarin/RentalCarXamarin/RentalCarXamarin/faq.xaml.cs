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
            //facciamo il controllo dell' elemento cliccato
            string item = (string)e.Item;
            if (item == "Dopo aver prenotato, è possibile cambiare la macchina ?")
            {
                //stampa a video la risposta
                await DisplayAlert("Risposta", "No, non è possibile.", "OK");
            }
            else if (item == "Cosa succede se non si riconsegna la macchina ?")
            {
                //stampa a video la risposta
                await DisplayAlert("Risposta", "Il cliente verrà contattato.", "OK");
            }
            else if (item == "Di cosa ho bisogno per noleggiare un' auto ?")
            {
                //stampa a video la risposta
                await DisplayAlert("Risposta", "Per prenotare un' auto, serve una carta di credito", "OK");
            }
            else if (item == "Cosa faccio se mi si rompe la macchina ?")
            {
                //stampa a video la risposta
                await DisplayAlert("Risposta", "Devi chiamarci e noi ti veniamo a prendere", "OK");
            }
            else if (item == "Posso prenotare un' auto per conto di qualcun altro ?")
            {
                //stampa a video la risposta
                await DisplayAlert("Risposta", "No non è possibile", "OK");
            }
            else if (item == "E' tutto incluso nel prezzo del noleggio ?")
            {
                //stampa a video la risposta
                await DisplayAlert("Risposta", "sì è tutto incluso", "OK");
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
                //insieme delle domande
                Items = new List<string>
                    {
                        "Dopo aver prenotato, è possibile cambiare la macchina ?",
                        "Cosa succede se non si riconsegna la macchina ?",
                        "Di cosa ho bisogno per noleggiare un' auto ?",
                        "Cosa faccio se mi si rompe la macchina ?",
                        "Posso prenotare un' auto per conto di qualcun altro ?",
                        "E' tutto incluso nel prezzo del noleggio ?"
                    };
            }
        }


    }
}