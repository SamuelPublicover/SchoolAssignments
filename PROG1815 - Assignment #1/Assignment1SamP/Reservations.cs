using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1SamP
{
    public partial class Reservations : Form
    {
        //multi-dimension array for rows and seats
        string[,] reservations = new string[5, 6];
        //array to hold waiting list name/seats
        string[] waiting = new string[10];
        //Boolean to determine if a seat is available or not
        Boolean seatsAvailable = true;
        //Boolean to determine if the customer has successfully been added to the waiting list
        Boolean addedToWaiting = false;
        //Boolean created to keep going
        Boolean keepGoing = true;
        public Reservations()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Eliminate old errors being displayed again
            lblErrors.Text = "";
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            lblErrors.Text = "";

            //Clear the text box everytime "show reservations" is closed, this way the list isn't repeated
            rtbReservations.Text = "";

            for (int i=0; i < reservations.GetLength(0); i++)
            {
                string row = lbRow.Items[i].ToString();
                for (int j = 0; j < reservations.GetLength(1); j++)
                {
                    string seat = lbSeat.Items[j].ToString();
                    if (string.IsNullOrEmpty(reservations[i, j]))
                        seatsAvailable = true;
                    rtbReservations.Text += row + seat + " - " + reservations[i, j] + "\n";
                }
            }
            lblErrors.Text = "";
        }

        //Book Button - used to add a customer to the reservations list
        private void btnBook_Click(object sender, EventArgs e)
        {
            lblErrors.Text = "";
            
            rtbReservations.Text = "";
            //Grab the selected indexes of Rows and Labels, and add the Customer Name to the list
            var a = lbRow.SelectedIndex;
            var b = lbSeat.SelectedIndex;
            //If/else to determine whether the requested cell is filled or not
            keepGoing = true;
            if (string.IsNullOrEmpty(tbCustomerName.Text))
            {
                lblErrors.Text = "Please enter a name for the reservation  \n";
                keepGoing = false;
            }
            if (lbRow.SelectedIndex == -1)
            {
                lblErrors.Text += "Please select a row \n";
                keepGoing = false;
            }
            if (lbSeat.SelectedIndex == -1)
            {
                lblErrors.Text += "Please select a seat \n";
                keepGoing = false;
            }
            if (keepGoing)
            {
                if (string.IsNullOrEmpty(reservations[a, b]))
                {
                    reservations[a, b] = tbCustomerName.Text.ToString();
                    MessageBox.Show("The seat for " + reservations[a, b] + " has successfully been reserved", "Congratulations", MessageBoxButtons.OK);
                }
                else
                {
                    lblErrors.Text = "Seat is already booked, please select another seat.\nIf all seats are booked, please join the waiting list\n";
                    //MessageBox.Show("The seat you have selected is already reserved. The following seats are still available:" + ());
                }
                //Re-print out the reservations array after a change is made
                for (int i = 0; i < reservations.GetLength(0); i++)
                {
                    string row = lbRow.Items[i].ToString();
                    for (int j = 0; j < reservations.GetLength(1); j++)
                    {
                        string seat = lbSeat.Items[j].ToString();
                        if (string.IsNullOrEmpty(reservations[i, j]))
                            seatsAvailable = true;
                        rtbReservations.Text += row + seat + " - " + reservations[i, j] + "\n";
                    }
                }
            }
        }

        //AddToWaiting button created to add a customer to the waiting list
        private void btnAddToWaiting_Click(object sender, EventArgs e)
        {
            lblErrors.Text = "";

            if (string.IsNullOrEmpty(tbCustomerName.Text))
            {
                lblErrors.Text = "Please enter a name for the reservation  \n";
            }
            else
            {
                //Set bool seatsAvailable to false, this way the following for loops will determing if seats are still available or not
                seatsAvailable = false;
                //A nested for loop to go through the multidimensional array and determine if there are any empty seats
                for (int row = 0; row < reservations.GetLength(0); row++)
                {
                    for (int column = 0; column < reservations.GetLength(0); column++)
                    {
                        if (string.IsNullOrEmpty(reservations[row, column]))
                        {
                            seatsAvailable = true;
                            //lblErrors.Text += "Seats available at:" + (reservations[row, column]);
                        }

                    }
                }
                //If seatsAvailable is true, advise them they cannot join the waiting list until all seats are filled
                if (seatsAvailable)
                {
                    lblErrors.Text = "You cannot join the waiting list unless their are no more available seats.";
                }
                //Else, add their name to the waiting list, along with their spot in the waiting list. 
                else
                {
                    int i = 0;
                    //Do-While created to try and add user to the waiting list (determines if there are spots available)
                    addedToWaiting = false;
                    do
                    {
                        if (string.IsNullOrEmpty(waiting[i]))
                        {
                            waiting[i] = tbCustomerName.Text;
                            addedToWaiting = true;
                            MessageBox.Show(waiting[i] + " has successfully been added to the waiting list", "Congratulations", MessageBoxButtons.OK);
                        }
                        i++;
                    } while (!addedToWaiting && i < 10);

                    //If statement created to determine if waitlist is full
                    if (!addedToWaiting)
                    {
                        lblErrors.Text = "We apologize for any inconvenience, but all spots in the waiting list are full.\n";
                    }
                }
                rtbWaitingList.Text = "";
                for (int i = 0; i < 10; i++)
                {
                    rtbWaitingList.Text += "#" + (i + 1) + ": " + waiting[i] + "\n";
                }
            }
        }

        //Debug Button created - fills all seats with the customer name
        private void btnDebug_Click(object sender, EventArgs e)
        {
            lblErrors.Text = "";

            for (int i = 0; i < reservations.GetLength(0); i++)
            {
                string row = lbRow.Items[i].ToString();
                for (int j = 0; j < reservations.GetLength(1); j++)
                {
                    string seat = lbSeat.Items[j].ToString();
                    reservations[i, j] += tbCustomerName.Text;
                }
            }
            rtbReservations.Text = "";
            for (int i = 0; i < reservations.GetLength(0); i++)
            {
                string row = lbRow.Items[i].ToString();
                for (int j = 0; j < reservations.GetLength(1); j++)
                {
                    string seat = lbSeat.Items[j].ToString();
                    if (string.IsNullOrEmpty(reservations[i, j]))
                        seatsAvailable = true;
                    rtbReservations.Text += row + seat + " - " + reservations[i, j] + "\n";
                }
            }
        }

        //Waiting List button - displays the customer's on the waiting list, ordered from 1-10 (10 being the max people on the waiting list)
        private void btnWaiting_Click(object sender, EventArgs e)
        {
            lblErrors.Text = "";

            rtbWaitingList.Text = "";
            for (int i = 0; i < 10; i++)
            {
                rtbWaitingList.Text += "#" + (i+1) + ": " + waiting[i] + "\n";
            }

            lblErrors.Text = "";
        }

        //Cancel button - cancels a reservation when a seat and row are selected
        private void btnCancel_Click(object sender, EventArgs e)
        {
            lblErrors.Text = "";

            //Variable to store the selection of seat to be cancelled
            var a = lbRow.SelectedIndex;
            var b = lbSeat.SelectedIndex;
            try
            {
                //if/else created to make sure there's actually a reservation in the seat
                if (string.IsNullOrEmpty(reservations[a, b]))
                {
                    lblErrors.Text = "This seat has not been reserved yet.";
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you would like to delete " + reservations[a,b] + "'s reservation?", "Comfirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        reservations[a, b] = null;
                        MessageBox.Show("The seat for " + reservations[a, b] + " has successfully been cancelled", "Congratulations", MessageBoxButtons.OK);
                        //Nested-For loop to display the reservations after change
                        rtbReservations.Text = "";
                        for (int i = 0; i < reservations.GetLength(0); i++)
                        {
                            string row = lbRow.Items[i].ToString();
                            for (int j = 0; j < reservations.GetLength(1); j++)
                            {
                                string seat = lbSeat.Items[j].ToString();
                                //Once someone is deleted, their spot opens up
                                if (string.IsNullOrEmpty(reservations[i, j]))
                                    seatsAvailable = true;
                                rtbReservations.Text += row + seat + " - " + reservations[i, j] + "\n";
                            }
                        }
                    }
                    //automatically move waiting patron to reservations list
                    //if (seatsAvailable && !(string.IsNullOrEmpty(waiting[0])))
                    //{
                    //    waiting[0] == reservations[a, b];
                    //    for (int w=0; w<9; w++)
                    //    {
                    //        waiting[w] = waiting[w + 1];
                    //        waiting[9] = null;
                    //    }
                    //}
                    

                    //automatically move waiting patron to reserve list
                    if (seatsAvailable && !(string.IsNullOrEmpty(waiting[0])))
                        reservations[a, b] = waiting[0];
                    {
                        waiting[0] = waiting[1];
                        waiting[1] = waiting[2];
                        waiting[2] = waiting[3];
                        waiting[3] = waiting[4];
                        waiting[4] = waiting[5];
                        waiting[5] = waiting[6];
                        waiting[6] = waiting[7];
                        waiting[7] = waiting[8];
                        waiting[8] = waiting[9];
                        waiting[9] = null;

                    }
                    //refresh the reservation list
                    rtbReservations.Text = "";

                    for (int i = 0; i < reservations.GetLength(0); i++)
                    {
                        string row = lbRow.Items[i].ToString();
                        for (int j = 0; j < reservations.GetLength(1); j++)
                        {
                            string seat = lbSeat.Items[j].ToString();
                            if (string.IsNullOrEmpty(reservations[i, j]))
                                seatsAvailable = true;
                            rtbReservations.Text += row + seat + " - " + reservations[i, j] + "\n";
                        }
                    }
                    //refresh the waiting list
                    rtbWaitingList.Text = "";
                    for (int i = 0; i < 10; i++)
                    {
                        rtbWaitingList.Text += "#" + (i + 1) + ": " + waiting[i] + "\n";
                    }
                }
            }
            catch
            {
                lblErrors.Text = "No seat and/or row was selected to be cancelled.";
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
