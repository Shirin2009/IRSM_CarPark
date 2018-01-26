using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class TicketMachine
    {
        private string message;
        private CarPark carpark;

        private ActiveTickets activetickets;

        public TicketMachine(ActiveTickets activetickets)
        {
            this.activetickets = activetickets;
        }

        public void AssignCarPark(CarPark carpark)
        {
            this.carpark = carpark;
        }

        public void CarArrived()
        {
            message = "Please press for ticket.";
        }

        public void PrintTicket()
        {
            message = "Thank you, enjoy your stay.";
            activetickets.AddTicket();
            //carpark.TicketDispensed();
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
