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
        private IHttpClientFactory _httpClientFactory;

        public AdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // method om als admin op een gebruiker te klikken en alle forms als overzicht te krijgen (doormiddel van dropdownmenus voor maand, jaar )

        public async Task<IActionResult> Dashboard()
        {
            
            List<AdminTaskModel> uncheckedForms = new List<AdminTaskModel>();

            

            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:5001/HoursForm/clientacceptforms");
            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                uncheckedForms = JsonConvert.DeserializeObject<List<AdminTaskModel>>(responseStream);
            }



            return View(uncheckedForms);
        }

        public async Task<IActionResult> Controleren(int formId, int accountId, string fullName, string month, string year)
        {

            ViewBag.formId = formId;
            ViewBag.accountId = accountId;
            ViewBag.fullName = fullName;
            ViewBag.month = month;
            ViewBag.year = year;

            List<HoursPerDayModel> formsForId = new List<HoursPerDayModel>();

            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:5001/HoursPerDay/getAllDaysForForm/" + formId);
            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                formsForId = JsonConvert.DeserializeObject<List<HoursPerDayModel>>(responseStream);
            }



            return View(formsForId);
        }

        public async Task<IActionResult> AccountOverzicht(string searchString)
        {

            List<AccountModel> listAccounts = new List<AccountModel>();

            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:5001/Account/accounts/?searchString=" + searchString);
            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                listAccounts = JsonConvert.DeserializeObject<List<AccountModel>>(responseStream);
            }
            return View(listAccounts);
        }

        public async Task<IActionResult> UrenFormulieren(int id, string name)
        {
            ViewBag.currUser = name;

            List<HoursFormModel> allFormsForAccount = new List<HoursFormModel>();

            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:5001/HoursForm/singleaccountform/" + id);
            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                allFormsForAccount = JsonConvert.DeserializeObject<List<HoursFormModel>>(responseStream);
            }


            return View(allFormsForAccount);
        }

        public async Task<RedirectToRouteResult> DeleteAccount(int accountID)
        {


            var request = new HttpRequestMessage(HttpMethod.Delete,
                "https://localhost:5001/Account/deleteAccount/" + accountID);
            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
            }

            return RedirectToRoute(new { controller = "Admin", action = "AccountOverzicht" });
        }

        public async Task<IActionResult> EditAccount (int accountID)
        {
            AccountModel userInfo = new AccountModel();

            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:5001/Account/" + accountID);
            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();

                userInfo = JsonConvert.DeserializeObject < AccountModel > (responseStream);
            }

            return View(userInfo);
        }

        public async Task<RedirectToRouteResult> Edit(AccountModel updatedAccount)
        {
            //var request = new HttpRequestMessage(HttpMethod.Post,
            //    "https://localhost:5001/Account/updateAccount/");


            //var client = _httpClientFactory.CreateClient();

            //var url = "https://localhost:5001/Account/updateAccount/";


            //var encodedContent = new FormUrlEncodedContent(updatedAccount);

            //var response = await client.PostAsync(url, encodedContent);

            //if (response.IsSuccessStatusCode)
            //{
            //    var responseStream = await response.Content.ReadAsStringAsync();
            //}

            return RedirectToRoute(new { controller = "Admin", action = "AccountOverzicht" });
        }

        public async Task<IActionResult> CreateEmployee()
        {
            return View();
        }



    }
}