using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Protobuf.Reflection.FeatureSet.Types;
using ReservationSystem.Forms;

namespace ReservationSystem.Forms.Frontdesk
{
    public partial class Walkin : Form
    {
        public float[] postCleaningFee = { 299.99F, 399.99F, 499.99F, 599.99F, 699.99F, 799.99F, 899.99F, 999.99F, 1099.99F };
        public float[] reservationFee = { 99.99F, 199.99F, 299.99F, 399.99F, 499.99F, 599.99F, 699.99F, 799.99F, 899.99F };
        public float[] cateringFee = { 999.99F, 1999.99F, 2999.99F };
        public float[] roomFee = { 3499.99F, 3599.99F, 3699.99F, 3999.99F, 4099.99F, 4199.99F, 4999.99F, 5099.99F, 5199.99F };
        public string roomType = "";
        public string venueType = "";
        public string cateringEnabled = "";
        public float totalCharge;
        public DateTime startDate;
        public DateTime endDate;
        public string lastName;
        public string firstName;
        public string reservationStatus;
        public int totalDayOccupancy = 0;
        private string connectionString = DatabaseConfig.ConnectionString;

        public Walkin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            FrontdeskMain frontdeskMain = new FrontdeskMain();
            frontdeskMain.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
         
            roomType = roomTypeCB.Text;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            startDate = dateTimePicker1.Value.Date;
            endDate = dateTimePicker2.Value.Date;

            totalDayOccupancy = (endDate.Date - startDate.Date).Days;

            MessageBox.Show("Total days of reservations: " + totalDayOccupancy.ToString());

