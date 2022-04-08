using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Models.Services;
using Models.Util;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreAirLineMongoDbTicket.Service
{
    public class TicketService 
    {
        private readonly IMongoCollection<Ticket> _ticketService;
        public TicketService(IConnectionMongoDb settings)
        {
            var connection = new MongoClient(settings.ConnectionString);
            var database = connection.GetDatabase(settings.NameDataBase);
            _ticketService = database.GetCollection<Ticket>(settings.CollectionName);
        }

        public async Task<List<Ticket>> GetAll()
        {
            return await _ticketService.Find(ticket => true).ToListAsync();
        }

        public async Task<Ticket> Get(string id)
        {
            return await _ticketService.Find(ticket => ticket.Id == id).FirstOrDefaultAsync();
        }

        //public async Task<Ticket> Post(TicketDTO ticketDTO)
        //{
        //    var newTicket = await NewTicket(ticketDTO);
        //    _ticketService.InsertOne(newTicket);
        //    return newTicket;
        //}

        //public async Task<Ticket> Update(string id, TicketDTO ticke

        //public async Task<Ticket> NewTicket(TicketDTO ticketDTO)
        //{
        //    var fly = await QueriesAndreAirLines.SearchFly(ticketDTO.FlightId);
        //    var person = await QueriesAndreAirLines.SearchPerson(ticketDTO.PersonId);
        //    var basePrice = await QueriesAndreAirLines.SearchBasePrice(ticketDTO.BasePriceId);
        //    var _class = await QueriesAndreAirLines.SearchClass(ticketDTO.BasePriceId);
                              
        //    ticketDTO.TotalValue += basePrice.Price + (basePrice.Price * (_class.Value / 100)); 

        //    var ticket = new Ticket(fly, person, basePrice, _class, ticketDTO.RegisterDate, ticketDTO.TotalValue, ticketDTO.Sale);
        //    return ticket;
        //}
    }
}
