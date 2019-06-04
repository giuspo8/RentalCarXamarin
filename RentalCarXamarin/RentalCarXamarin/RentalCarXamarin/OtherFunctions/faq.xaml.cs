using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
            BindingContext = new ListViewPageModel();
        }
        public class ListViewPageModel
        {
            public ObservableCollection<ListItem> List_element { get; set; }

            public ListItem PreviousSelectedElement { get; set; }
            private ListItem _selectedItem { get; set; }
            public ListItem SelectedItem
            {
                get { return _selectedItem; }
                set
                {
                    if (_selectedItem != value)
                    {
                        _selectedItem = value;
                        ExpandSelectedItem();
                    }
                }
            }

            private void ExpandSelectedItem()
            {
                if (PreviousSelectedElement != null)
                {
                    List_element.Where(t => t.index == PreviousSelectedElement.index).FirstOrDefault().IsVisible =
                    false;
                }

                List_element.Where(t => t.index == SelectedItem.index).FirstOrDefault().IsVisible =
                    true;
                PreviousSelectedElement = SelectedItem;
            }

            public ListViewPageModel()
            {
                List_element = new ObservableCollection<ListItem>
                {
                    new ListItem {index=0,item="Dopo aver prenotato, è possibile cambiare la vettura scelta ?",rispo="No, non è possibile."},

                    new ListItem {index=1,item= "Cosa succede se la macchina non viene riconsegnata nei tempi previsti ?",rispo="Verrà contattato."},

                    new ListItem {index=2,item = "Di che cosa ho bisogno per noleggiare un' auto ?",rispo="Per prenotare un auto, serve una carta di credito"},
    
                    new ListItem {index=3,item = "Cosa faccio se mi si dovessere rompere l'auto ?",rispo="Deve chiamarci e noi La veniamo a prendere"},

                    new ListItem {index=4,item= "Posso prenotare un' auto per conto di terzi ?",rispo="No, non è possibile."},
    
                    new ListItem {index=5,item = "E' tutto incluso nel prezzo del noleggio ?",rispo="Sì, è tutto incluso"}
                };
            }

        }


    }
}
 


        



        
    
