using AndreAirLineMongoDbTicket.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        //[HttpGet]
        //[HttpGet("{id}")]
        //[HttpPost]
        //[HttpPut]
        //[HttpDelete("{id}")]
    }
}
