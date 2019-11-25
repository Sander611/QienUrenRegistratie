using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QienHoursRegistration.DataContext;
using QienHoursRegistration.Repositories;
using Shared.Models;

namespace QienHoursRegistration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository clientRepo;

        public ClientController(IClientRepository clientRepo)
        {
            this.clientRepo = clientRepo;
        }


        [HttpGet("clients")]
        public async Task<IEnumerable<ClientModel>> GetAll()
        {
            var clients = await clientRepo.Get();
            return clients;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ClientModel>> GetClientById(int id)
        {
            var client = await clientRepo.GetById(id);
            if (client == null)
            {
                return NotFound();
            }
            return client;
        }


        [HttpPost("{create}")]
        public async Task<ActionResult<ClientModel>> Create(ClientModel client)
        {
            if (!ModelState.IsValid)
                return client;

            return await clientRepo.CreateNewClient(client);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingClient = await clientRepo.GetById(id);
            if (existingClient == null)
            {
                return NotFound();
            }
            await clientRepo.DeleteClient(id);
            return NoContent();
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult<ClientModel>> Update( ClientModel client)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingClient = await clientRepo.GetById(client.ClientId);
            if (existingClient == null)
            {
                return NotFound();
            }
            return await clientRepo.Update(client);
        }
    }
}