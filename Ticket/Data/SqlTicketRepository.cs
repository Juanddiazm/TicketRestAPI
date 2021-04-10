using System;
using System.Collections.Generic;
using System.Linq;
using Ticket.Models;

namespace Ticket.Data
{
    public class SqlTicketRepository : ITicketRepository
    {
        private readonly TicketContext _context;

        public SqlTicketRepository(TicketContext context)
        {
            _context = context;
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void CreateTicket(TicketModel ticket)
        {
           if(ticket == null){
               throw new ArgumentNullException(nameof(ticket));
           }
           _context.Add(ticket);
        }
        public TicketModel GetTicketById(int id)
        {
            return _context.Tickets.FirstOrDefault(p => p.id == id);
        }

        public IEnumerable<TicketModel> GetAllTickets()
        {
            return _context.Tickets.ToList();
        }

        public void UpdateTicket(TicketModel ticket){}

        public void DeleteTicket(TicketModel ticket)
        {
              if(ticket == null){
               throw new ArgumentNullException(nameof(ticket));
           }
           _context.Tickets.Remove(ticket);
        }
    }
}