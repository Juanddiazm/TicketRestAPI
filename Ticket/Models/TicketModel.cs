using System;
using System.ComponentModel.DataAnnotations;

namespace Ticket.Models{
    public class TicketModel{
        [Key]
        public int id { get; set; }
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