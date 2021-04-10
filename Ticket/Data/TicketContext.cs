using Microsoft.EntityFrameworkCore;
using Ticket.Models;

namespace Ticket.Data{
    public class TicketContext: DbContext{
        public TicketContext(DbContextOptions<TicketContext> opt) : base(opt){
            
        }


        public DbSet<TicketModel> Tickets { get; set; }
    }
}