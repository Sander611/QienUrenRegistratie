using Microsoft.EntityFrameworkCore;
using QienHoursRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QienHoursRegistration.Repositories
{
    public class HoursFormRepository : IHoursFormRepository
    {
        private readonly DbContext context;
        public HoursFormRepository(DbContext context)
        {
            this.context = context;
        }

        //returning all hoursforms, ordered by account Id
        public List<HoursForm> GetAllHoursForms()
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
            return models.OrderBy(m => m.AccountId).ToList();
        }

        //new hoursform
        public HoursForm GetHoursForm()
        {
            return new HoursForm
            {
            };
        }

        //getting all forms for specific account
        public HoursForm GetSingleAccountForms()
        {
            return context.HoursForm.Where(x => x.AccountId).ToList();

        }

        //getting a single form
        public HoursForm GetSingleForm()
        {
            return context.HoursForm.Where(x => x.FormId).toList();
        }

        //edit the form
        public void EditForm(HoursForm editform)
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
            context.SaveChanges();
        }
    }
}
