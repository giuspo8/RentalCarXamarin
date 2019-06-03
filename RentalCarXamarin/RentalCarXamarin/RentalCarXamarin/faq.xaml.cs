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

                new ListItem {item="Dopo aver prenotato, è possibile cambiare la vettura scelta ?",index=0,rispo="No, non è possibile."},

                new ListItem {item= "Cosa succede se la macchina non viene riconsegnata nei tempi previsti ?",index=1,rispo="Verrà contattato."},

                new ListItem {item = "Di che cosa ho bisogno per noleggiare un' auto ?",index=2,rispo="Per prenotare un auto, serve una carta di credito"},

                new ListItem {item = "Cosa faccio se mi si dovessere rompere l'auto ?",index=3,rispo="Deve chiamarci e noi La veniamo a prendere"},

                new ListItem {item= "Posso prenotare un' auto per conto di terzi ?",index=4,rispo="No, non è possibile."},

                new ListItem {item = "E' tutto incluso nel prezzo del noleggio ?",index=5,rispo="Sì, è tutto incluso"}



        };

            listfaq.ItemsSource = listItems;
        }

    }
}
 


        



        
    
