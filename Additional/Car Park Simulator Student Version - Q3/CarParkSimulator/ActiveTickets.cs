using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class ActiveTickets
    {
        private List<Ticket> tickets = new List<Ticket>();

        public ActiveTickets()
        {

        }

        public Ticket GetTicket(int index)
        {
            return tickets[index];
        }

        public bool IsTicketPayed(int index)
        {
            Ticket ticket;
            ticket = tickets[index];
            return ticket.IsPaid();
        }

        public List<Ticket> GetTickets()
        {
            return tickets;
        }

        public void AddTicket()
        {
            tickets.Add(new Ticket());
        }

        public void RemoveTicket()
        {
            tickets.RemoveAt(tickets.Count - 1);
        }
    }
}
