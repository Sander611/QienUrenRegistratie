using Microsoft.EntityFrameworkCore;
using QienHoursRegistration.DataContext;
using QienHoursRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QienHoursRegistration.Repositories
{
    public class HoursFormRepository : IHoursFormRepository
    {
        private readonly RepositoryContext context;
        public HoursFormRepository(RepositoryContext context)
        {
            this.context = context;
        }
        private readonly HoursForm hoursform;
        public HoursFormRepository(HoursForm hoursform)
        { 
            this.hoursform = hoursform; 
        }

        //returning all hoursforms, ordered by account Id
        public async Task<List<HoursForm>> GetAllHoursForms()
        {
            var models = context.HoursForm
                .Select(p => new HoursForm
                {
                    FormId = p.FormId,
                    AccountId = p.AccountId,
                    DateSend = p.DateSend,
                    DateDue = p.DateDue,
                    TotalHours = p.TotalHours,
                    ProjectMonth = p.ProjectMonth,
                    IsAcceptedClient = p.IsAcceptedClient

                });
            return await models.OrderBy(m => m.AccountId).ToList();
        }

        //new hoursform
        public async Task<HoursForm> GetHoursForm(HoursForm hoursformmodel)
        {
            return new HoursForm
            {
                AccountId = hoursformmodel.AccountId,
                IsAcceptedClient = hoursformmodel.IsAcceptedClient
            };
        }

        //getting all forms for specific account
        public async Task<HoursForm> GetSingleAccountForms()
        {
            return await context.HoursForm.Where(x => x.AccountId).ToList();

        }

        //getting a single form
        public async Task<HoursForm> GetSingleForm()
        {
            return await context.HoursForm.Where(x => x.FormId).toList();
        }

        //edit the form
        public async void EditForm(HoursForm editform)
        {
            context.HoursForm.Add(new HoursForm
            {
                FormId = editform.FormId,
                AccountId = editform.AccountId,
                DateSend = editform.DateSend,
                DateDue = editform.DateDue,
                TotalHours = editform.TotalHours,
                ProjectMonth = editform.ProjectMonth,
                IsAcceptedClient = editform.IsAcceptedClient

            });
            await context.SaveChangesAsync();
        }
    }
}
