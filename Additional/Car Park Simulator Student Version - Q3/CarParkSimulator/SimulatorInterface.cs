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
        private PaymentMachine paymentMachine;

        private Barrier entryBarrier2;
        private Barrier exitBarrier2;
        private EntrySensor entrySensor2;
        private ExitSensor exitSensor2;
        private TicketMachine ticketMachine2;
        private TicketValidator ticketValidator2;
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
            
            

            entryBarrier2 = new Barrier();
            exitBarrier2 = new Barrier();
            

            ticketMachine2 = new TicketMachine(activeTickets);
            ticketValidator2 = new TicketValidator(activeTickets);

            carPark = new CarPark(ticketMachine, ticketMachine2, ticketValidator, ticketValidator2, fullSign, entryBarrier, entryBarrier2, exitBarrier, exitBarrier2);
            
            
            entrySensor = new EntrySensor(carPark);
            exitSensor = new ExitSensor(carPark);


            entrySensor2 = new EntrySensor(carPark);
            exitSensor2 = new ExitSensor(carPark);

            paymentMachine = new PaymentMachine();
            ticketMachine.AssignCarPark(carPark);
            ticketValidator.AssignCarPark(carPark);

            ticketMachine2.AssignCarPark(carPark);
            ticketValidator.AssignCarPark(carPark);

            /////////////////////////////////////////

            btnCarArrivesAtEntrance.Visible = true;
            btnDriverPressesForTicket.Visible = false;
            btnCarEntersCarPark.Visible = false;
            btnCarArrivesAtExit.Visible = false;
            btnDriverEntersTicket.Visible = false;
            btnCarExitsCarPark.Visible = false;

            btnCarArrivesAtEntrance2.Visible = true;
            btnDriverPressesForTicket2.Visible = false;
            btnCarEntersCarPark2.Visible = false;
            btnCarArrivesAtExit2.Visible = false;
            btnDriverEntersTicket2.Visible = false;
            btnCarExitsCarPark2.Visible = false;

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

            if (ActiveRight2() == false)
            {
                btnCarArrivesAtExit2.Visible = true;
            }
            
            UpdateDisplay();
        }

        private void CarArrivesAtExit(object sender, EventArgs e)
        {
            carPark.CarArrivedAtExit();
            exitSensor.CarDetected();
            btnCarArrivesAtExit.Visible = false;
            btnDriverEntersTicket.Visible = true;

            if (carPark.GetCurrentSpaces() == 4)
            {
                btnCarArrivesAtExit2.Visible = false;
                btnDriverEntersTicket2.Visible = false;
                HideBottom();
            }
            UpdateDisplay();
        }

        private void DriverEntersTicket(object sender, EventArgs e)
        {
            
            if (lstActiveTickets.SelectedIndex != -1)
            {
                string ticket = lstActiveTickets.SelectedItem.ToString();
                int index = lstActiveTickets.Items.IndexOf(ticket);
                bool ispaid = activeTickets.IsTicketPayed(index);


                if (ispaid == true)
                {
                    carPark.TicketValidated();
                    btnDriverEntersTicket.Visible = false;
                    btnCarExitsCarPark.Visible = true;
                }
                else
                {
                    btnDriverEntersTicket.Visible = false;
                    btnCarArrivesAtExit.Visible = true;
                    carPark.CarArrivedAtExit();
                    ticketValidator.TicketPaidFor();
                    if (carPark.GetCurrentSpaces() == 4)
                    {
                        btnCarArrivesAtExit2.Visible = false;
                        btnDriverEntersTicket2.Visible = false;
                        HideBottom();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a ticket from the list");
                btnCarArrivesAtExit.Visible = true;
                btnDriverEntersTicket.Visible = false;
            }
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

        // Second entrance and exit
        private void btnCarArrivesAtEntrance2_Click(object sender, EventArgs e)
        {
            carPark.CarArrivedAtEntrance2();
            entrySensor2.CarDetected2();
            btnCarArrivesAtEntrance2.Visible = false;
            btnDriverPressesForTicket2.Visible = true;
            UpdateDisplay();
        }


        private void btnDriverPressesForTicket2_Click(object sender, EventArgs e)
        {
            carPark.TicketDispensed2();
            btnDriverPressesForTicket2.Visible = false;
            btnCarEntersCarPark2.Visible = true;
            UpdateDisplay();
        }

        private void btnCarEntersCarPark2_Click(object sender, EventArgs e)
        {
            carPark.CarEnteredCarPark2();
            entrySensor2.CarLeftSensor2();
            btnCarEntersCarPark2.Visible = false;
            if (carPark.IsFull() == true)
            {
                btnCarArrivesAtEntrance2.Visible = false;
            }
            else
            {
                btnCarArrivesAtEntrance2.Visible = true;
            }

            if (ActiveRight() == false)
            {
                btnCarArrivesAtExit.Visible = true;
            }

            if (ActiveRight2() == false)
            {
                btnCarArrivesAtExit2.Visible = true;
            }
            UpdateDisplay();
        }

        private void btnCarArrivesAtExit2_Click(object sender, EventArgs e)
        {
            carPark.CarArrivedAtExit2();
            exitSensor2.CarDetected2();
            btnCarArrivesAtExit2.Visible = false;
            btnDriverEntersTicket2.Visible = true;

            if (carPark.GetCurrentSpaces() == 4)
            {
                btnCarArrivesAtExit.Visible = false;
                btnDriverEntersTicket.Visible = false;
                HideTop();
            }

            UpdateDisplay();
        }


        private void btnDriverEntersTicket2_Click(object sender, EventArgs e)
        {
            if (lstActiveTickets.SelectedIndex != -1)
            {
                string ticket = lstActiveTickets.SelectedItem.ToString();
                int index = lstActiveTickets.Items.IndexOf(ticket);
                bool ispaid2 = activeTickets.IsTicketPayed(index);

                if (ispaid2 == true)
                {
                    carPark.TicketValidated2();
                    btnDriverEntersTicket2.Visible = false;
                    btnCarExitsCarPark2.Visible = true;
                }
                else
                {
                    btnDriverEntersTicket2.Visible = false;
                    btnCarArrivesAtExit2.Visible = true;
                    carPark.CarArrivedAtExit2();
                    ticketValidator2.TicketPaidFor();
                    if (carPark.GetCurrentSpaces() == 4)
                    {
                        btnCarArrivesAtExit2.Visible = false;
                        btnDriverEntersTicket2.Visible = false;
                        HideTop();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a ticket from the list");
                btnCarArrivesAtExit2.Visible = true;
                btnDriverEntersTicket2.Visible = false;
            }
            UpdateDisplay();
        }

        private void btnCarExitsCarPark2_Click(object sender, EventArgs e)
        {
            carPark.CarExitedCarPark2();
            exitSensor2.CarLeftSensor2();
            btnCarExitsCarPark2.Visible = false;

            if ((carPark.IsEmpty() == false) || (carPark.HasSpace() == true))
                btnCarArrivesAtExit2.Visible = true;

            if (carPark.IsEmpty() == true)
            {
                btnCarArrivesAtExit2.Visible = false;
            }
            else
            {
                btnCarArrivesAtExit2.Visible = true;
            }

            if (ActiveLeft2() == false)
            {
                btnCarArrivesAtEntrance2.Visible = true;
            }

            if (ActiveLeft() == false)
            {
                btnCarArrivesAtEntrance.Visible = true;
            }
            UpdateDisplay();
        }

        public void HideTop()
        {
            btnDriverEntersTicket.Visible = false;
            btnCarArrivesAtExit.Visible = false;
            btnCarExitsCarPark.Visible = false;
        }

        public void HideBottom()
        {
            btnDriverEntersTicket2.Visible = false;
            btnCarArrivesAtExit2.Visible = false;
            btnCarExitsCarPark2.Visible = false;
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


        // Second entrance and exit
        public bool ActiveLeft2()
        {
            if ((btnCarArrivesAtEntrance2.Visible == true) || (btnDriverPressesForTicket2.Visible == true) || (btnCarEntersCarPark2.Visible == true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ActiveRight2()
        {
            if ((btnCarArrivesAtExit2.Visible == true) || (btnDriverEntersTicket2.Visible == true) || (btnCarExitsCarPark2.Visible == true))
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


            if (entryBarrier2.isLifted() == true)
            {
                lblEntryBarrier2.Text = "True";
            }
            else
            {
                lblEntryBarrier2.Text = "False";
            }
            

            if (entrySensor.IsCarOnSensor() == true)
            {
                lblEntrySensor.Text = "True";
            }
            else
            {
                lblEntrySensor.Text = "False";
            }


            if (entrySensor2.IsCarOnSensor() == true)
            {
                lblEntrySensor2.Text = "True";
            }
            else
            {
                lblEntrySensor2.Text = "False";
            }


            if (exitBarrier.isLifted() == true)
            {
                lblExitBarrier.Text = "True";
            }
            else
            {
                lblExitBarrier.Text = "False";
            }


            if (exitBarrier2.isLifted() == true)
            {
                lblExitBarrier2.Text = "True";
            }
            else
            {
                lblExitBarrier2.Text = "False";
            }


            if (exitSensor.IsCarOnSensor() == true)
            {
                lblExitSensor.Text = "True";
            }
            else
            {
                lblExitSensor.Text = "False";
            }

            if (exitSensor2.IsCarOnSensor() == true)
            {
                lblExitSensor2.Text = "True";
            }
            else
            {
                lblExitSensor2.Text = "False";
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

            lblTicketMachine2.Text = ticketMachine2.GetMessage2();
            lblTicketValidator2.Text = ticketValidator2.GetMessage2();

            lstActiveTickets.Items.Clear();
            List<Ticket> tickets = activeTickets.GetTickets();

            foreach (Ticket ticket in tickets)
            {
                lstActiveTickets.Items.Add(Convert.ToString("#" + ticket.ticketNumber() + " : " + ticket.IsPaid()));
            }

            lblPayTicket.Text = paymentMachine.GetMessage();
            paymentMachine.ClearMessage();
        }

        private void lblEntrySensor_Click(object sender, EventArgs e)
        {

        }

        private void lblTicketMachine_Click(object sender, EventArgs e)
        {

        }

        private void btnPayForTicket_Click(object sender, EventArgs e)
        {
            int index = lstActiveTickets.SelectedIndex;
            if (index != -1)
            {
                Ticket ticket;
                ticket = activeTickets.GetTicket(index);
                paymentMachine.PayTicket(ticket);
                UpdateDisplay();
            }
            else
            {
                MessageBox.Show("Please select the ticket that you want to pay for");
            }
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void lstActiveTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }      
    }
}
