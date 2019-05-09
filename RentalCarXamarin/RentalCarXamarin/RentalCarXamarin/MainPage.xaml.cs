using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RentalCarXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //questi metodi sono relativi ai click sui buttoni nel menu e semplicemente spostano 
        //la navigazione su un'altra pagina
        public async void newReservationButton(object sender,EventArgs e)
        {
            await this.Navigation.PushAsync(new StartPrenotazione());
        }

        public async void manageReservationButton(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new ModificaPrenotazione());
        }

        public async void contactsButton(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new Contatti());
        }

        public async void segnalationsButton(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new ScriviProblemi());
        }

        public async void faqButton(object sender, EventArgs e)
        {
            
        }

        public async void adminButton(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new AreaAdmin());
        }

    }

}
