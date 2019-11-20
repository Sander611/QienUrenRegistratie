using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QienHoursRegistration.DataContext;
using Shared.Models

namespace QienHoursRegistration.Repositories
{
    public interface IClientRepository
    {
        Task<List<Client>> Get();
        Task<Client> GetById(int id);
        Task Post(Client clientModel);
        Task Delete(int id);
        Task Update(Client client);
        Client VerifyEmail(string email);
    }
}