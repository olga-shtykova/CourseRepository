using System.Collections.Generic;
using System.Linq;
using UserTicketService.Contracts;
using UserTicketService.Exceptions;

namespace UserTicketService
{
    public class TicketService : ITicketService
    {
        private List<Ticket> FakeBaseData
        {
            get
            {
                return new List<Ticket>
                {
                   new Ticket(1, "Москва - Санкт-Петербург", 3500),
                   new Ticket(2, "Челябинск - Магадан", 3500),
                   new Ticket(3, "Норильск - Уфа", 3500)
                };
            }
        }

        public int GetTicketPrice(int ticketId)
        {
            var ticket = FakeBaseData.FirstOrDefault(t => t.Id == ticketId);
            return (ticket is null) ?
               throw new TicketNotFoundException() : ticket.Price;
        }

        public Ticket GetTicket(int ticketId)
        {
            var ticket = FakeBaseData.FirstOrDefault(t => t.Id == ticketId);
            return (ticket is null) ?
              throw new TicketNotFoundException() : ticket;
        }

        public void SaveTicket(Ticket ticket)
        {
            FakeBaseData.Add(ticket);
        }

        private void DeleteTicket(Ticket ticket)
        {

            FakeBaseData.Remove(ticket);
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return FakeBaseData;
        }
    }
}
