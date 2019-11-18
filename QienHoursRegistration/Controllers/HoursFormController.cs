using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QienHoursRegistration.Models;
using QienHoursRegistration.Repositories;
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
        public HoursFormController(DbContext context)
        {
            this.context = context;
        }
        private readonly IHoursFormRepository hoursform;
        public HoursFormController(IHoursFormRepository hoursform)
        {
            this.hoursform = hoursform;
        }

        [HttpGet]
        public async Task<IEnumerable<HoursForm>> GetAllHoursForms()
        {
            return await hoursform.GetAllHoursForms();
        }

        [HttpGet("{hoursformmodel}")]
        public async Task<ActionResult<HoursForm>> GetHoursForms(HoursForm hoursformmodel)
        {
            return await hoursform.GetHoursForm(hoursformmodel);
        }
        [HttpGet]
        public async Task<ActionResult<HoursForm>> GetSingleAccountForms()
        {
            return await hoursform.GetSingleAccountForms();
        }
        [HttpPatch]
        public async void EditForm(HoursForm editform)
        {
            hoursform.EditForm(editform);
        }

    }
}
