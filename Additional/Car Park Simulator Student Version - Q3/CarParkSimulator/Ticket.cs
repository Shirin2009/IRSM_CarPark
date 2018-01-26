using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class Ticket
    {
        private bool paid;
        private int ticketNo;

        public Ticket()
        {
            paid = false;
            Random r = new Random();    // This generates a random number for the ticketNo
            ticketNo = r.Next(0,1000000);
        }

        public int ticketNumber()
        {
            return ticketNo;
        }

        public bool IsPaid()
        {
            return paid;
        }

        public void SetPaid()
        {
            paid = true;
        }
    }
}
