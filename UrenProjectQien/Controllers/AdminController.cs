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
        //ApiHelper _api = new ApiHelper();
        public async Task<IActionResult> Dashboard()
        {
            //Taskoverzicht

            //api call op methode
            //list view returnen 
            // [naam] - Urenregistratie [Maand] [Jaar] bij [Companyname] | [Datum][tijd] | [statusClientcheck] | Controleren
            //List<HoursForm> uncheckedForms = new List<HoursForm>();

            //HttpClient client = _api.Connect();
            //HttpResponseMessage res = await client.GetAsync("api/uncheckedForms");
            //if (res.IsSuccessStatusCode)
            //{
            //    var result = res.Content.ReadAsStringAsync().Result;
            //    uncheckedForms = JsonConvert.DeserializeObject<List<HoursForm>>(result);
            //}

            List<AdminTaskModel> uncheckedForms = new List<AdminTaskModel>();

            for (int i = 0; i < 6; i++)
            {
                // formid meegeven
                AdminTaskModel atm = new AdminTaskModel() { formId = 1, accountId = 1, FullName = "Test", HandInTime = DateTime.Now, stateClientCheck = null, Info = "Uren Registratie Januari 2019 bij Macaw", Month="Januari", Year=2019};
                uncheckedForms.Add(atm);
            }



            return View(uncheckedForms);
        }

        public async Task<IActionResult> Controleren(int formId, int userId, string month, string year)
        {
            // get data using arguments
            // naam
            // dagen 
            // make table with headers
            ViewBag.formId = formId;
            ViewBag.userid = userId;
            ViewBag.month = month;
            ViewBag.year = year;
            return View();
        }

        public async Task<IActionResult> CreateEmployee()
        {
            return View();
        }
    }
}