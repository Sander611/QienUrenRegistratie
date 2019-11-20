using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QienHoursRegistration.DataContext;
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
        public async Task<IEnumerable<HoursForm>> GetAllHoursForms()
        {
            return await hoursform.GetAllHoursForms();
        }

        [HttpGet("clientacceptforms")]
        public async Task<IEnumerable<HoursForm>> GetAllClientAcceptedForms()
        {
            return await hoursform.GetAllClientAcceptedForms();
        }

        [HttpPost("createhourform")]
        public ActionResult<HoursForm> createHourForm(HoursFormModel hoursFormModel, int clientId)
        {
            return hoursform.createHoursForm(hoursFormModel, clientId);
        }

        [HttpGet("singleaccountform/{accountId}")]
        public async Task<ActionResult<HoursForm>> GetSingleAccountForms(int accountId)
        {
            return await hoursform.GetSingleAccountForms(accountId);
        }
        [HttpPatch]
        public void EditForm(HoursForm editform)
        {
            hoursform.EditForm(editform);
        }

    }
}
