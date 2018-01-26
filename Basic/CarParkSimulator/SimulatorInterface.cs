using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarParkSimulator
{
    public partial class SimulatorInterface : Form
    {
        // Attributes ///        
        private TicketMachine ticketMachine;
        private ActiveTickets activeTickets;
        private TicketValidator ticketValidator;
        private Barrier entryBarrier;
        private Barrier exitBarrier;
        private FullSign fullSign;
        private CarPark carPark;
        private EntrySensor entrySensor;
        private ExitSensor exitSensor;
        /////////////////


        // Constructor //
        public SimulatorInterface()
        {
            InitializeComponent();
        }
        /////////////////


        // Operations ///
        private void ResetSystem(object sender, EventArgs e)
        {
            // STUDENTS:
            ///// Class contructors are not defined so there will be errors
            ///// This code is correct for the basic version though

            activeTickets = new ActiveTickets();
            ticketMachine = new TicketMachine(activeTickets);
            ticketValidator = new TicketValidator(activeTickets);
            entryBarrier = new Barrier();
            exitBarrier = new Barrier();
            fullSign = new FullSign();
            carPark = new CarPark(ticketMachine, ticketValidator, fullSign, entryBarrier, exitBarrier);
            entrySensor = new EntrySensor(carPark);
            exitSensor = new ExitSensor(carPark);

            ticketMachine.AssignCarPark(carPark);
            ticketValidator.AssignCarPark(carPark);

            /////////////////////////////////////////

            btnCarArrivesAtEntrance.Visible = true;
            btnDriverPressesForTicket.Visible = false;
            btnCarEntersCarPark.Visible = false;
            btnCarArrivesAtExit.Visible = false;
            btnDriverEntersTicket.Visible = false;
            btnCarExitsCarPark.Visible = false;

            UpdateDisplay();
        }

        private void CarArrivesAtEntrance(object sender, EventArgs e)
        {
            carPark.CarArrivedAtEntrance();
            entrySensor.CarDetected();
            btnCarArrivesAtEntrance.Visible = false;
            btnDriverPressesForTicket.Visible = true;
            UpdateDisplay();
        }

        private void DriverPressesForTicket(object sender, EventArgs e)
        {
            carPark.TicketDispensed();
            btnDriverPressesForTicket.Visible = false;
            btnCarEntersCarPark.Visible = true;
            UpdateDisplay();
        }

        private void CarEntersCarPark(object sender, EventArgs e)
        {
            carPark.CarEnteredCarPark();
            entrySensor.CarLeftSensor();
            btnCarEntersCarPark.Visible = false;
            if (carPark.IsFull() == true)
            {
                btnCarArrivesAtEntrance.Visible = false;
            }
            else
            {
                btnCarArrivesAtEntrance.Visible = true;
            }

            if (ActiveRight() == false)
            {
                btnCarArrivesAtExit.Visible = true;
            }
            
            UpdateDisplay();
        }

        private void CarArrivesAtExit(object sender, EventArgs e)
        {
            carPark.CarArrivedAtExit();
            exitSensor.CarDetected();
            btnCarArrivesAtExit.Visible = false;
            btnDriverEntersTicket.Visible = true;
            UpdateDisplay();
        }

        private void DriverEntersTicket(object sender, EventArgs e)
        {
            carPark.TicketValidated();
            btnDriverEntersTicket.Visible = false;
            btnCarExitsCarPark.Visible = true;
            UpdateDisplay();
        }

        private void CarExitsCarPark(object sender, EventArgs e)
        {
            carPark.CarExitedCarPark();
            exitSensor.CarLeftSensor();
            btnCarExitsCarPark.Visible = false;

            if ((carPark.IsEmpty() == false) || (carPark.HasSpace() == true))
                btnCarArrivesAtExit.Visible = true;

            if (carPark.IsEmpty() == true)
            {
                btnCarArrivesAtExit.Visible = false;
            }
            else
            {
                btnCarArrivesAtExit.Visible = true;
            }

            if (ActiveLeft() == false)
            {
                btnCarArrivesAtEntrance.Visible = true;
            }
            UpdateDisplay();
        }

        public bool ActiveLeft()
        {
            if ((btnCarArrivesAtEntrance.Visible == true) || (btnDriverPressesForTicket.Visible == true) || (btnCarEntersCarPark.Visible == true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ActiveRight()
        {
            if ((btnCarArrivesAtExit.Visible == true) || (btnDriverEntersTicket.Visible == true) || (btnCarExitsCarPark.Visible == true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void UpdateDisplay()
        {
            if (entryBarrier.isLifted() == true)
            {
                lblEntryBarrier.Text = "True";
            }
            else
            {
                lblEntryBarrier.Text = "False";
            }
            
            if (entrySensor.IsCarOnSensor() == true)
            {
                lblEntrySensor.Text = "True";
            }
            else
            {
                lblEntrySensor.Text = "False";
            }

            if (exitBarrier.isLifted() == true)
            {
                lblExitBarrier.Text = "True";
            }
            else
            {
                lblExitBarrier.Text = "False";
            }

            if (exitSensor.IsCarOnSensor() == true)
            {
                lblExitSensor.Text = "True";
            }
            else
            {
                lblExitSensor.Text = "False";
            }

            if (fullSign.isLit() == true)
            {
                lblFullSign.Text = "True";
            }
            else
            {
                lblFullSign.Text = "False";
            }
            lblSpaces.Text = Convert.ToString(carPark.GetCurrentSpaces());

            lblTicketMachine.Text = ticketMachine.GetMessage();
            lblTicketValidator.Text = ticketValidator.GetMessage();


            lstActiveTickets.Items.Clear();
            List<Ticket> tickets = activeTickets.GetTickets();

            foreach (Ticket ticket in tickets)
            {
                lstActiveTickets.Items.Add(Convert.ToString("#" + ticket.ticketNumber() + ":" + ticket.IsPaid()));
            }
        }

        private void lblEntrySensor_Click(object sender, EventArgs e)
        {

        }

        private void lblTicketMachine_Click(object sender, EventArgs e)
        {

        }
    }
}
