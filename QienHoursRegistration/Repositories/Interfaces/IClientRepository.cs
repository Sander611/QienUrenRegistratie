﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QienHoursRegistration.DataContext;
using Shared.Models;

namespace QienHoursRegistration.Repositories
{
    public interface IClientRepository
    {
        Task<List<ClientModel>> Get();
        Task<ClientModel> GetById(int id);
        Task<ClientModel> CreateNewClient(ClientModel clientModel);
        Task DeleteClient(int id);
        Task<ClientModel> Update(ClientModel client);
        //Client VerifyEmail(string email);
    }
}