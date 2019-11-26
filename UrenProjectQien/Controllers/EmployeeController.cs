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
    public class EmployeeController : Controller
    {
        //private readonly ApiHelper helper;
        //public EmployeeController(ApiHelper helper)
        //{
        //    this.helper = helper;
        //}

        private IHttpClientFactory _httpClientFactory;

        public EmployeeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> EmployeeDashboard()
        {
            var client = _httpClientFactory.CreateClient("Api");
            var response = await client.GetAsync($"Account/{2}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Cannont retrieve account");
            }
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AccountModel>(jsonString);

            var response1 = await client.GetAsync($"HoursForm/formsperuser/{2}");
            if (!response1.IsSuccessStatusCode)
            {
                throw new Exception("Cannont retrieve form");
            }
            var jsonString1 = await response1.Content.ReadAsStringAsync();
            var result1 = JsonConvert.DeserializeObject<List<HoursFormModel>>(jsonString1);

            AccountModel accountInfo = new AccountModel()
            {
                FirstName = result.FirstName,
                LastName = result.LastName,
                Address = result.Address,
                ZIP = result.ZIP,
                AccountId = result.AccountId,
                City = result.City
            };
            List<HoursFormModel> formsOverview = new List<HoursFormModel>();
            foreach (var form in result1)
            {
                formsOverview.Add(new HoursFormModel
                {
                    AccountId = form.AccountId,
                    FormId = form.FormId,
                    DateDue = form.DateDue,
                    Year = form.Year,
                    ProjectMonth = form.ProjectMonth
                });
            }
            EmployeeDashboardModel EDM = new EmployeeDashboardModel();
            EDM.Account = accountInfo;
            EDM.Forms = formsOverview;
            List<HoursFormModel> hoursforms = new List<HoursFormModel>();

            //HttpClient client = _api.Connect();
            //HttpResponseMessage res = await client.GetAsync("HoursForm/hoursform");

            //if(res.IsSuccessStatusCode)
            //{
            //    var result = res.Content.ReadAsStringAsync().Result;
            //    hoursforms = JsonConvert.DeserializeObject<List<HoursFormModel>>(result);
            //}

            for (int i = 0; i < 5; i++)
            {
                HoursFormModel hoursform = new HoursFormModel()
                {
                    ProjectMonth = "November",
                    DateDue = new DateTime(2019,02,12)

                };

                hoursforms.Add(hoursform);
            }
            return View(EDM);
        }


        public async Task<IActionResult> HoursRegistration(int formid)
        {
            List<HoursPerDayModel> formsForId = new List<HoursPerDayModel>();
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:5001/HoursPerDay/getAllDaysForForm/" + formid);
            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                formsForId = JsonConvert.DeserializeObject<List<HoursPerDayModel>>(responseStream);
            }

            return View(formsForId);
        }

        [HttpPost]
        public async Task<IActionResult> HoursRegistration(List<HoursPerDayModel> model)
        {
            if (ModelState.IsValid)
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:5001/HoursPerDay/updateHoursPerDay/");

                string json = JsonConvert.SerializeObject(model);

                request.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpClient http = new HttpClient();
                HttpResponseMessage response = await http.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseStream = await response.Content.ReadAsStringAsync();
                    return View(model);

                }
            }

            return View(model);

        }
    }
}
