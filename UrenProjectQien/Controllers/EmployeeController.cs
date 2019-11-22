using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using UrenProjectQien.Helper;

namespace UrenProjectQien.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApiHelper helper;
        public EmployeeController(ApiHelper helper)
        {
            this.helper = helper;
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
        int formid = 1;

        public IActionResult HoursRegistration(int formid)
        {
            return View(helper.GetHours(formid));
        }

        [HttpPost]
        public async Task<IActionResult> UrenRegistratie(List<HoursPerDayModel> model)
        {
            await helper.AddHours(model);
            return RedirectToAction("EmployeeDashboard");

        }
    }
}