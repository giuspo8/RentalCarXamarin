﻿using System;
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
            //settiamo la data minima (domani)per i due datepicker
            DatePickerRit.SetValue(DatePicker.MinimumDateProperty, DateTime.Now.AddDays(1));
            DatePickerRic.SetValue(DatePicker.MinimumDateProperty, DateTime.Now.AddDays(1));
            //mette valori di default alle stazioni
            //per evitare controlli successivi
            PickerRit.SelectedIndex = 1;
            PickerRic.SelectedIndex = 1;
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
            //= PickerRit.Items[PickerRit.SelectedIndex];
        }
        public async void carchoosing(object sender, EventArgs e)
        {
            //se la data di ritiro supera quella di riconsegna ci avverte dell'errore
            if ((DatePickerRit.Date>DatePickerRic.Date)||((DatePickerRit.Date==DatePickerRic.Date)&&(TimePickerRit.Time>TimePickerRic.Time)))
            {
                await DisplayAlert("Attenzione","La data di ritiro deve essere antecedente alla data di riconsegna","OK");
            }
            else {
                //salvo tutti i valori sul dizionario properties
                String dateRetire = DatePickerRit.Date.Day+"/"+ DatePickerRit.Date.Month +
                    "/"+ DatePickerRit.Date.Year+" " + TimePickerRit.Time;
                String dateRestitution = DatePickerRic.Date.Day + "/" + DatePickerRic.Date.Month +
                    "/" + DatePickerRic.Date.Year + " " + TimePickerRic.Time;
                String stationRetire = PickerRit.Items[PickerRit.SelectedIndex];
                String stationRestitution = PickerRic.Items[PickerRic.SelectedIndex];
                Double days = ((DateTime)DatePickerRic.Date-(DateTime)DatePickerRit.Date).TotalDays;
                Application.Current.Properties["dateRetire"] = dateRetire;
                Application.Current.Properties["dateRestitution"] = dateRestitution;
                Application.Current.Properties["stationRetire"] = stationRetire;
                Application.Current.Properties["stationRestitution"] = stationRestitution;
                Application.Current.Properties["days"] = days;
                //passiamo alla page sceltaauto
                await this.Navigation.PushAsync(new SceltaAuto());
            }
        }
        public async void backToHomeButton(object sender, EventArgs e)
        {
            //ritorno alla home
            await this.Navigation.PopToRootAsync();
            
        }
       
    }
}