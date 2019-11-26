using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared.Models;

namespace UrenProjectQien.Controllers
{
    public class ClientController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public ClientController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> GetAllClients(string searchString)
        {
            var client = _httpClientFactory.CreateClient("Api");
            var response = await client.GetAsync("Client/clients");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Cannont retrieve clients");
            }
            var jsonString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<ClientModel>>(jsonString);
            
            if(!String.IsNullOrEmpty(searchString))
            {
                result = result.Where(s => s.CompanyName.ToLower().Contains(searchString.ToLower())).ToList();
            }
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
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Cannot add a new client");
            }
            var createdClient = JsonConvert.DeserializeObject<ClientModel>(await response.Content.ReadAsStringAsync());
            return createdClient;
        }
        public async Task<IActionResult> UpdateClient(int id)
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

        [HttpPost]
        public async Task<IActionResult> UpdateClient(ClientModel updatedClient)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient("Api");
                var content = JsonConvert.SerializeObject(updatedClient);

                var response = await client.PatchAsync($"Client/{updatedClient.ClientId}", new StringContent(content, Encoding.Default, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot update the client");
                }
                return RedirectToRoute(new { controller = "Client", action = "GetAllClients" });
            }
            return View(updatedClient);
        }
        [HttpGet("{id}")]
        public async Task<RedirectToRouteResult> DeleteClient(int id)
        {
            var client = _httpClientFactory.CreateClient("Api");
            var response = await client.DeleteAsync($"Client/{id}");
            if(!response.IsSuccessStatusCode)
            {
                throw new Exception("Cannot delete the client");
            }
            return RedirectToRoute(new { controller = "Client", action = "GetAllClients" });
        }
    }
}