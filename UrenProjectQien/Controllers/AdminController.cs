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
    public class AdminController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public AdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Dashboard()
        {
            
            List<AdminTaskModel> uncheckedForms = new List<AdminTaskModel>();

            

            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:5001/HoursForm/clientacceptforms");
            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                uncheckedForms = JsonConvert.DeserializeObject<List<AdminTaskModel>>(responseStream);
            }



            return View(uncheckedForms);
        }

        public async Task<IActionResult> Controleren(int formId, int accountId, string fullName, string month, string year)
        {

            ViewBag.formId = formId;
            ViewBag.accountId = accountId;
            ViewBag.fullName = fullName;
            ViewBag.month = month;
            ViewBag.year = year;

            List<HoursPerDayModel> formsForId = new List<HoursPerDayModel>();

            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:5001/HoursPerDay/getAllDaysForForm/" + formId);
            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                formsForId = JsonConvert.DeserializeObject<List<HoursPerDayModel>>(responseStream);
            }



            return View(formsForId);
        }

        public async Task<IActionResult> CreateEmployee()
        {
            return View();
        }
    }
}