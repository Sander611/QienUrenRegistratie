using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QienHoursRegistration.DataContext;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;

namespace QienHoursRegistration.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly RepositoryContext context;

        public ClientRepository(RepositoryContext _context)
        {
            context = _context;
        }
        public async Task<List<Client>> Get()
        {
            return await context.Clients.ToListAsync();
        }
        public async Task<Client> GetById(int id)
        {
            return await context.Clients.FindAsync(id);
        }
        public async Task Post(Client clientModel)
        {
            Client newClient = new Client()
            {
                ClientEmail1 = clientModel.ClientEmail1,
                ClientEmail2 = clientModel.ClientEmail2,
                AccountId = clientModel.AccountId,
                ClientName1 = clientModel.ClientName1,
                ClientName2 = clientModel.ClientName2,
                CompanyName = clientModel.CompanyName
            };
                context.Clients.Add(newClient);
                await context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var client = await context.Clients.FindAsync(id);
            context.Clients.Remove(client);
            await context.SaveChangesAsync();
        }
        public async Task Update(Client client)
        {
            context.Entry(client).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public Client VerifyEmail(string email)
        {
            return context.Clients.Find(email);
        }
    }
}
