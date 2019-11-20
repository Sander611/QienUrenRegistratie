using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UrenProjectQien.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult EmployeeDashboard()
        {
            return View();
        }
    }
}