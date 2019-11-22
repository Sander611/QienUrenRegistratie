using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace UrenProjectQien.Helper
{
    public class ApiHelper : IApiHelper
    {
        //public HttpClient Connect()
        //{
        //    // HIER ONDER HET IP ADRESS TOEVOEGEN WAAR DE API OP DRAAIT.

        //    var client = new HttpClient();
        //    client.BaseAddress = new Uri("https://localhost:44319/");
        //    return client;

        private readonly HttpClient client;
        public ApiHelper(HttpClient client)
        {
            client.BaseAddress = new Uri("");
            this.client = client;
        }

        public async Task<IEnumerable<HoursPerDayModel>> GetHours(int formid)
        {
            var response = await client.GetAsync("/HoursPerDayModel");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<HoursPerDayModel>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<HoursPerDayModel>> AddHours(List<HoursPerDayModel> model)
        {
            var response = await client.GetAsync("");
            response.EnsureSuccessStatusCode();

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44319/");
            //client.BaseAddress = new Uri("https://localhost:44319/");

            return client;
        }

    }
}
