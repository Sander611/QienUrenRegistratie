using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using QienHoursRegistration.Repositories;

namespace QienHoursRegistration.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HoursPerDayController : ControllerBase
    {
        private readonly IHoursPerDayRepository hoursPerDayRepository;

        public HoursPerDayController(IHoursPerDayRepository hoursPerDayRepository)
        {
            this.hoursPerDayRepository = hoursPerDayRepository;
        }

        [HttpPost("SaveADay")]
        public async Task<ActionResult<HoursPerDay>> FillInDay(HoursPerDay hoursPerDay)
        {
            if (!ModelState.IsValid)
                return hoursPerDay;

            return await hoursPerDayRepository.SaveADay(hoursPerDay);

        }



        [HttpPost("CreateAMonth")]
        public async Task<ActionResult<HoursForm>> CreateAMonth(HoursForm hoursForm)
        {
            if (!ModelState.IsValid)
                return hoursForm;

            return await hoursPerDayRepository.CreateOneMonth(hoursForm);

        }

        [HttpPost("updateHoursPerDay")]
        public async Task<ActionResult<HoursPerDay>> Update(HoursPerDay hoursPerDay)
        {
            
            return await hoursPerDayRepository.Update(hoursPerDay);
        }
    }
}
