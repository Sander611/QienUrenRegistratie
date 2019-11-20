using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrenProjectQien.Helper;

namespace UrenProjectQien.Controllers
{
    public class ClientController : Controller
    {
        ApiHelper _api = new ApiHelper();
        //public async Task<IActionResult> AllClients()
        //{
        //    //Taskoverzicht

        //    //api call op methode
        //    //list view returnen 
        //    // [naam] - Urenregistratie [Maand] [Jaar] bij [Companyname] | [Datum][tijd] | [statusClientcheck] | Controleren
        //    List<HoursForm> uncheckedForms = new List<HoursForm>();

        //    HttpClient client = _api.Connect();
        //    HttpResponseMessage res = await client.GetAsync("api/uncheckedForms");
        //    if (res.IsSuccessStatusCode)
        //    {
        //        var result = res.Content.ReadAsStringAsync().Result;
        //        uncheckedForms = JsonConvert.DeserializeObject<List<HoursForm>>(result);
        //    }

        //    return View(uncheckedForms);
        //}
    }
}