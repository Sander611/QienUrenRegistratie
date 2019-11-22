using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QienHoursRegistration.DataContext;
using Shared.Models;
using Shared.Models;
using UrenProjectQien.Helper;

namespace UrenProjectQien.Controllers
{
    //[Authorize(Policy = "IsAdmicClaimAccess")]
    public class ClientController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public ClientController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

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
        public async Task<IActionResult> ClientDetails(int id)
        {
            var client = _httpClientFactory.CreateClient("Api");
            var response = await client.GetAsync($"Client/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Cannont retrieve client");
            }
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ClientModel>(jsonString);
            return View(result);
        }
        [HttpGet]
        public IActionResult CreateClient()
        {
            return View();
        }
        [HttpPost]
        public async Task<ClientModel> CreateClient(ClientModel newClient)
        {
            var client = _httpClientFactory.CreateClient("Api");
            var content = JsonConvert.SerializeObject(newClient);

            var response = await client.PostAsync("Client/create", new StringContent(content, Encoding.Default, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                throw new Exception("Cannot add a new client");
            }
            var createdClient = JsonConvert.DeserializeObject<ClientModel>(await response.Content.ReadAsStringAsync());
            return createdClient;
        }
    }
}