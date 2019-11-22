using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace UrenProjectQien.Controllers
{
    public class EmployeeController : Controller
    {
        //ApiHelper _api = new ApiHelper();
        
        public async Task<IActionResult> EmployeeDashboard()
        {
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
            return View(hoursforms);
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
