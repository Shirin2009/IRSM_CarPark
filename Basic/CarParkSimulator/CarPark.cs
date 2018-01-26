using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class CarPark
    {
        //attributes
        private int maxSpaces = 5;
        private int currentSpaces;
        //EntrySensor entrySensor = new EntrySensor();
        //ExitSensor exitSensor = new ExitSensor();
        TicketMachine ticketMachine;
        TicketValidator ticketValidator;
        FullSign fullsign;
        Barrier entryBarrier;
        Barrier exitBarrier;
        List<Ticket> tickets;
        //constructor
        public CarPark(TicketMachine ticketMachine, TicketValidator ticketValidator, FullSign fullsign, Barrier entryBarrier, Barrier exitBarrier)
        {
            currentSpaces = maxSpaces;
            this.ticketMachine = ticketMachine;
            this.ticketValidator = ticketValidator;
            this.fullsign = fullsign;
            this.entryBarrier = entryBarrier;
            this.exitBarrier = exitBarrier;

        }

        public void CarArrivedAtEntrance()
        {
            ticketMachine.CarArrived();
            ticketMachine.GetMessage();
        }

        public void TicketDispensed()
        {
            ticketMachine.CarArrived();
            ticketMachine.PrintTicket();
            ticketMachine.GetMessage();
            entryBarrier.Raise();

        }

        public void CarEnteredCarPark()
        {
            ticketMachine.ClearMessage();
            if (IsFull() == true)
                fullsign.SetLit(true);
            entryBarrier.Lower();
            currentSpaces--;
        }
        public void CarExitedCarPark()
        {
            ticketValidator.ClearMessage();
            if (fullsign.isLit() == true) 
                fullsign.SetLit(false);
            exitBarrier.Lower();
            currentSpaces++;
        }

        public void CarArrivedAtExit()
        {
            ticketValidator.CarArrived();
            ticketValidator.GetMessage();
        }

        public void TicketValidated()
        {
            ticketValidator.CarArrived();
            ticketValidator.GetMessage();
            ticketValidator.TicketEntered();
            exitBarrier.Raise();
        }
        public bool IsFull()
        {
            if (currentSpaces == 0)
            {
                fullsign.SetLit(true);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsEmpty()
        {
            if (currentSpaces == maxSpaces)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool HasSpace()
        {
            if (IsFull() == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetCurrentSpaces()
        {
            return currentSpaces;
        }

    }
}