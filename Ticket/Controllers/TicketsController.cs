using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ticket.Data;
using Ticket.Dtos;
using Ticket.Models;
namespace Ticket.Controllers
{
    // api/tickets
    [Route("api/tickets")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        private IMapper _mapper;

        public TicketsController(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        //private readonly MockTicketRepository _ticketRepository = new MockTicketRepository();
        //GET api/tickets
        [HttpGet]
        public ActionResult<IEnumerable<TicketReadDto>> GetAllTickets()
        {
            var ticketItems = _ticketRepository.GetAllTickets();
            return Ok(_mapper.Map<IEnumerable<TicketReadDto>>(ticketItems));
        }

        // GET api/tickets/{id}
        [HttpGet("{id}", Name = "GetTicketById")]
        public ActionResult<TicketReadDto> GetTicketById(int id)
        {
            var ticketItem = _ticketRepository.GetTicketById(id);
            if (ticketItem != null)
            {
                return Ok(_mapper.Map<TicketReadDto>(ticketItem));
            }
            return NotFound();
        }

        // POST api/tickets
        [HttpPost]
        public ActionResult<TicketReadDto> CreateTicket(TicketCreateDto ticketCreateDto)
        {
            var ticketModel = _mapper.Map<TicketModel>(ticketCreateDto);
            _ticketRepository.CreateTicket(ticketModel);
            _ticketRepository.SaveChanges();

            var ticketReadDto = _mapper.Map<TicketReadDto>(ticketModel);

            return CreatedAtRoute(nameof(GetTicketById), new { Id = ticketReadDto.id }, ticketReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTicket(int id, TicketUpdateDto ticketUpdateDto)
        {
            var ticketModelFromRepository = _ticketRepository.GetTicketById(id);
            if (ticketModelFromRepository == null)
            {
                return NotFound();
            }

            _mapper.Map(ticketUpdateDto, ticketModelFromRepository);

            _ticketRepository.UpdateTicket(ticketModelFromRepository);

            _ticketRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTicket(int id)
        {
            var ticketModelFromRepository = _ticketRepository.GetTicketById(id);
            if (ticketModelFromRepository == null)
            {
                return NotFound();
            }

            _ticketRepository.DeleteTicket(ticketModelFromRepository);
            _ticketRepository.SaveChanges();

            return NoContent();
        }
    }
}