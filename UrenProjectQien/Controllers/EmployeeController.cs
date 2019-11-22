﻿using System;
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

        public IActionResult EmployeeDashboard()
        {
            return View();
        }



        //public IActionResult UrenRegistratie()
        //{
        //    var formid = 1;
        //    List<HoursPerDayModel> urenMaand = new List<HoursPerDayModel>();
        //    HoursPerDayModel hfm = new HoursPerDayModel() { FormId = formid };
        //    urenMaand.Add(hfm);
        //    return View(urenMaand);
        //}


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

        //[HttpPost]
        //public async Task<IActionResult> UrenRegistratie(List<HoursPerDayModel> model)
        //{
        //    await helper.AddHours(model);
        //    return RedirectToAction("EmployeeDashboard");

        //}
    }
}
