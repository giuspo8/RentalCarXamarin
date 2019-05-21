using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace RentalCarXamarin
{
    class ServerRequest
    {
        private string URL;
        private HttpClient _client;
        private MainPage mainPage;

        public ServerRequest(MainPage mainPage, string URL)
        {
            this.mainPage = mainPage;
            this.URL = URL;
            this._client = new HttpClient();
        }

        public async void getStazioni()
        {
            var response = await _client.GetAsync(URL);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                Dictionary<string, Stazione> result_utenti = JsonConvert.DeserializeObject<Dictionary<string, Stazione>>(result);
            }/*
                List<Stazione> stazioni = new List<Utente>();
                
                foreach (KeyValuePair<string, Utente> entry in result_utenti)
                {
                    int idutente = Int32.Parse(entry.Key);
                    utenti.Add(new Utente(idutente, entry.Value.Username, entry.Value.Password));
                }
                mainPage.fillListView(utenti);
            }
            else
                Debug.WriteLine("Nothing retrieved from server.");
                
            }

            public async void setUtenteGet(Utente ut)
        {
            string URL_Param = "?username=" + ut.Username + "&password=" + ut.Password;
            var response = await _client.PostAsync(URL + URL_Param, null);
            if (response.IsSuccessStatusCode)
            {
                string responseText = response.Content.ReadAsStringAsync().Result.ToString();
                mainPage.Insert_Result(responseText);
            }
            else
            {
                Debug.WriteLine("Error while inserting User in Post mode");
            }
            */
        }
           

            }
        }
