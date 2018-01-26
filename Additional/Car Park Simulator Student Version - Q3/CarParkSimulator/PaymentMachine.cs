using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkSimulator
{
    class PaymentMachine
    {
        private string message;

        public PaymentMachine()
        {

        }

        public void PayTicket(Ticket ticket)
        {
            ticket.SetPaid();
            message = "Thanks for your payment";
        }

        public string GetMessage()
        {
            return message;
        }

        public void ClearMessage()
        {
            message = "";
        }
    }
}
