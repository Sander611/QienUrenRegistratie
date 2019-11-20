﻿using Microsoft.EntityFrameworkCore;
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
        public async Task<List<HoursForm>> GetAllHoursForms()
        {
            var models = context.HoursForms
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
            return await models.OrderBy(m => m.AccountId).ToListAsync();
        }

        //returning all hoursforms where IsAcceptedClient is NOT null
        public async Task<List<HoursForm>> GetAllClientAcceptedForms()
        {
            var models = context.HoursForms.Where(p => p.IsAcceptedClient != null);
            return await models.OrderBy(m => m.AccountId).ToListAsync();
            
        }

        //new hoursform
        public async Task<HoursForm> createHoursForm(HoursForm hoursFormModel, int clientId)
        {
            context.HoursForms.Add(hoursFormModel);

            await context.SaveChangesAsync();
        }

        //getting all forms for specific account
        public async Task<HoursForm> GetSingleAccountForms(int accountId)
        {
            return await context.HoursForms.FindAsync(accountId);

        }

        //getting a single form
        public async Task<HoursForm> GetSingleForm(int formId)
        {
            return await context.HoursForms.FindAsync(formId);
        }

        //edit the form
        public async void EditForm(HoursForm editform)
        {
            context.HoursForms.Add(new HoursForm
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
