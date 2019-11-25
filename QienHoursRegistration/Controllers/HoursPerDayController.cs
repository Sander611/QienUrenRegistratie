using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using QienHoursRegistration.Repositories;

namespace QienHoursRegistration.Controllers
{

    
    [ApiController]
    [Route("[controller]")]
    public class HoursPerDayController : ControllerBase
    {
        private readonly IHoursPerDayRepository hoursPerDayRepository;

        public HoursPerDayController(IHoursPerDayRepository hoursPerDayRepository)
        {
            this.hoursPerDayRepository = hoursPerDayRepository;
        }

        //[HttpPost("SaveADay")]
        //public async Task<ActionResult<HoursPerDay>> FillInDay(HoursPerDay hoursPerDay)
        //{
        //    if (!ModelState.IsValid)
        //        return hoursPerDay;

        //    return await hoursPerDayRepository.SaveADay(hoursPerDay);

        //}

        [HttpGet("getAllDaysForForm/{formId}")]
        public async Task<IEnumerable<HoursPerDayModel>> GetAllDaysForForm(int formId)
        {
            return await hoursPerDayRepository.GetAllDaysForForm(formId);
        }

        [HttpPost("updateHoursPerDay")]
        public async Task<IEnumerable<HoursPerDayModel>> Update(List<HoursPerDayModel> hoursPerDay)
        {
            
            return await hoursPerDayRepository.Update(hoursPerDay);
        }
    }
}
