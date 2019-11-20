using Microsoft.EntityFrameworkCore;
using QienHoursRegistration.DataContext;
using Shared.Models;
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
        public async Task<List<HoursFormModel>> GetAllHoursForms()
        {
            var models = context.HoursForms
                .Select(p => new HoursFormModel
                {
                    FormId = p.FormId,
                    AccountId = p.AccountId,
                    DateSend = p.DateSend,
                    DateDue = p.DateDue,
                    TotalHours = p.TotalHours,
                    ProjectMonth = p.ProjectMonth,
                    IsAcceptedClient = p.IsAcceptedClient

                });
            return await models.OrderBy(m => m.AccountId).ToListAsync();
        }

        //returning all hoursforms where IsAcceptedClient is NOT null
        public async Task<List<HoursFormModel>> GetAllClientAcceptedForms()
        {
            var formsEntities = await context.HoursForms.Where(p => p.IsAcceptedClient != null).ToListAsync();

            List<HoursFormModel> allForms = new List<HoursFormModel>();

            foreach (var form in formsEntities)
                allForms.Add(new HoursFormModel
                {
                    FormId = form.FormId,
                    AccountId = form.AccountId,
                    DateSend = form.DateSend,
                    DateDue = form.DateDue,
                    TotalHours = form.TotalHours,
                    ProjectMonth = form.ProjectMonth,
                    IsAcceptedClient = form.IsAcceptedClient,
                });


            return allForms;
            
        }

        //new hoursform
        //public async Task<HoursForm> createHoursForm(HoursFormModel hoursFormModel, int clientId)
        //{
        //    context.HoursForms.Add(hoursFormModel);

        //    await context.SaveChangesAsync();
        //}

        //getting all forms for specific account
        public async Task<List<HoursFormModel>> GetSingleAccountForms(int accountId)
        {
            var formsEntities = await context.HoursForms.Where(p => p.AccountId == accountId).ToListAsync();

            List<HoursFormModel> allFormsForUser = new List<HoursFormModel>();

            foreach (var form in formsEntities)
                allFormsForUser.Add(new HoursFormModel
                {
                    FormId = form.FormId,
                    AccountId = form.AccountId,
                    DateSend = form.DateSend,
                    DateDue = form.DateDue,
                    TotalHours = form.TotalHours,
                    ProjectMonth = form.ProjectMonth,
                    IsAcceptedClient = form.IsAcceptedClient,
                });


            return allFormsForUser;

        }

        //getting a single form
        public async Task<HoursForm> GetSingleForm(int formId)
        {
            return await context.HoursForms.FindAsync(formId);
        }

        //edit the form
        public async Task<HoursFormModel> EditForm(HoursFormModel editform)
        {


            HoursForm entity = context.HoursForms.Single(p => p.FormId == editform.FormId);
            entity.FormId = editform.FormId;
            entity.AccountId = editform.AccountId;
            entity.DateSend = editform.DateSend;
            entity.DateDue = editform.DateDue;
            entity.TotalHours = editform.TotalHours;
            entity.ProjectMonth = editform.ProjectMonth;
            entity.IsAcceptedClient = editform.IsAcceptedClient;

            await context.SaveChangesAsync();

            return editform;
        }

        public async Task<HoursFormModel> CreateNewForm(HoursFormModel hoursFormModel)
        {
            // create form
            
            // get form id, maand, jaar
            // generate days
            return hoursFormModel;
        }
    }
}
