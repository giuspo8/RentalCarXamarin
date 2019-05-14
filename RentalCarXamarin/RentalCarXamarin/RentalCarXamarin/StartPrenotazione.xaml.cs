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
	public partial class StartPrenotazione : ContentPage
	{
        string DateStringRit = "";
        string DateStringRic = "";
        string Stazione = "";
        public StartPrenotazione ()
		{
			InitializeComponent ();
            PickerRit.Items.Add("ciao");
        }
        public void DatePickerDateSelected(object sender, DateChangedEventArgs e)
        {
            DateStringRit = DatePickerRit.Date.ToString();
        }
        public void DatePickerDateSelectedRic(object sender, DateChangedEventArgs e)
        {
            DateStringRic = DatePickerRic.Date.ToString();
        }
        public void PickerSelectedIndexChanged(object sender, EventArgs e)
        {
             lab.Text= PickerRit.Items[PickerRit.SelectedIndex];
        }
        public async void carchoosing(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new SceltaAuto(DateStringRic,DateStringRit,Stazione));
        }
        public async void backToHomeButton(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new MainPage());
            
        }
       
    }
}