            if (roomType != "" && venueType != "" && cateringBool.Text != "" && totalDayOccupancy > 0)
            {
                switch (venueType)
                {
                    default:
                        MessageBox.Show("Pick A Venue!");
                        break;

                    case "Conference Room":
                        switch (roomType)
                        {
                            default:
                                MessageBox.Show("Pick A Room Type!");
                                break;

                            case "Small Room":
                                if (cateringBool.Text == "Included")
                                {
                                    cateringFeeText.Text = (cateringFee[1] * totalDayOccupancy).ToString();
                                    totalCharge = postCleaningFee[3] + reservationFee[3] + (cateringFee[1] * totalDayOccupancy) + (roomFee[3] * totalDayOccupancy);

                                }
                                else
                                {
                                    cateringFeeText.Text = "0.00";
                                    totalCharge = postCleaningFee[3] + reservationFee[3] + (roomFee[3] * totalDayOccupancy);
                                }

                                roomFeeText.Text = (roomFee[3] * totalDayOccupancy).ToString();
                                postCleaningFeeText.Text = postCleaningFee[3].ToString();
                                reservationFeeText.Text = reservationFee[3].ToString();
                                totalChargeText.Text = totalCharge.ToString();
                                break;

                            case "Medium Room":
                                if (cateringBool.Text == "Included")
                                {
                                    cateringFeeText.Text = (cateringFee[1] * totalDayOccupancy).ToString();
                                    totalCharge = postCleaningFee[4] + reservationFee[4] + (cateringFee[1] * totalDayOccupancy) + (roomFee[4] * totalDayOccupancy);

                                }
                                else
                                {
                                    cateringFeeText.Text = "0.00";
                                    totalCharge = postCleaningFee[4] + reservationFee[4] + (roomFee[4] * totalDayOccupancy);
                                }
                                roomFeeText.Text = (roomFee[4] * totalDayOccupancy).ToString();
                                postCleaningFeeText.Text = postCleaningFee[4].ToString();
                                reservationFeeText.Text = reservationFee[4].ToString();
                                totalChargeText.Text = totalCharge.ToString();
                                break;

                            case "Large Room":
                                if (cateringBool.Text == "Included")
                                {
                                    cateringFeeText.Text = (cateringFee[1] * totalDayOccupancy).ToString();
                                    totalCharge = postCleaningFee[5] + reservationFee[5] + (cateringFee[1] * totalDayOccupancy) + (roomFee[5] * totalDayOccupancy);

                                }
                                else
                                {
                                    cateringFeeText.Text = "0.00";
                                    totalCharge = postCleaningFee[5] + reservationFee[5] + (roomFee[5] * totalDayOccupancy);
                                }
                                roomFeeText.Text = (roomFee[5] * totalDayOccupancy).ToString();
                                postCleaningFeeText.Text = postCleaningFee[5].ToString();
                                reservationFeeText.Text = reservationFee[5].ToString();
                                totalChargeText.Text = totalCharge.ToString();
                                break;
                        }
                        break;

                    case "Banquet Hall":
                        switch (roomType)
                        {
                            default:
                                MessageBox.Show("Pick A Room Type!");
                                break;

                            case "Small Room":
                                if (cateringBool.Text == "Included")
                                {
                                    cateringFeeText.Text = (cateringFee[2] * totalDayOccupancy).ToString();
                                    totalCharge = postCleaningFee[6] + reservationFee[6] + (cateringFee[2] * totalDayOccupancy) + (roomFee[6] * totalDayOccupancy);

                                }
                                else
                                {
                                    cateringFeeText.Text = "0.00";
                                    totalCharge = postCleaningFee[6] + reservationFee[6] + (roomFee[6] * totalDayOccupancy);
                                }
                                roomFeeText.Text = (roomFee[6] * totalDayOccupancy).ToString();
                                postCleaningFeeText.Text = postCleaningFee[6].ToString();
                                reservationFeeText.Text = reservationFee[6].ToString();
                                totalChargeText.Text = totalCharge.ToString();
                                break;

                            case "Medium Room":
                                if (cateringBool.Text == "Included")
                                {
                                    cateringFeeText.Text = (cateringFee[2] * totalDayOccupancy).ToString();
                                    totalCharge = postCleaningFee[7] + reservationFee[7] + (cateringFee[2] * totalDayOccupancy) + (roomFee[7] * totalDayOccupancy);

                                }
                                else
                                {
                                    cateringFeeText.Text = "0.00";
                                    totalCharge = postCleaningFee[7] + reservationFee[7] + (roomFee[7] * totalDayOccupancy);
                                }
                                roomFeeText.Text = (roomFee[7] * totalDayOccupancy).ToString();
                                postCleaningFeeText.Text = postCleaningFee[7].ToString();
                                reservationFeeText.Text = reservationFee[7].ToString();
                                totalChargeText.Text = totalCharge.ToString();

                                break;

                            case "Large Room":
                                if (cateringBool.Text == "Included")
                                {
                                    cateringFeeText.Text = (cateringFee[2] * totalDayOccupancy).ToString();
                                    totalCharge = postCleaningFee[8] + reservationFee[8] + (cateringFee[2] * totalDayOccupancy) + (roomFee[8] * totalDayOccupancy);

                                }
                                else
                                {
                                    cateringFeeText.Text = "0.00";
                                    totalCharge = postCleaningFee[8] + reservationFee[8] + (roomFee[8] * totalDayOccupancy);
                                }
                                roomFeeText.Text = (roomFee[8] * totalDayOccupancy).ToString();
                                postCleaningFeeText.Text = postCleaningFee[8].ToString();
                                reservationFeeText.Text = reservationFee[8].ToString();
                                totalChargeText.Text = totalCharge.ToString();
                                break;
                        }
                        break;

                    case "Outdoor Space":
                        switch (roomType)
                        {
                            default:
                                MessageBox.Show("Pick A Room Type!");
                                break;

                            case "Small Room":
                                if (cateringBool.Text == "Included")
                                {
                                    cateringFeeText.Text = (cateringFee[0] * totalDayOccupancy).ToString();
                                    totalCharge = postCleaningFee[0] + reservationFee[0] + (cateringFee[0] * totalDayOccupancy) + (roomFee[0] * totalDayOccupancy);

                                }
                                else
                                {
                                    cateringFeeText.Text = "0.00";
                                    totalCharge = postCleaningFee[0] + reservationFee[0] + (roomFee[0] * totalDayOccupancy);
                                }
                                roomFeeText.Text = (roomFee[0] * totalDayOccupancy).ToString();
                                postCleaningFeeText.Text = postCleaningFee[0].ToString();
                                reservationFeeText.Text = reservationFee[0].ToString();
                                totalChargeText.Text = totalCharge.ToString();
                                break;

                            case "Medium Room":
                                if (cateringBool.Text == "Included")
                                {
                                    cateringFeeText.Text = (cateringFee[0] * totalDayOccupancy).ToString();
                                    totalCharge = postCleaningFee[1] + reservationFee[1] + (cateringFee[0] * totalDayOccupancy) + (roomFee[1] * totalDayOccupancy);

                                }
                                else
                                {
                                    cateringFeeText.Text = "0.00";
                                    totalCharge = postCleaningFee[1] + reservationFee[1] + (roomFee[1] * totalDayOccupancy);
                                }
                                roomFeeText.Text = (roomFee[1] * totalDayOccupancy).ToString();
                                postCleaningFeeText.Text = postCleaningFee[1].ToString();
                                reservationFeeText.Text = reservationFee[1].ToString();
                                totalChargeText.Text = totalCharge.ToString();

                                break;

                            case "Large Room":
                                if (cateringBool.Text == "Included")
                                {
                                    cateringFeeText.Text = (cateringFee[0] * totalDayOccupancy).ToString();
                                    totalCharge = postCleaningFee[2] + reservationFee[2] + (cateringFee[0] * totalDayOccupancy) + (roomFee[2] * totalDayOccupancy);

                                }
                                else
                                {
                                    cateringFeeText.Text = "0.00";
                                    totalCharge = postCleaningFee[2] + reservationFee[2] + (roomFee[2] * totalDayOccupancy);
                                }
                                roomFeeText.Text = (roomFee[2] * totalDayOccupancy).ToString();
                                postCleaningFeeText.Text = postCleaningFee[2].ToString();
                                reservationFeeText.Text = reservationFee[2].ToString();
                                totalChargeText.Text = totalCharge.ToString();
                                break;
                        }
                        break;


                }


                if (promoText.Text == "00000")
                {
                    totalCharge = totalCharge * 0.90F;
                    float promo = totalCharge * 0.10F;
                    promoDiscountText.Text = promo.ToString();
                }
                else
                {
                    promoDiscountText.Text = "0.00";
                }

                float tax = totalCharge * 0.12F;
                totalCharge = totalCharge + (totalCharge * 0.12F);
                vatText.Text = tax.ToString();

                float totalExpenses = totalCharge;
                netExpensesText.Text = totalExpenses.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            roomType = "";
            roomTypeCB.Text = "";
            venueType = "";
            cateringBool.Text = "";
            cateringEnabled = "";
            promoText.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            roomType = roomTypeCB.Text;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            startDate = dateTimePicker1.Value.Date;
            endDate = dateTimePicker2.Value.Date;
            firstName = textBox2.Text;
            lastName = textBox3.Text;
            

            totalDayOccupancy = (endDate.Date - startDate.Date).Days;

            MessageBox.Show("Total days of reservations: " + totalDayOccupancy.ToString());

            if (roomType != "" && venueType != "" && cateringBool.Text != "" && totalDayOccupancy > 0)
            {
                switch (venueType)
                {
                    default:
                        MessageBox.Show("Pick A Venue!");
                        break;

                    case "Conference Room":
                        switch (roomType)
                        {
                            default:
                                MessageBox.Show("Pick A Room Type!");
                                break;

                            case "Small Room":
                                if (cateringBool.Text == "Included")
                                {
                                    cateringFeeText.Text = (cateringFee[1] * totalDayOccupancy).ToString();
                                    totalCharge = postCleaningFee[3] + reservationFee[3] + (cateringFee[1] * totalDayOccupancy) + (roomFee[3] * totalDayOccupancy);

                                }
                                else
                                {
                                    cateringFeeText.Text = "0.00";
                                    totalCharge = postCleaningFee[3] + reservationFee[3] + (roomFee[3] * totalDayOccupancy);
                                }

                                roomFeeText.Text = (roomFee[3] * totalDayOccupancy).ToString();
                                postCleaningFeeText.Text = postCleaningFee[3].ToString();
                                reservationFeeText.Text = reservationFee[3].ToString();
                                totalChargeText.Text = totalCharge.ToString();
                                break;

                            case "Medium Room":
                                if (cateringBool.Text == "Included")
                                {
                                    cateringFeeText.Text = (cateringFee[1] * totalDayOccupancy).ToString();
                                    totalCharge = postCleaningFee[4] + reservationFee[4] + (cateringFee[1] * totalDayOccupancy) + (roomFee[4] * totalDayOccupancy);

                                }
                                else
                                {
                                    cateringFeeText.Text = "0.00";
                                    totalCharge = postCleaningFee[4] + reservationFee[4] + (roomFee[4] * totalDayOccupancy);
                                }
                                roomFeeText.Text = (roomFee[4] * totalDayOccupancy).ToString();
                                postCleaningFeeText.Text = postCleaningFee[4].ToString();
                                reservationFeeText.Text = reservationFee[4].ToString();
                                totalChargeText.Text = totalCharge.ToString();
                                break;

                            case "Large Room":
                                if (cateringBool.Text == "Included")
                                {
                                    cateringFeeText.Text = (cateringFee[1] * totalDayOccupancy).ToString();
                                    totalCharge = postCleaningFee[5] + reservationFee[5] + (cateringFee[1] * totalDayOccupancy) + (roomFee[5] * totalDayOccupancy);

                                }
                                else
                                {
                                    cateringFeeText.Text = "0.00";
                                    totalCharge = postCleaningFee[5] + reservationFee[5] + (roomFee[5] * totalDayOccupancy);
                                }
                                roomFeeText.Text = (roomFee[5] * totalDayOccupancy).ToString();
                                postCleaningFeeText.Text = postCleaningFee[5].ToString();
                                reservationFeeText.Text = reservationFee[5].ToString();
                                totalChargeText.Text = totalCharge.ToString();
                                break;
                        }
                        break;

                    case "Banquet Hall":
                        switch (roomType)
                        {
                            default:
                                MessageBox.Show("Pick A Room Type!");
                                break;

                            case "Small Room":
                                if (cateringBool.Text == "Included")
                                {
                                    cateringFeeText.Text = (cateringFee[2] * totalDayOccupancy).ToString();
                                    totalCharge = postCleaningFee[6] + reservationFee[6] + (cateringFee[2] * totalDayOccupancy) + (roomFee[6] * totalDayOccupancy);

                                }
                                else
                                {
                                    cateringFeeText.Text = "0.00";
                                    totalCharge = postCleaningFee[6] + reservationFee[6] + (roomFee[6] * totalDayOccupancy);
                                }
                                roomFeeText.Text = (roomFee[6] * totalDayOccupancy).ToString();
                                postCleaningFeeText.Text = postCleaningFee[6].ToString();
                                reservationFeeText.Text = reservationFee[6].ToString();
                                totalChargeText.Text = totalCharge.ToString();
                                break;

                            case "Medium Room":
                                if (cateringBool.Text == "Included")
                                {
                                    cateringFeeText.Text = (cateringFee[2] * totalDayOccupancy).ToString();
                                    totalCharge = postCleaningFee[7] + reservationFee[7] + (cateringFee[2] * totalDayOccupancy) + (roomFee[7] * totalDayOccupancy);

                                }
                                else
                                {
                                    cateringFeeText.Text = "0.00";
                                    totalCharge = postCleaningFee[7] + reservationFee[7] + (roomFee[7] * totalDayOccupancy);
                                }
                                roomFeeText.Text = (roomFee[7] * totalDayOccupancy).ToString();
                                postCleaningFeeText.Text = postCleaningFee[7].ToString();
                                reservationFeeText.Text = reservationFee[7].ToString();
                                totalChargeText.Text = totalCharge.ToString();

                                break;

                            case "Large Room":
                                if (cateringBool.Text == "Included")
                                {
                                    cateringFeeText.Text = (cateringFee[2] * totalDayOccupancy).ToString();
                                    totalCharge = postCleaningFee[8] + reservationFee[8] + (cateringFee[2] * totalDayOccupancy) + (roomFee[8] * totalDayOccupancy);

                                }
                                else
                                {
                                    cateringFeeText.Text = "0.00";
                                    totalCharge = postCleaningFee[8] + reservationFee[8] + (roomFee[8] * totalDayOccupancy);
                                }
                                roomFeeText.Text = (roomFee[8] * totalDayOccupancy).ToString();
                                postCleaningFeeText.Text = postCleaningFee[8].ToString();
                                reservationFeeText.Text = reservationFee[8].ToString();
                                totalChargeText.Text = totalCharge.ToString();
                                break;
                        }
                        break;

                    case "Outdoor Space":
                        switch (roomType)
                        {
                            default:
                                MessageBox.Show("Pick A Room Type!");
                                break;

                            case "Small Room":
                                if (cateringBool.Text == "Included")
                                {
                                    cateringFeeText.Text = (cateringFee[0] * totalDayOccupancy).ToString();
                                    totalCharge = postCleaningFee[0] + reservationFee[0] + (cateringFee[0] * totalDayOccupancy) + (roomFee[0] * totalDayOccupancy);

                                }
                                else
                                {
                                    cateringFeeText.Text = "0.00";
                                    totalCharge = postCleaningFee[0] + reservationFee[0] + (roomFee[0] * totalDayOccupancy);
                                }
                                roomFeeText.Text = (roomFee[0] * totalDayOccupancy).ToString();
                                postCleaningFeeText.Text = postCleaningFee[0].ToString();
                                reservationFeeText.Text = reservationFee[0].ToString();
                                totalChargeText.Text = totalCharge.ToString();
                                break;

                            case "Medium Room":
                                if (cateringBool.Text == "Included")
                                {
                                    cateringFeeText.Text = (cateringFee[0] * totalDayOccupancy).ToString();
                                    totalCharge = postCleaningFee[1] + reservationFee[1] + (cateringFee[0] * totalDayOccupancy) + (roomFee[1] * totalDayOccupancy);

                                }
                                else
                                {
                                    cateringFeeText.Text = "0.00";
                                    totalCharge = postCleaningFee[1] + reservationFee[1] + (roomFee[1] * totalDayOccupancy);
                                }
                                roomFeeText.Text = (roomFee[1] * totalDayOccupancy).ToString();
                                postCleaningFeeText.Text = postCleaningFee[1].ToString();
                                reservationFeeText.Text = reservationFee[1].ToString();
                                totalChargeText.Text = totalCharge.ToString();

                                break;

                            case "Large Room":
                                if (cateringBool.Text == "Included")
                                {
                                    cateringFeeText.Text = (cateringFee[0] * totalDayOccupancy).ToString();
                                    totalCharge = postCleaningFee[2] + reservationFee[2] + (cateringFee[0] * totalDayOccupancy) + (roomFee[2] * totalDayOccupancy);

                                }
                                else
                                {
                                    cateringFeeText.Text = "0.00";
                                    totalCharge = postCleaningFee[2] + reservationFee[2] + (roomFee[2] * totalDayOccupancy);
                                }
                                roomFeeText.Text = (roomFee[2] * totalDayOccupancy).ToString();
                                postCleaningFeeText.Text = postCleaningFee[2].ToString();
                                reservationFeeText.Text = reservationFee[2].ToString();
                                totalChargeText.Text = totalCharge.ToString();
                                break;
                        }
                        break;


                }


                if (promoText.Text == "00000")
                {
                    totalCharge = totalCharge * 0.90F;
                    float promo = totalCharge * 0.10F;
                    promoDiscountText.Text = promo.ToString();
                }
                else
                {
                    promoDiscountText.Text = "0.00";
                }

                float tax = totalCharge * 0.12F;
                totalCharge = totalCharge + (totalCharge * 0.12F);
                vatText.Text = tax.ToString();

                float totalExpenses = totalCharge;
                netExpensesText.Text = totalExpenses.ToString();

                string dateValidationQuery = "SELECT reservationID FROM reservations " +
                                  "WHERE  " +
                                  "venue = @venueType " +
                                  "AND room = @roomType " +
                                  "AND (dateStart < @endDate AND dateEnd > @startDate);";

                try
                {

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        using (MySqlCommand command = new MySqlCommand(dateValidationQuery, connection))
                        {
                            command.Parameters.AddWithValue("@venueType", venueType);
                            command.Parameters.AddWithValue("@roomType", roomType);
                            command.Parameters.AddWithValue("@startDate", startDate);
                            command.Parameters.AddWithValue("@endDate", endDate);

                            object result = command.ExecuteScalar();

                            if (result == null)
                            {
                                string queryAddReservation = "INSERT INTO reservations (dateStart, dateEnd, venue, room, bill, firstName, lastName, reservationStatus, catering, accountID) " +
                                                              "VALUES (@dateStart, @dateEnd, @venue, @room, @bill, @firstName, @lastName, @reservationStatus, @catering, @accountID);";

                                reservationStatus = "Under Review";

                                using (MySqlCommand insertReservation = new MySqlCommand(queryAddReservation, connection))
                                {
                                    insertReservation.Parameters.AddWithValue("@dateStart", startDate);
                                    insertReservation.Parameters.AddWithValue("@dateEnd", endDate);
                                    insertReservation.Parameters.AddWithValue("@venue", venueType);
                                    insertReservation.Parameters.AddWithValue("@room", roomType);
                                    insertReservation.Parameters.AddWithValue("@bill", totalExpenses);
                                    insertReservation.Parameters.AddWithValue("@firstName", firstName);
                                    insertReservation.Parameters.AddWithValue("@lastName", lastName);
                                    insertReservation.Parameters.AddWithValue("@reservationStatus", reservationStatus);
                                    insertReservation.Parameters.AddWithValue("@accountID", 0);
                                    insertReservation.Parameters.AddWithValue("@catering", cateringBool.Text);

                                    insertReservation.ExecuteNonQuery();
                                }

                                MessageBox.Show("Reservation Successfully Made!");

                            }
                            else
                            {
                                MessageBox.Show("Date Selected is Occupied!");
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message);
                }
            }
            }

        private void button4_Click(object sender, EventArgs e)
        {
            venueType = "Conference Room";
            MessageBox.Show("Venue: " + venueType);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            venueType = "Banquet Hall";
            MessageBox.Show("Venue: " + venueType);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            venueType = "Outdoor Space";
            MessageBox.Show("Venue: " + venueType);
        }

        private void roomTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string details = "";
            string roomType = roomTypeCB.Text;

            if (string.IsNullOrEmpty(venueType) || string.IsNullOrEmpty(roomType))
            {
                MessageBox.Show("Please select both a venue type and a room type.");
                return;
            }

            switch (venueType)
            {
                case "Conference Room":
                    switch (roomType)
                    {
                        case "Small Room":
                            details = "Byte Room: 10 - 20 People";
                            break;
                        case "Medium Room":
                            details = "Protocol Room: 30 - 50 People";
                            break;
                        case "Large Room":
                            details = "Server Room: 100 - 200 People";
                            break;
                        default:
                            details = "Invalid Room Type for Conference Room.";
                            break;
                    }
                    break;

                case "Banquet Hall":
                    switch (roomType)
                    {
                        case "Small Room":
                            details = "Gateway Hall: 50 - 100 People";
                            break;
                        case "Medium Room":
                            details = "Kernel Hall: 200 - 300 People";
                            break;
                        case "Large Room":
                            details = "Mainframe Hall: 400 - 600 People";
                            break;
                        default:
                            details = "Invalid Room Type for Banquet Hall.";
                            break;
                    }
                    break;

                case "Outdoor Space":
                    switch (roomType)
                    {
                        case "Small Room":
                            details = "LAN Garden: 100 - 200 People";
                            break;
                        case "Medium Room":
                            details = "Medium Outdoor Venue: 200 - 400 People";
                            break;
                        case "Large Room":
                            details = "Fiber Fields: 400 - 700 People";
                            break;
                        default:
                            details = "Invalid Room Type for Outdoor Space.";
                            break;
                    }
                    break;

                default:
                    details = "Invalid Venue Type.";
                    break;
            }

            // Update the label with the formatted description
            label8.Text = details;
        }

        private void Walkin_Load(object sender, EventArgs e)
        {

        }
    }
}
