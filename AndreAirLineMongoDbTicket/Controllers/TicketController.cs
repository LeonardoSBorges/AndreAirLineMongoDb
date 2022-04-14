using AndreAirLineMongoDbTicket.Service;
using Microsoft.AspNetCore.Mvc;
using ModelShare;
using ModelShare.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreAirLineMongoDbTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly TicketService _ticketService;

        public TicketController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<List<Ticket>> Get()
        {
            return await _ticketService.GetAll();

        }

        [HttpGet("{id}", Name = "GetTicket")]
        public async Task<Ticket> Get(string id)
        {
            return await _ticketService.Get(id);
        }
        [HttpPost]
        public async Task<Ticket> Post(TicketDTO ticketDTO)
        {
            Ticket ticket = await _ticketService.Post(ticketDTO);
            return ticket;
        }

        [HttpPut]
        public async Task<IActionResult> Put(Ticket ticket)
        {
            await _ticketService.Update(ticket);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _ticketService.Delete(id);
            return NoContent();
        }
    }
}
