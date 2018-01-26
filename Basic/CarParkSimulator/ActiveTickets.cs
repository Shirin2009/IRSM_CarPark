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

        public List<Ticket> GetTickets()
        {
            return tickets;
        }

        public void AddTicket()
        {
            tickets.Add(new Ticket());  //Adds a new ticket
        }

        public void RemoveTicket()
        {
            tickets.RemoveAt(tickets.Count - 1);
        }
    }
}
