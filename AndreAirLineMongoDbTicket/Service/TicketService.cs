﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelShare;
using ModelShare.DTO;
using ModelShare.Services;
using ModelShare.Util;
using MongoDB.Driver;
using System;
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

        public async Task<Ticket> Post(TicketDTO ticketDTO)
        {

            var newTicket = await Ticket.NewTicket(ticketDTO);
            newTicket.Reserve = ticketDTO.Reserve;

            await PostAndreAirLines.PostLog(new LogDTO(null, null, newTicket.ToString(), "Create", DateTime.Now));
            _ticketService.InsertOne(newTicket);
            return newTicket;
        }

        public async Task<int> Update(Ticket ticket)
        {
            var ticketExists = _ticketService.Find(searchTicket => searchTicket.Id == ticket.Id).FirstOrDefaultAsync();
            if (ticketExists == null)
                return 400;

            await _ticketService.ReplaceOneAsync(searchTicket => searchTicket.Id == ticket.Id, ticket);
            return 201;
        }


        public async Task Delete(string id)
        {
            await _ticketService.DeleteOneAsync(searchTicket => searchTicket.Id == id);

        }

        
    }
}
