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
    public class HoursFormController: ControllerBase
    {
        private readonly DbContext context;
        public HoursFormController(DbContext context)
        {
            this.context = context;
        }
        private readonly HoursFormRepository hoursform;
        public HoursFormController(HoursFormRepository hoursform)
        {
            this.hoursform = hoursform;
        }

        [HttpGet]
        public IEnumerable<HoursForm> GetAllHoursForms()
        {
            return hoursform.GetAllHoursForms();
        }

        [HttpGet]
        public IEnumerable<HoursForm> GetHoursForms()
        {
            yield return hoursform.GetHoursForm();
        }
        [HttpGet]
        public IEnumerable<HoursForm> GetSingleAccountForms()
        {
            yield return hoursform.GetSingleAccountForms();
        }
        [HttpPatch]
        public void EditForm(HoursForm editform)
        {
            hoursform.EditForm(editform);
        }

    }
}
