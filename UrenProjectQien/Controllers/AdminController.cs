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
        ApiHelper _api = new ApiHelper();
        public async Task<IActionResult> Dashboard()
        {
            //Taskoverzicht

            //api call op methode
            //list view returnen 
            // [naam] - Urenregistratie [Maand] [Jaar] bij [Companyname] | [Datum][tijd] | [statusClientcheck] | Controleren
            List<HoursForm> uncheckedForms = new List<HoursForm>();
            
            HttpClient client = _api.Connect();
            HttpResponseMessage res = await client.GetAsync("api/uncheckedForms");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                uncheckedForms = JsonConvert.DeserializeObject<List<HoursForm>>(result);
            }

            return View(uncheckedForms);
        }
    }
}