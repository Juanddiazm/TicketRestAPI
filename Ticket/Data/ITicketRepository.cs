using System.Collections.Generic;
using Ticket.Models;

namespace Ticket.Data
{
    public interface ITicketRepository
    {
        bool SaveChanges();
        IEnumerable<TicketModel> GetAllTickets();
        TicketModel GetTicketById(int id);

        void CreateTicket(TicketModel ticket);
        void UpdateTicket(TicketModel ticket);

        void DeleteTicket(TicketModel ticket);
    }
}