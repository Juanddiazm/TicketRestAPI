using System;
using System.ComponentModel.DataAnnotations;

namespace Ticket.Dtos
{
    public class TicketCreateDto
    {
        [Required]
        public int userId { get; set; }
        [Required]
        public DateTime creationDate { get; set; }
        [Required]
        public DateTime lastModifiedDate { get; set; }
        [Required]
        public bool status { get; set; }
    }
}