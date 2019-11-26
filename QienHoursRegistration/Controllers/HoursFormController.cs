using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QienHoursRegistration.Repositories;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QienHoursRegistration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HoursFormController : ControllerBase
    {
        private readonly DbContext context;
        //public HoursFormController(DbContext context)
        //{
        //    this.context = context;
        //}

        private readonly IHoursFormRepository hoursform;
        public HoursFormController(IHoursFormRepository hoursform)
        {
            this.hoursform = hoursform;
        }

        [HttpGet("hourforms")]
        public async Task<IEnumerable<HoursFormModel>> GetAllHoursForms()
        {
            return await hoursform.GetAllHoursForms();
        }

        [HttpGet("clientacceptforms")]
        public async Task<IEnumerable<AdminTaskModel>> GetAllClientAcceptedForms()
        {
            return await hoursform.GetAllClientAcceptedForms();
        }

        [HttpGet("formsperuser")]
        public async Task<IEnumerable<EmployeeDashboardModel>> getAllFormPerAccount(int accountId)
        {
            return await hoursform.getAllFormPerAccount(accountId);
        }

        [HttpPost("createhourform")]
        public async Task<HoursFormModel> createHourForm(HoursFormModel hoursFormModel)
        {
            return await hoursform.CreateNewForm(hoursFormModel);
        }

        [HttpGet("singleaccountform/{accountId}")]
        public async Task<IEnumerable<HoursFormModel>> GetSingleAccountForms(int accountId)
        {
            return await hoursform.GetSingleAccountForms(accountId);
        }


        [HttpPost("updateHoursForm")]
        public async Task<ActionResult<HoursFormModel>> EditForm(HoursFormModel editform) 
        {
           return await hoursform.EditForm(editform);
        }

    }
}
