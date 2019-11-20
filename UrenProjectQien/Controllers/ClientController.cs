using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared.Models;
using UrenProjectQien.Helper;

namespace UrenProjectQien.Controllers
{
    public class ClientController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public ClientController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllClients()
        {
            var client = _httpClientFactory.CreateClient("Api");
            var response = await client.GetAsync("GetAll");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Cannont retrieve clients");
            }
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Client>>(jsonString);
            return View(result);
        }
        public async Task<ActionResult> ClientDetails(int clientId)
        {
            var client = _httpClientFactory.CreateClient("Api");
            var response = await client.GetAsync("GetClientById");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Cannont retrieve tasks");
            }
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Client>>(jsonString);
            return View(result);
        }
        public async Task OnGet()
        {
            var client = _httpClientFactory.CreateClient("Api");

            var response = await client.SendAsync("Create");

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                Branches = await JsonSerializer.DeserializeAsync
                    <IEnumerable<GitHubBranch>>(responseStream);
            }
            else
            {
                GetBranchesError = true;
                Branches = Array.Empty<GitHubBranch>();
            }
        }
    }
}