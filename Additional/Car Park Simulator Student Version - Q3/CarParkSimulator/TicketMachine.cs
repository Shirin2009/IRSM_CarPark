using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class TicketMachine
    {
        private string message;
        private string message2;
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
        }

        public string GetMessage()
        {
            return message;
        }


        public void CarArrived2()
        {
            message2 = "Please press for ticket.";
        }

        public void PrintTicket2()
        {
            message2 = "Thank you, enjoy your stay.";
            activetickets.AddTicket();
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
