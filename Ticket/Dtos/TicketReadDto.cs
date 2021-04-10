using System;

namespace Ticket.Dtos
{
    public class TicketReadDto
    {
        public int id { get; set; }
        public int userId { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime lastModifiedDate { get; set; }
        public bool status { get; set; }
    }
}