using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class TicketValidator
    {
        private string message;
        private string message2;
        private CarPark carpark;

        private ActiveTickets activetickets;

        public TicketValidator(ActiveTickets activetickets)
        {
            this.activetickets = activetickets;
        }

        public void TicketPaidFor()
        {
            message = "Please pay for your ticket";
        }
        public void TicketPaidFor2()
        {
            message2 = "Please pay for your ticket";
        }


        public void AssignCarPark(CarPark carpark)
        {
            this.carpark = carpark;
        }

        public void CarArrived()
        {
            message = "Please insert your ticket.";
        }

        public void CarArrived2()
        {
            message2 = "Please insert your ticket.";
        }

        public void TicketEntered()
        {
            message = "Thank you, drive safely.";
            activetickets.RemoveTicket();
        }

        public void TicketEntered2()
        {
            message2 = "Thank you, drive safely.";
            activetickets.RemoveTicket();
        }

        public string GetMessage()
        {
            return message;
        }

        public string GetMessage2()
        {
            return message2;
        }

        public void ClearMessage()
        {
            message = "";
        }

        public void ClearMessage2()
        {
            message2 = "";
        }

    }
}
