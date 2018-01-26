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
        TicketMachine ticketMachine;
        TicketValidator ticketValidator;
        FullSign fullsign;
        Barrier entryBarrier;
        Barrier exitBarrier;

        TicketMachine ticketMachine2;
        TicketValidator ticketValidator2;
        Barrier entryBarrier2;
        Barrier exitBarrier2;
        //constructor
        public CarPark(TicketMachine ticketMachine, TicketMachine ticketMachine2, TicketValidator ticketValidator, TicketValidator ticketValidator2, FullSign fullsign, Barrier entryBarrier, Barrier entryBarrier2, Barrier exitBarrier, Barrier exitBarrier2)
        {
            currentSpaces = maxSpaces;
            this.ticketMachine = ticketMachine;
            this.ticketValidator = ticketValidator;
            this.fullsign = fullsign;
            this.entryBarrier = entryBarrier;
            this.exitBarrier = exitBarrier;


            this.ticketMachine2 = ticketMachine2;
            this.ticketValidator2 = ticketValidator2;
            this.entryBarrier2 = entryBarrier2;
            this.exitBarrier2 = exitBarrier2;
        }

        public void CarArrivedAtEntrance()
        {
            ticketMachine.CarArrived();
            ticketMachine.GetMessage();
        }

        public void CarArrivedAtEntrance2()
        {
            ticketMachine2.CarArrived2();
            ticketMachine2.GetMessage2();
        }

        public void TicketDispensed()
        {
            ticketMachine.CarArrived();
            ticketMachine.PrintTicket();
            ticketMachine.GetMessage();
            entryBarrier.Raise();
        }

        public void TicketDispensed2()
        {
            ticketMachine2.CarArrived2();
            ticketMachine2.PrintTicket2();
            ticketMachine2.GetMessage2();
            entryBarrier2.Raise();
        }

        public void CarEnteredCarPark()
        {
            ticketMachine.ClearMessage();
            if (IsFull() == true)
                fullsign.SetLit(true);
            entryBarrier.Lower();
            currentSpaces--;
        }

        public void CarEnteredCarPark2()
        {
            ticketMachine2.ClearMessage2();
            if (IsFull() == true)
                fullsign.SetLit(true);
            entryBarrier2.Lower();
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

        public void CarExitedCarPark2()
        {
            ticketValidator2.ClearMessage2();
            if (fullsign.isLit() == true)
                fullsign.SetLit(false);
            exitBarrier2.Lower();
            currentSpaces++;
        }

        public void CarArrivedAtExit()
        {
            ticketValidator.CarArrived();
            ticketValidator.GetMessage();
        }


        public void CarArrivedAtExit2()
        {
            ticketValidator2.CarArrived2();
            ticketValidator2.GetMessage2();
        }


        public void TicketValidated()
        {
            ticketValidator.CarArrived();
            ticketValidator.GetMessage();
            ticketValidator.TicketEntered();
            exitBarrier.Raise();
        }

        public void TicketValidated2()
        {
            ticketValidator2.CarArrived();
            ticketValidator2.GetMessage();
            ticketValidator2.TicketEntered2();
            exitBarrier2.Raise();
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