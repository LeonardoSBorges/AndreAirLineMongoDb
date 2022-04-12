using AndreAirLineDapper.Models;
using AndreAirLineDapper.Repository;
using AndreAirLineDapper.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AndreAirLineDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly AirportService _dapperContext;

        public AirportController()
        {
            _dapperContext = new AirportService();
        }
        // GET: api/<AirportController>
        [HttpGet]
        public async Task<List<Airport>> Get()
        {

            var result = await _dapperContext.GetAll();
            return result;
        }

        // POST api/<AirportController>
        [HttpPost]
        public  IActionResult Post(Airport airport)
        {
            var result = _dapperContext.Add(airport);
            return result == true ? Ok() : NotFound();
        }       
    }
}
