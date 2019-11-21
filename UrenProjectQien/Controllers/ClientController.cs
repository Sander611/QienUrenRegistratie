using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QienHoursRegistration.DataContext;
using Shared.Models;
using Shared.Models;
using UrenProjectQien.Helper;

namespace UrenProjectQien.Controllers
{
    public class ClientController : Controller
    {
        public IEnumerable<Client> result { get; private set; }
        public bool GetClientError { get; private set; }
        private IHttpClientFactory _httpClientFactory;

        public ClientController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var client = _httpClientFactory.CreateClient("Api");
            var response = await client.GetAsync("Client/clients");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Cannont retrieve clients");
            }
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ClientModel>>(jsonString);
            return View(result);
        }
        //public async Task<ActionResult> ClientDetails(int clientId)
        //{
        //    var client = _httpClientFactory.CreateClient("Api");
        //    var response = await client.GetAsync("GetClientById");
        //    if (!response.IsSuccessStatusCode)
        //    {
        //        throw new Exception("Cannont retrieve tasks");
        //    }
        //    var jsonString = await response.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<List<Client>>(jsonString);
        //    return View(result);
        //}
        //public async Task CreateClient()
        //{
        //    var request = new HttpRequestMessage(HttpMethod.Get, "Create");
        //    var client = _httpClientFactory.CreateClient("Api");

        //    var response = await client.SendAsync(request);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        using var jsonString = await response.Content.ReadAsStreamAsync();
        //        result = await JsonConvert.DeserializeObject<IEnumerable<Client>>(jsonString);
        //    }
        //    else
        //    {
        //        GetClientError = true;
        //        result = Array.Empty<Client>;
        //    }
        //    return (result);
        //}
    }
}