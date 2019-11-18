using System.Collections.Generic;
using System.Threading.Tasks;
using QienHoursRegistration.Models;

namespace QienHoursRegistration.Repositories
{
    public interface IClientRepository
    {
        Task<List<Client>> Get();
        Task<Client> GetById(int id);
        void Post(Client clientModel);
        void Delete(int id);
        void Update(Client client);
    }
}