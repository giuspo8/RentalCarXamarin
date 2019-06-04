using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;

namespace RentalCarXamarin
{
    public class ServerRequest
    {
        public string URL;
        public HttpClient _client;


        public ServerRequest(string URL)
        {
            this.URL = URL;
            this._client = new HttpClient();
        }

    }


}
     
