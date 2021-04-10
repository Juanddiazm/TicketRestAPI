using AutoMapper;
using Ticket.Dtos;
using Ticket.Models;

namespace Ticket.Profiles
{
    public class TicketsProfile : Profile
    {
        public TicketsProfile()
        {
            // Source -> Target
            CreateMap<TicketModel, TicketReadDto>();
            CreateMap<TicketCreateDto, TicketModel>();
            CreateMap<TicketUpdateDto, TicketModel>();
        }
    }
}