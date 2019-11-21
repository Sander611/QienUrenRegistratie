using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;
using Microsoft.AspNetCore.Mvc;
using UrenProjectQien.Helper;
using System.Net.Http;
using Newtonsoft.Json;

namespace UrenProjectQien.Controllers
{
    public class EmployeeController : Controller
    {
        ApiHelper _api = new ApiHelper();
        
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
    }
}