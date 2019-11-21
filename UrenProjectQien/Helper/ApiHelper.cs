using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace UrenProjectQien.Helper
{
    public class ApiHelper
    {
        public HttpClient Connect()
        {
            // HIER ONDER HET IP ADRESS TOEVOEGEN WAAR DE API OP DRAAIT.

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44319/");
            //client.BaseAddress = new Uri("https://localhost:44319/");

            return client;
        }
    }
}
