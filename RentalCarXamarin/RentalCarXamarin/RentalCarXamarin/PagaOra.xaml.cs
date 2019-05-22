using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Newtonsoft.Json;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace RentalCarXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PagaOra : ContentPage
	{
        Boolean payment = (Boolean)Application.Current.Properties["payment"];
        int paynow = 1;
        String message1;
        String message2;
        String message3;
        String message4;
        String message5;
        String message6;
        String message7;
        String message8;
        int id;
        public PagaOra ()
		{
			InitializeComponent ();
            //se non paghiamo ora mette alcuni campi invisibili
            if (!payment)
            {
                CartaCredito.IsVisible = false;
                DataScadenza.IsVisible = false;
                CodiceSicurezza.IsVisible = false;
                paynow = 0;
            }
            //impostiamo data minima per scadenza carta
            DataScadenza.SetValue(DatePicker.MinimumDateProperty, DateTime.Now);
            
        }

        public async void backToHomeButton(object sender, EventArgs e)
        {
            //ritorno alla home
            await this.Navigation.PopToRootAsync();

        }

        public async void ConfirmButton(object sender, EventArgs e)
        {
            //se c'è qualche campo vuoto ti avverte dell'errore
            if (string.IsNullOrEmpty(name.Text) || string.IsNullOrEmpty(surname.Text) ||
                    string.IsNullOrEmpty(emailEntry.Text) || string.IsNullOrEmpty(phone.Text))
            {
                await DisplayAlert("Attenzione", "Per favore riempire tutti i campi", "OK");
            }
            else if(payment&&(string.IsNullOrEmpty(CartaCredito.Text) || string.IsNullOrEmpty(CodiceSicurezza.Text)))
            {
                await DisplayAlert("Attenzione", "Per favore riempire tutti i campi", "OK");
            }
            else
            {
            
                //mi prendo tutti i valori e teoricamente dovrei salvarli sul server
                //per ora li salvo in properties
                String fName = name.Text;
                String sName = surname.Text;
                String email = emailEntry.Text;
                String telephone = phone.Text;
                Application.Current.Properties["name"] = fName;
                Application.Current.Properties["surname"] = sName;
                Application.Current.Properties["email"] = email;
                Application.Current.Properties["phone"] = telephone;
                //carica tutto sul server
                Stazioni sRit = new Stazioni((String)Application.Current.Properties["stationRetire"]);
                Stazioni sRest = new Stazioni((String)Application.Current.Properties["stationRestitution"]);
                String car =(String)Application.Current.Properties["model"];
                String dateRetire = (String)Application.Current.Properties["dateRetire"];
                String dateRestitution = (String)Application.Current.Properties["dateRestitution"];
                double price=(double)Application.Current.Properties["totalPrice"];
                if (!payment) price += 25;
 
                set_reservations(new Reservation(sRit,sRest,car,email,dateRetire,dateRestitution,paynow,price),
                    new ServerRequest("http://rentalcar.altervista.org/inserisci_prenotazione.php"));
                set_users(new User(email, fName, sName, telephone),
                    new ServerRequest("http://rentalcar.altervista.org/inserisci_utenti.php"));
                read_id(new ServerRequest("http://rentalcar.altervista.org/leggi_id.php"),
                    email,dateRetire,dateRestitution);
                
                message1 = "Caro " + fName + " " + sName;
                message2 = "La ringraziamo per averci scelto,";
                message3 = "ecco il riepilogo della Sua prenotazione:";
                message5 = "Ritiro: " + sRit.Stazione + " " + dateRetire;
                message6 = "Restituzione: " + sRest.Stazione + " " + dateRestitution;
                message7 = car + "   " + price + " euro";
                message8 = "Le auguriamo buon viaggio";
                
                //va alla pagina finale
                await this.Navigation.PushAsync(new ConfermaEmail());
            }
        }

        public async void set_reservations(Reservation rs,ServerRequest sr)
        {
            string URL_Param = "?StazioneRit=" + rs.retStation.Stazione + "&StazioneRic=" + rs.recStation.Stazione
                + "&Macchina="+rs.car+ "&Email="+rs.email+ "&Pagamento="+rs.payment+
                "&DataRitiro="+rs.dateRetire+ "&DataRestituzione="+rs.dateRestitution+ "&Prezzo="+rs.price;
            var response = await sr._client.PostAsync(sr.URL + URL_Param, null);
            if (response.IsSuccessStatusCode)
            {
                string responseText = response.Content.ReadAsStringAsync().Result.ToString();
                Insert_Result(responseText);
            }
            else
            {
                //Debug.WriteLine("Error while inserting User in Post mode");
            }
        }

        public async void set_users(User ur, ServerRequest sr)
        {
            string URL_Param = "?Nome=" + ur.Nome + "&Cognome=" + ur.Cognome
                + "&Telefono=" + ur.Telefono + "&Email="+ur.Email;
            var response = await sr._client.PostAsync(sr.URL + URL_Param, null);
            if (response.IsSuccessStatusCode)
            {
                string responseText = response.Content.ReadAsStringAsync().Result.ToString();
                Insert_Result(responseText);
            }
            else
            {
                //Debug.WriteLine("Error while inserting User in Post mode");
            }
        }

        public async void read_id(ServerRequest sr,String email,String dataritiro,String datarestituzione)
        {
            string URL_Param = "?Email=" + email + "&DataRitiro=" + dataritiro
                + "&DataRestituzione=" + datarestituzione;
            var response = await sr._client.GetAsync(sr.URL + URL_Param);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                Dictionary<string, UserId> result_id = JsonConvert.DeserializeObject<Dictionary<string, UserId>>(result);

                foreach (KeyValuePair<string, UserId> entry in result_id)
                {
                    Debug.WriteLine("Key: {0}, Value: {1}", entry.Key, entry.Value.ID);
                    id = entry.Value.ID;
                }
                Debug.WriteLine("Id: {0}", id);
                message4 = " Id Prenotazione: " + id;
                send_mail(new ServerRequest("http://rentalcar.altervista.org/invio_email.php"),message4);
            }
            else
            {
                Debug.WriteLine("Error");
            }
        }

        public async void send_mail(ServerRequest sr,String msg4)
        {
            string URL_Param = "?Email=" + emailEntry.Text + "&msg1=" + message1
                + "&msg2=" + message2 + "&msg3=" + message3 + "&msg4=" + msg4 + "&msg5=" + message5
                + "&msg6=" + message6 + "&msg7=" + message7 + "&msg8=" + message8;
            var response = await sr._client.PostAsync(sr.URL + URL_Param, null);
            if (response.IsSuccessStatusCode)
            {
                string responseText = response.Content.ReadAsStringAsync().Result.ToString();
                Insert_Result(responseText);
            }
            else
            {
                //Debug.WriteLine("Error while inserting User in Post mode");
            }
        }

        public void Insert_Result(string ans)
        {
            if (ans == "1")
            {
                DisplayAlert("Risultato inserimento", "Inserimento corretto", "OK");
            }
            else
            {
                DisplayAlert("Risultato inserimento", "Inserimento errato. Check your query", "OK");
            }
        }
    }
}