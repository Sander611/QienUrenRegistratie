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
        [Route("GetAllClients")]
        public async Task<List<ClientModel>> GetAllClients()
        {
            var client = _httpClientFactory.CreateClient("Api");
            var response = await client.GetAsync("GetAll");

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ClientModel>>(jsonString);
        }
    }
}