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
        public faq()
        {
            InitializeComponent();
            List<ListItem> listItems = new List<ListItem> {
                new ListItem {item="Dopo aver prenotato, è possibile cambiare la vettura scelta ?",index=0},
                new ListItem {item= "Cosa succede se la macchina non viene riconsegnata nei tempi previsti ?",index=1},
                new ListItem {item = "Di che cosa ho bisogno per noleggiare un' auto ?",index=2},
                new ListItem {item = "Cosa faccio se mi si dovessere rompere l'auto ?",index=3},
                new ListItem {item= "Posso prenotare un' auto per conto di terzi ?",index=4},
                new ListItem {item = "E' tutto incluso nel prezzo del noleggio ?",index=5}

        };
            listfaq.ItemsSource = listItems;
        }
        public class ListItem
        {
            public string item { get; set; }
            public int index { get; set; }
        }
        public async void ListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            //facciamo il controllo dell' elemento cliccato
            ListItem l = (ListItem)e.Item;
            int index = l.index;

            switch (index)
            {
                case 0:
                    //stampa a video la risposta
                    await DisplayAlert("Risposta", "No, non è possibile.", "OK");
                    break;
                case 1:
                    //stampa a video la risposta
                    await DisplayAlert("Risposta", "Verrà contattato.", "OK");
                    break;
                case 2:
                    //stampa a video la risposta
                    await DisplayAlert("Risposta", "Per prenotare un auto, serve una carta di credito", "OK");
                    break;
                case 3:
                    //stampa a video la risposta
                    await DisplayAlert("Risposta", "Deve chiamarci e noi La veniamo a prendere", "OK");
                    break;
                case 4:
                    //stampa a video la risposta
                    await DisplayAlert("Risposta", "No, non è possibile", "OK");
                    break;
                case 5:
                    //stampa a video la risposta
                    await DisplayAlert("Risposta", "Sì, è tutto incluso", "OK");
                    break;
            }
        }
    }
}

        



        
    
