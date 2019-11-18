using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QienHoursRegistration.Models;
using QienHoursRegistration.Repositories;

namespace QienHoursRegistration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository clientRepo;

        public ClientController(IClientRepository clientRepo)
        {
            this.clientRepo = clientRepo;
        }
        [HttpGet]
        public async Task<IEnumerable<Client>> GetAll()
        {
            return await clientRepo.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClientById(int id)
        {
            var client = await clientRepo.GetById(id);
            if(client == null)
            {
                return NotFound();
            }
            return client;
        }
        [HttpPost]
        public async Task<ActionResult<Client>> Create(Client client)
        {
            var existingClient =  await clientRepo.GetById(client.ClientId);
            if (existingClient != null)
            {
                return Conflict("Kan een nieuwe klant niet tovoegen. De klant bestaat al in de DB");
            }
            clientRepo.Post(client);
            return CreatedAtAction(nameof(GetClientById), new { id = client.ClientId }, client);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingClient = await clientRepo.GetById(id);
            if (existingClient == null)
            {
                return NotFound();
            }
            clientRepo.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Client client)
        {
            var existingClient = await clientRepo.GetById(id);
            if (existingClient == null)
            {
                return BadRequest();
            }
            clientRepo.Update(client);
            return NoContent();
        }
    }
}