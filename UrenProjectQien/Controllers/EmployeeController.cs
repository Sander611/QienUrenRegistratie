using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;
using Microsoft.AspNetCore.Mvc;
using UrenProjectQien.Helper;
using System.Net.Http;

namespace UrenProjectQien.Controllers
{
    public class EmployeeController : Controller
    {
        ApiHelper _api = new ApiHelper();
        
        public async Task<IActionResult> EmployeeDashboard()
        {
            //HttpClient httpClient = _api.initial(); 
            AccountModel account = new AccountModel()
            {
                FirstName = "Romy",
                LastName = "van der Sar",
                City = "Utrecht",
                Address = "Langelaan 45",
                DateOfBirth = new DateTime(1995, 8, 6)
                


            };
            return View(account);
        }
    }
}