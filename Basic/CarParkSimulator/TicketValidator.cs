using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class TicketValidator
    {
        private string message;
        private CarPark carpark;

        private ActiveTickets activetickets;

        public TicketValidator(ActiveTickets activetickets)
        {
            this.activetickets = activetickets;
        }

        public void AssignCarPark(CarPark carpark)
        {
            this.carpark = carpark;
        }

        public void CarArrived()
        {
            message = "Please insert your ticket.";
        }

        public void TicketEntered()
        {
            message = "Thank you, drive safely.";
            //carpark.TicketValidated();
            activetickets.RemoveTicket();
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
